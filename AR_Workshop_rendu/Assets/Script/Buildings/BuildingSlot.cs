﻿using System.Collections;
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
        mat.SetFloat("_Mode", 3);
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
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentTower == other.gameObject)
        {
            //Debug.Log("tower sortie");
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
        if (currentTower != null && GameManager.instance.gameIsStart == false)
        {
            Vector3 newTowerPOS = new Vector3(transform.position.x, TerrainAR.instance.transform.position.y + TerrainAR.instance.transform.localScale.y / 2, currentTower.transform.position.z);

            //Debug.Log("Go");

            currentTower.transform.position = newTowerPOS;
            currentTower.transform.rotation = Quaternion.Euler(0, 90, 0);
        }


    }

}
