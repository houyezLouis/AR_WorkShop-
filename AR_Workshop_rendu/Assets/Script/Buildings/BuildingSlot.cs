using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    public MeshRenderer mR;

    private bool isOccupied;
    private GameObject currentTower;

    public int teamNumber;
    private Color teamColor;
    private Material mat;

    UnitTeam myTeam;

    private void Start()
    {
        Initialisation();
    }

    private void Initialisation()
    {
        //Ref et setup 
        //  teamColor = TeamManager.instance.colorsForTeam[teamNumber];
        //Visualisation de l'équipe 
        if (teamNumber == 0)
        {
            teamColor = TeamManager.instance.red.teamColor;
            myTeam = UnitTeam.Red;
        }
        else if (teamNumber ==1)
        {
            teamColor = TeamManager.instance.blue.teamColor;
            myTeam = UnitTeam.Blue;
        }

        mat = mR.material;
        mat.color = teamColor;
        mR.material = mat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13 && myTeam == other.GetComponent<TowerInfo>().towerTeam)
        {
            Debug.Log("collide with tower");
            currentTower = other.gameObject;
            GameManager.instance.CheckTowerInSLot(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentTower == other.gameObject)
        {
            currentTower.transform.localPosition = Vector3.zero;
            currentTower = null;
            GameManager.instance.CheckTowerInSLot(-1);
        }
    }

    private void Update()
    {
        Debug.Log(GameManager.instance.gameIsStart);
        if(currentTower != null && GameManager.instance.gameIsStart == false)
        {
            Vector3 newTowerPOS = new Vector3(transform.position.x, TerrainAR.instance.transform.position.y + TerrainAR.instance.transform.localScale.y/2, currentTower.transform.position.z);
            currentTower.transform.position = newTowerPOS;
        }
    }

}
