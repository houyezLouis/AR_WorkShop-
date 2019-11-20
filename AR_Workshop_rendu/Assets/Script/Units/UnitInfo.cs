using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitInfo : MonoBehaviour
{
    public UnitType unitType;
    public UnitTeam unitTeam;
    public int life = 100;

    //Attaque
    public int damage;
    public float attackDelay;
    public float speed;
    public float range;

    public UnitTemplate myConfig;

    public CapsuleCollider rangeCollider;

    // Start is called before the first frame update
    void Start()
    {
        //get value
        life = myConfig.baseLife;
        damage = myConfig.baseDamage;
        attackDelay = 1;
        speed = myConfig.baseMouvementSpeed;
        range = myConfig.range;

        rangeCollider.radius = range;
        GetComponent<NavMeshAgent>().speed = speed;
    }

    public void SetTeam(UnitTeam value)
    {
        unitTeam = value;
    }

    public void TakeDamage(int value)
    {
        life += value;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
