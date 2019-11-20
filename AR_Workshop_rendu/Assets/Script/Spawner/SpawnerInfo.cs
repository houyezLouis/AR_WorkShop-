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

    // Start is called before the first frame update
    //void Start()
    //{
    //    StartCoroutine(SpawnUnit());
    //}
    private void OnEnable()
    {
        StartCoroutine(SpawnUnit());
    }

    IEnumerator SpawnUnit()
    {
        yield return new WaitForSeconds(delay);
        GameObject newUnit = Instantiate(prefab);
        newUnit.transform.position = spawnPos.position;

        newUnit.GetComponent<UnitInfo>().unitTeam = towerTeam;
        newUnit.GetComponent<IAUnit>().SetDestination(GameObject.Find(towerEnnemyName).transform);

        StartCoroutine(SpawnUnit());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnUnit());
    }
}
