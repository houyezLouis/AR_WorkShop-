using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamTower : MonoBehaviour
{
    public MeshRenderer mR;
    public List<UnitMain> unitsInThisTeam = new List<UnitMain>();


    //Afin de tracker plus facilement le team manager à 
    private int indexToTarget;
    public Vector3 ennemyTeamManagerPos;


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
        TeamManager.instance.teamList.Add(this);
        teamNumber = TeamManager.instance.teamList.IndexOf(this);
        teamColor = TeamManager.instance.colorsForTeam[teamNumber];
        //Visualisation de l'équipe 
        mat = mR.material;
        mat.color = teamColor;
        mR.material = mat;
    } 

    public void GenerateSpawnZone()
    {

    }

}
