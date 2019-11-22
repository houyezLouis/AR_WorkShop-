using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAUnit : MonoBehaviour
{
    Animator myAnimator;
    NavMeshAgent myAgent;
    AttackUnit attackUnit;
    UnitInfo myInfo;

    Transform destination;

    public GameObject currentEnnemy;

    bool canAttack = true;

    public float attackDelay = 1;

    public TowerInfo myTower;

    // Start is called before the first frame update
    void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myAgent = GetComponent<NavMeshAgent>();
        attackUnit = GetComponent<AttackUnit>();
        myInfo = GetComponent<UnitInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnnemy != null)
        {
            myAnimator.SetBool("Forward", false);
            myAgent.isStopped = true;
            transform.LookAt(currentEnnemy.transform, Vector3.up);

            if (canAttack)
            {
                canAttack = false;
                StartCoroutine(Attack());
            }
        }
        else
        {
            myAnimator.SetBool("Forward", true);
            myAgent.isStopped = false;
        }
    }

    public void SetDestination(Transform pos)
    {
        myTower = TeamManager.instance.GetTeamInfo(myInfo.unitTeam).myTowerInfo;
        destination = pos;

        myAgent.SetDestination(destination.position);

        //check if attacked
        print(myTower.isAttacked);
        if (myTower.isAttacked)
        {
            myAgent.SetDestination(myTower.ennemy.transform.position);
            myTower.OnNotAttacked += OnTowerNotAttacked;
        }
        else
        {
            myAgent.SetDestination(destination.position);
        }
    }

    IEnumerator Attack()
    {
        myAnimator.SetTrigger("Attack");
        attackUnit.Attack();
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    void OnTowerNotAttacked()
    {
        myAgent.SetDestination(destination.position);
        myTower.OnNotAttacked -= OnTowerNotAttacked;
    }
}

