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
    }

    public virtual void OutSlot()
    {
        inASlot = false;
        teamNumber = -1;
    }
}
