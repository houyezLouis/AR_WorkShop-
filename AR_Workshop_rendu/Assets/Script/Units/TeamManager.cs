using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;


    public teamTowerInfo red;
    public teamTowerInfo blue;


    private bool TeamSetup;


    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void OnDisable()
    {
        red.myTowerInfo.OnDeath -= OnTowerDeath;
        blue.myTowerInfo.OnDeath -= OnTowerDeath;
    }

    void OnTowerDeath(UnitTeam teamDead)
    {
        Time.timeScale = 0;
        string textValue = "";
        Color colorValue = Color.white;

        switch (teamDead)
        {
            case UnitTeam.Blue:
                textValue = "Red win !";
                colorValue = red.teamColor;
                break;

            case UnitTeam.Red:
                textValue = "Blue win !";
                colorValue = blue.teamColor;
                break;
        }


        UIManager.instance.DisplayEndPanel(textValue, colorValue);
    }


    public float SetupDistanceBetweenTowers()
    {
       // Vector3 center = red.towerTransform.position + ((blue.towerTransform.position - red.towerTransform.position) / 2);
        //TerrainAR.instance.transform.position = center;
        TerrainAR.terrainHeigth = Mathf.Abs(blue.towerTransform.position.x - red.towerTransform.position.x);
        TerrainAR.terrainWidth= Mathf.Abs(blue.towerTransform.position.z - red.towerTransform.position.z);

        return Vector3.Distance(red.towerTransform.position, blue.towerTransform.position);
    }

    public teamTowerInfo GetTeamInfo(UnitTeam team)
    {
        if(team == red.myTeam)
        {
            return red;
        }

        if (team == blue.myTeam)
        {
            return blue;
        }

        return red;
    }
}


[System.Serializable]
public struct teamTowerInfo
{  
    public Transform towerTransform;
    public Color teamColor;
    public TowerInfo myTowerInfo;
    public UnitTeam myTeam;
}
