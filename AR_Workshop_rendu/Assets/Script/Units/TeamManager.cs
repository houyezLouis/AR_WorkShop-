using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public MeshRenderer mR;
    public List<UnitMain> unitsInThisTeam = new List<UnitMain>();


    //Afin de tracker plus facilement le team manager à 
    private int indexToTarget;
    private Transform ennemyTeamManagerPos;


    //faudra faire +1 pour display sur L'UI
    private int teamNumber;
    private Color teamColor;
    private Material mat;

    private void Start()
    {
        Initialisation();
    }

    private void Initialisation()
    {
        //Ref et setup 
        UnitManager.instance.teamList.Add(this);
        teamNumber =  UnitManager.instance.teamList.IndexOf(this);
        teamColor = UnitManager.instance.colorsForTeam[teamNumber];
        //Visualisation de l'équipe 
        mat = mR.material;
        mat.color = teamColor;
        mR.material = mat;
        // Definition du transform a target pour les units
        int numberOfTeam = UnitManager.instance.teamList.Count;
        if (teamNumber == numberOfTeam - 1)
        {
            ennemyTeamManagerPos = UnitManager.instance.teamList[0].transform;
        }
        else
        {
            ennemyTeamManagerPos = UnitManager.instance.teamList[teamNumber + 1 ].transform;
        }

    }

}
