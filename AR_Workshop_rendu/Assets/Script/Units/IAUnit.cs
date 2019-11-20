using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAUnit : MonoBehaviour
{
    Animator myAnimator;
    NavMeshAgent myAgent;
    AttackUnit attackUnit;

    public Transform destination;

    public GameObject currentEnnemy;

    bool canAttack = true;

    public float attackDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAgent = GetComponent<NavMeshAgent>();
        attackUnit = GetComponent<AttackUnit>();


        // A enlever
        //SetDestination();
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

    public void SetDestination()
    {
        myAgent.SetDestination(destination.position);
    }

    IEnumerator Attack()
    {
        myAnimator.SetTrigger("Attack");
        attackUnit.Attack();
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}

