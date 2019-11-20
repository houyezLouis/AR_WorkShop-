using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUnit : MonoBehaviour
{
    public unitType myType;

    public GameObject bullets;
    public Transform bulletSpawnPos;

    IAUnit myIAUnit;

    public enum unitType
    {
        Chevalier,
        Soldat
    }

    private void Start()
    {
        myIAUnit = GetComponent<IAUnit>();
    }

    public void Attack()
    {
        switch (myType)
        {
            case unitType.Chevalier:
                StartCoroutine(ChevalierAttack());
                break;

            case unitType.Soldat:
                StartCoroutine(SoldatAttack());
                break;
        }
    }

    IEnumerator ChevalierAttack()
    {
        yield return new WaitForSeconds(0.5f);

        if (myIAUnit.currentEnnemy != null)
        {

            switch (myIAUnit.currentEnnemy.layer)
            {
                case 10:
                    myIAUnit.currentEnnemy.GetComponent<UnitInfo>().TakeDamage(-35);
                    break;

                case 13:
                    myIAUnit.currentEnnemy.GetComponent<TowerInfo>().TakeDamage(-35);
                    break;
            }
        }
    }

    IEnumerator SoldatAttack()
    {
        yield return new WaitForSeconds(0.1f);
        CreateBullet();

        yield return new WaitForSeconds(0.1f);
        CreateBullet();

        yield return new WaitForSeconds(0.1f);
        CreateBullet();
    }

    void CreateBullet()
    {
        GameObject newBullet = Instantiate(bullets);
        newBullet.transform.position = bulletSpawnPos.position;
        newBullet.transform.rotation = bulletSpawnPos.rotation;
    }
}
