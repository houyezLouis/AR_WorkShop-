using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    public MeshRenderer mR;

    private bool isOccupied;
    private StructureMain currentStructure;

    public int teamNumber;
    private Color teamColor;
    private Material mat;

    private void Start()
    {
        Initialisation();
    }

    private void Initialisation()
    {
        //Ref et setup 
        teamColor = TeamManager.instance.colorsForTeam[teamNumber];
        //Visualisation de l'équipe 
        mat = mR.material;
        mat.color = teamColor;
        mR.material = mat;
    }

    private void Update()
    {
        if (currentStructure != null && !isOccupied )
        {
            if (!currentStructure.onMouvement)
            {
                currentStructure.OnSlot(teamNumber) ;
                isOccupied = true;
                currentStructure.transform.position = transform.position + new Vector3(0, 0.2f, 0);
            }
        }
        if (currentStructure && currentStructure.onMouvement)
        {
            isOccupied = false;
            currentStructure.OutSlot() ;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StructureMain structure = other.GetComponent<StructureMain>();
        if (structure != null)
        {
            currentStructure = structure;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StructureMain structure = other.GetComponent<StructureMain>();
        if (structure == currentStructure)
        {

            currentStructure.OutSlot(); ;
            isOccupied = false;
            currentStructure = null;
        }
    }

}
