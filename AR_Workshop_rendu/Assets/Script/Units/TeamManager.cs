using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;
 
    public List<TeamTower> teamList = new List<TeamTower>();
    public Color[] colorsForTeam;

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


    public float SetupDistanceBetweenTowers()
    {
        AssignUnitTeamTarget();
        Vector3 center = teamList[0].transform.position + ((teamList[1].transform.position - teamList[0].transform.position) / 2);
        Terrain.instance.transform.position = center;
        Terrain.terrainHeigth = Mathf.Abs(teamList[1].transform.position.x - teamList[0].transform.position.x);
        return Vector3.Distance(teamList[0].transform.position, teamList[1].transform.position);
    }

    public void AssignUnitTeamTarget()
    {
        for (int i = 0; i < teamList.Count; i++)
        {
            if (i == 0)
            {
                teamList[i].ennemyTeamManagerPos = teamList[1].transform.position;
            }
            else
            {
                teamList[i].ennemyTeamManagerPos = teamList[0].transform.position;
            }
        }
        GameManager.instance.EnoughTeamTower = true;

    }
}
