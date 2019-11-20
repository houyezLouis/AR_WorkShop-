using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject teamTowerPrefab;
    public int slotNumber;


    public static GameManager instance;
    public static float distanceBetweenTower;

    public bool EnoughTeamTower;
    public bool ValidateTerrain;
    private bool SetupDone;


    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        Debug.Log("Phase1");
        if (TeamManager.instance.teamList.Count >= 2 && !SetupDone)
        {
            if (!EnoughTeamTower)
            {
                Debug.Log("Phase2");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    distanceBetweenTower = TeamManager.instance.SetupDistanceBetweenTowers();
                }
            }
            if (!ValidateTerrain && EnoughTeamTower)
            {
                Debug.Log("Phase3");
                TerrainAR.instance.SetScale();
                if (Input.GetKeyDown(KeyCode.R))
                {
                    NavMeshRebaker.instance.BuildNavMesh();
                    Debug.Log("Phase4");
                    ValidateTerrain = true;
                    TerrainAR.instance.CreateSlot();
                    SetupDone = true;
                }
            }
        }
    }



    public void CreateTeamTower(Vector3 pos)
    {
        Instantiate(teamTowerPrefab, pos, Quaternion.identity);
    }
}
