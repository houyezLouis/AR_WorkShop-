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

    public UnitTeam myTeam;

    public List<GameObject> myFabri = new List<GameObject>();

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
        else if (teamNumber == 1)
        {
            teamColor = TeamManager.instance.blue.teamColor;
            myTeam = UnitTeam.Blue;
        }

        mat = mR.material;
        mat.SetFloat("_Mode", 2);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;
        mat.color = teamColor;
        mR.material = mat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13 && myTeam == other.GetComponent<TowerInfo>().towerTeam)
        {
            currentTower = other.gameObject;
            GameManager.instance.CheckTowerInSLot(1);

            GameManager.instance.towers[GameManager.instance.towerPlaced - 1] = currentTower;
        }

        if(other.gameObject.layer == 14)
        {
            myFabri.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentTower == other.gameObject)
        {
            //Debug.Log("tower sortie");
            currentTower.transform.parent.localPosition = Vector3.zero;
            currentTower.transform.localPosition = Vector3.zero;
            currentTower = null;
            GameManager.instance.CheckTowerInSLot(-1);

            GameManager.instance.towers[GameManager.instance.towerPlaced] = null;
        }
    }

    private void Update()
    {
        //Debug.Log("y = " + TerrainAR.instance.transform.position.y + TerrainAR.instance.transform.localScale.y / 2);

        //Debug.Log(GameManager.instance.gameIsStart);

        if (currentTower != null && GameManager.instance.gameIsStart == false && currentTower.transform.parent != null)
        {
            Vector3 newTowerPOS = new Vector3(transform.position.x, TerrainAR.instance.transform.position.y + TerrainAR.instance.transform.localScale.y / 2, currentTower.transform.parent.position.z);

            currentTower.transform.parent.position = newTowerPOS;
            currentTower.transform.parent.rotation = Quaternion.Euler(0, 90, 0);
        }


        foreach (GameObject element in myFabri)
        {
            Vector3 newTowerPOS = new Vector3(transform.position.x, TerrainAR.instance.transform.position.y + TerrainAR.instance.transform.localScale.y / 2, element.transform.parent.position.z);
            element.transform.position = newTowerPOS;
            element.transform.rotation = Quaternion.Euler(0, 90, 0);

            if(Vector3.Distance(element.transform.position, element.transform.parent.position) > 8)
            {
                myFabri.Remove(element);
                element.transform.localPosition = new Vector3(0,0.1f,0);
                element.transform.localRotation = new Quaternion(0,0,0,0);
            }
        }
    }
}
