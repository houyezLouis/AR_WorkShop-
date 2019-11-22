using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInfo : MonoBehaviour
{
    public UnitTeam towerTeam;
    public UnitType type;

    public GameObject prefab;
    public Transform spawnPos;

    public float delay = 10;

    public string towerEnnemyName = "RedTower";

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(SpawnUnit());
    }

    IEnumerator SpawnUnit()
    {
        yield return new WaitForSeconds(delay);

        if(GetComponent<MeshRenderer>().isVisible == false)
        {
            StopAllCoroutines();
        }
        else
        {
            GameObject newUnit = Instantiate(prefab);
            newUnit.transform.position = spawnPos.position;

            newUnit.GetComponent<UnitInfo>().SetTeam(towerTeam);
            newUnit.GetComponent<IAUnit>().SetDestination(GameObject.Find(towerEnnemyName).transform);

            StartCoroutine(SpawnUnit());
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
