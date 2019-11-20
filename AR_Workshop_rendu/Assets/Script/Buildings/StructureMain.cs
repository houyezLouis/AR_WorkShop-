using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureMain : MonoBehaviour
{
    protected bool inASlot;
    public bool onMouvement;

    protected int teamNumber;

    public MeshRenderer mR;
    protected Material mat;

    public virtual void OnSlot(int teamIndex)
    {
        inASlot = true;
        teamNumber = teamIndex;
        MaterialChange();

    }
    public virtual void OutSlot()
    {
        inASlot = false;
        teamNumber = -1;
        MaterialChange();
    }


    public virtual void MaterialChange()
    {
        //Visualisation de l'équipe 
        mat = mR.material;
        if (teamNumber < 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color = TeamManager.instance.colorsForTeam[teamNumber];
        }
        mR.material = mat;
    }
}
