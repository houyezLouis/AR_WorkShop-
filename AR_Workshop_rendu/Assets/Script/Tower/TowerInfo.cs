using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    public UnitTeam towerTeam;
    public int life = 1000;

    public bool isAttacked = false;

    public Action OnNotAttacked;

    public void TakeDamage(int value)
    {
        life += value;

        isAttacked = true;

        StopAllCoroutines();
        StartCoroutine(CheckIsAttaked());

        if (life <= 0)
        {
            
        }
    }

    IEnumerator CheckIsAttaked()
    {
        yield return new WaitForSeconds(1.5f);
        isAttacked = false;

        OnNotAttacked();
    }
}
