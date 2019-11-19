using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMain : MonoBehaviour
{
    public UnitTemplate myTemplate;
    public NavMeshAgent myAgent;


    private int currentLife;
    private int currentDamage;
    private float currentMouvSpeed;
    private bool CanAttack;

    private void OnEnable()
    {
        ResetStats();
    }


    private void ResetStats()
    {
        currentLife = myTemplate.baseLife;
        currentDamage = myTemplate.baseDamage;
        currentMouvSpeed = myTemplate.baseMouvementSpeed;
    }

    private void SetMouvementSpeed()
    {
        // myAgent.speed = UnitManager.distanceBetweenTower
    }

    public void MoveTo(Vector3 posToReach)
    {
        myAgent.SetDestination(posToReach);
    }
  


    public void TakeDamage(int amount)
    {
        currentLife -= amount;
        if (currentLife <= 0)
        {
            Died();
        }

    }
    private void Died()
    {
        Destroy(this);
    }

}
