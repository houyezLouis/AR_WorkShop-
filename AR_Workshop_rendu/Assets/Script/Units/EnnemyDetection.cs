using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDetection : MonoBehaviour
{
    IAUnit myIAUnit;

    private void Start()
    {
        myIAUnit = GetComponentInParent<IAUnit>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer != 10 && other.gameObject.layer != 13) { return; }

        if(other.gameObject == myIAUnit.currentEnnemy)
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
