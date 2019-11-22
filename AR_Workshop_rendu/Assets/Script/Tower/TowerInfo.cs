using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    public UnitTeam towerTeam;
    int life = 1000;

    public bool isAttacked = false;
    public GameObject ennemy;

    public Action OnNotAttacked;
    public Action<UnitTeam> OnDeath;

    public LifeBar myLifeBar;

    private bool isDetected;
    public BoxCollider col;
    private bool inSlot;



    private void Start()
    {
        myLifeBar.startLife = life;
    }

    public void TakeDamage(int _value, GameObject _ennemy)
    {
        life += _value;

        isAttacked = true;
        ennemy = _ennemy;

        StopAllCoroutines();
        StartCoroutine(CheckIsAttaked());

        myLifeBar.SetLife(life);
        if (life <= 0)
        {
            OnDeath(towerTeam);
        }
    }

    IEnumerator CheckIsAttaked()
    {
        yield return new WaitForSeconds(1.5f);
        isAttacked = false;

        OnNotAttacked();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 16 && towerTeam == other.GetComponent<BuildingSlot>().myTeam)
        {
            inSlot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 16)
        {
            inSlot = false;
        }
    }

    private void Update()
    {

        if (col.enabled && !isDetected)
        {
            isDetected = true;
        }
        if (!col.enabled && isDetected)
        {
            isDetected = false;
            if (inSlot)
            {
                GameManager.instance.CheckTowerInSLot(-1);
            }
        }
        //Debug.Log("referencedMap" + GameManager.instance.referencedMap.transform.position);
    }
}
