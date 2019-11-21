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
}
