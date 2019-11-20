﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamTower : StructureMain
{

    public List<UnitMain> unitsInThisTeam = new List<UnitMain>();

    private Vector3 lastPos; 

    //Afin de tracker plus facilement le team manager à 
    private int indexToTarget;
    public Vector3 ennemyTeamManagerPos;


    //faudra faire +1 pour display sur L'UI
    //private int teamNumber;

    private void Start()
    {
        Initialisation();
    }

    private void Initialisation()
    {
        //Ref et setup 
        TeamManager.instance.teamList.Add(this);
        teamNumber = TeamManager.instance.teamList.IndexOf(this);
        //teamColor = TeamManager.instance.colorsForTeam[teamNumber];
        MaterialChange();
    }

    private void Update()
    {
        //faudra check de façon plus propre le déplecement 
        if (lastPos !=transform.position)
        {
            onMouvement = true;
            lastPos = transform.position;
        }
        else
        {
            onMouvement = false;
        }
    }

    

}
