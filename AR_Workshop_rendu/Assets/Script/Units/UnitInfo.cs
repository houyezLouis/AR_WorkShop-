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

    public LifeBar myLifeBar;

    public SpriteRenderer circle;

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
        myLifeBar.startLife = life;
    }

    public void SetTeam(UnitTeam value)
    {
        unitTeam = value;
        print(unitTeam);

        switch (unitTeam)
        {
            case UnitTeam.Blue:
                circle.color = Color.blue;
                break;

            case UnitTeam.Red:
                circle.color = Color.red;
                break;
        }
    }

    public void TakeDamage(int value)
    {
        life += value;
        myLifeBar.SetLife(life);

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
