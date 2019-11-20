using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDetection : MonoBehaviour
{
    IAUnit myIAUnit;
    UnitInfo myUnitInfo;

    private void Start()
    {
        myIAUnit = GetComponentInParent<IAUnit>();
        myUnitInfo = GetComponentInParent<UnitInfo>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer != 10 && other.gameObject.layer != 13) { return; }

        UnitTeam otherTeam = UnitTeam.Blue;
        switch (other.gameObject.layer)
        {
            case 10:
                otherTeam = other.gameObject.GetComponent<UnitInfo>().unitTeam;
                break;

            case 13:
                otherTeam = other.gameObject.GetComponent<TowerInfo>().towerTeam;
                break;
        }

        if (otherTeam == myUnitInfo.unitTeam)
        {
            return;
        }


        if (other.gameObject == myIAUnit.currentEnnemy)
        {
            return;
        }

        if(myIAUnit.currentEnnemy == null && other.gameObject != myIAUnit.currentEnnemy)
        {
            myIAUnit.currentEnnemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 10) { return; }
        if (other.gameObject == myIAUnit.currentEnnemy)
        {
            myIAUnit.currentEnnemy = null;
            return;
        }
    }
}
