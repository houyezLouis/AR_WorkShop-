using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    public UnitTeam towerTeam;
    int life = 1000;

    public bool isAttacked = false;

    public Action OnNotAttacked;
    public Action<UnitTeam> OnDeath;

    public LifeBar myLifeBar;



    private void Start()
    {
        myLifeBar.startLife = life;
    }

    public void TakeDamage(int value)
    {
        life += value;

        isAttacked = true;

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

    private void Update()
    {
        //if (GameManager.instance.isTerrainSet)
        //    transform.localPosition = new Vector3((GameManager.instance.referencedMap.transform.position.x + transform.localPosition.x),
        //        (GameManager.instance.referencedMap.transform.position.y + transform.localPosition.y),
        //        (GameManager.instance.referencedMap.transform.position.z + transform.localPosition.z));

        //Debug.Log("referencedMap" + GameManager.instance.referencedMap.transform.position);

    }
}
