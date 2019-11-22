using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject teamTowerPrefab;
    public GameObject terrainPrefab;
    public GameObject redprefab;
    public GameObject bluePrefab;

    public Material previewMat;
    public int slotNumber;

    public GameObject[] towers = new GameObject[2];

    public GameObject referencedMap;



    public static GameManager instance;
    public static float distanceBetweenTower;

    //public bool EnoughTeamTower;

    public bool towerPlacementDone;
    public int towerPlaced;


    public bool ValidateTerrain;
    private bool SetupDone;

    public bool isTerrainSet = false;
    public bool areTowersSet;


    public bool gameIsStart = false;

    public GameObject redTarget;
    public GameObject blueTarget;

    private void Awake()
    {
        isTerrainSet = false;

        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }


    //private void Update()
    //{
    //    Debug.Log("Phase1");
    //    if (TeamManager.instance.red.towerTransform != null && TeamManager.instance.blue.towerTransform != null && !SetupDone)
    //    {
    //        if (!EnoughTeamTower)
    //        {
    //            Debug.Log("Phase2");
    //            if (Input.GetKeyDown(KeyCode.Space))
    //            {
    //                distanceBetweenTower = TeamManager.instance.SetupDistanceBetweenTowers();
    //            }
    //        }
    //        if (!ValidateTerrain && EnoughTeamTower)
    //        {
    //            Debug.Log("Phase3");
    //           // TerrainAR.instance.SetScale();
    //            if (Input.GetKeyDown(KeyCode.R))
    //            {
    //                NavMeshRebaker.instance.BuildNavMesh();
    //                Debug.Log("Phase4");
    //                ValidateTerrain = true;
    //                TerrainAR.instance.CreateSlot();
    //                SetupDone = true;
    //            }
    //        }
    //    }
    //}


    private void OnApplicationQuit()
    {
        previewMat.color = new Color32(11, 255, 0, 100);
    }

    public void GenerateMap(Transform pos)
    {
        previewMat.color = new Color32(11, 255, 0, 0);

        Vector3 newPos = transform.position;

        referencedMap = Instantiate(terrainPrefab, pos.transform.position, /*pos.rotation*/ Quaternion.Euler(0, 90, 0));
        referencedMap.transform.localScale = new Vector3(pos.localScale.x * 1.5f, pos.localScale.y * 0.1f, pos.localScale.z * 2.8f);

        //NavMeshRebaker.instance.surfaces[0] = TerrainAR.instance.GetComponent<NavMeshSurface>();

        ValidateMap();
    }


    public void ValidateMap()
    {
        NavMeshRebaker.instance.BuildNavMesh();
        TerrainAR.instance.CreateSlot();
        UIManager.instance.ValideSize();
        isTerrainSet = true;
    }

    public void BuildNav()
    {
        NavMeshRebaker.instance.BuildNavMesh();
    }

    public void CheckTowerInSLot(int towerVariation)
    {
        towerPlaced += towerVariation;
        if (towerVariation <0)
        {
            Debug.Log("Nuit");
        }
        else
        {
            Debug.Log("Jour");
        }

        if (towerPlaced > 2)
        {
            towerPlaced = 2;
        }
        else if (towerPlaced == 2)
        {
            UIManager.instance.btn_ValidatePlacement.SetActive(true);
            towerPlacementDone = true;
        }
        else
        {
            UIManager.instance.btn_ValidatePlacement.SetActive(false);
            towerPlacementDone = false;
        }
    }

    public void ValidateTowerPos()
    {
        NavMeshRebaker.instance.BuildNavMesh();
        //TerrainAR.instance.CreateSlot();
        //distanceBetweenTower = TeamManager.instance.SetupDistanceBetweenTowers();

        TeamManager.instance.red.towerTransform.parent = null;
        TeamManager.instance.blue.towerTransform.parent = null;

        for (int i = 0; i < towers.Length; i++)
        {
            if (towers[i].name == redprefab.name)
            {
                GameObject redTower = Instantiate(redprefab, towers[i].transform.position, Quaternion.identity);
                towers[i] = redTower;
                TeamManager.instance.red.towerTransform = redTower.transform;
                TeamManager.instance.red.myTowerInfo = redTower.GetComponent<TowerInfo>();
            }
            else
            {
                GameObject blueTower = Instantiate(bluePrefab, towers[i].transform.position, Quaternion.identity);
                towers[i] = blueTower;
                TeamManager.instance.blue.towerTransform = blueTower.transform;
                TeamManager.instance.blue.myTowerInfo = blueTower.GetComponent<TowerInfo>();
            }


        }

        UIManager.instance.ValidPlacement();
    }
}
