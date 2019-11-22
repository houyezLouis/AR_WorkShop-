using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabriqueBehaviour : MonoBehaviour
{
    public GameObject redPrefab, BluePrefab;
    public GameObject childGraph;
    public MeshRenderer mR;
    // public MeshCollider myCollider;
    public bool inSlot;
    public bool collideWithAnotherStructure;
    public bool inMouvement;
    private bool stateChange;

    public BuildingSlot currentSlot;

    private Vector3 lastPos;


    public void SwitchType(int teamIndex)
    {
        switch (teamIndex)
        {
            case 0:
                redPrefab.SetActive(true);
                BluePrefab.SetActive(false);
                childGraph.SetActive(false);
                mR.enabled = false;
                break;
            case 1:
                redPrefab.SetActive(false);
                BluePrefab.SetActive(true);
                childGraph.SetActive(false);
                mR.enabled = false;
                break;

            default:
                redPrefab.SetActive(false);
                BluePrefab.SetActive(false);
                childGraph.SetActive(true);
                mR.enabled = true;
                break;
        }
    }

    private void Update()
    {
        CheckPos();
        CheckState();
    }

    private void CheckPos()
    {
        if (Vector3.Distance(lastPos, transform.position) < 1)
        {
            inMouvement = false;
        }
        else
        {
            inMouvement = true;
        }
        lastPos = transform.position;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 14 || other.gameObject.layer == 13)
        {
            collideWithAnotherStructure = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 14 || other.gameObject.layer == 13)
        {
            collideWithAnotherStructure = false;
        }
        BuildingSlot slot = other.GetComponent<BuildingSlot>();
        if (slot == currentSlot)
        {
            currentSlot = null;
            inSlot = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        BuildingSlot slot = other.GetComponent<BuildingSlot>();
        if (slot != null)
        {
            currentSlot = slot;
            inSlot = true;
        }
    }

    private void CheckState()
    {
        if (inSlot && !collideWithAnotherStructure && !inMouvement)
        {
            if (stateChange)
            {
                if (currentSlot == null)
                {
                    SwitchType(-1);
                }
                else
                {
                    SwitchType(currentSlot.teamNumber);
                    //transform.position = new Vector3(currentSlot.transform.position.x , 0, transform.position.z);
                }
            }
            stateChange = false;
        }
        else
        {
            SwitchType(-1);
            stateChange = true;
        }

    }
}
