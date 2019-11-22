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



    private void Start()
    {
        myLifeBar.startLife = life;
    }

    public void TakeDamage(int _value, GameObject _ennemy)
    {
        life += _value;

        isAttacked = true;
        _ennemy = ennemy;

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
        if (GameManager.instance.isTerrainSet)
        {
            transform.position = new Vector3(transform.position.x, TerrainAR.instance.transform.position.y + TerrainAR.instance.transform.localScale.y / 2, transform.position.z);
            transform.rotation = Quaternion.Euler(0,90,0);
        }

        //Debug.Log("referencedMap" + GameManager.instance.referencedMap.transform.position);

    }
}
