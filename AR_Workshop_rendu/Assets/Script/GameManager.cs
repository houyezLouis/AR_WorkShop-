using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject teamTowerPrefab;
    public GameObject terrainPrefab;
    public Material previewMat;
    public int slotNumber;


    public GameObject referencedMap;



    public static GameManager instance;
    public static float distanceBetweenTower;

    //public bool EnoughTeamTower;

    public bool towerPlacementDone;
    private int towerPlaced;


    public bool ValidateTerrain;
    private bool SetupDone;

    public bool isTerrainSet = false;
    public bool areTowersSet;


    public bool gameIsStart = false;

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

        referencedMap = Instantiate(terrainPrefab, pos.position, pos.rotation /*Quaternion.Euler(0 , 90 , 0)*/);
        referencedMap.transform.localScale = new Vector3(pos.localScale.x * 1.5f, pos.localScale.y * 0.1f, pos.localScale.z * 2.8f);

        NavMeshRebaker.instance.surfaces[0] = TerrainAR.instance.GetComponent<NavMeshSurface>();

        ValidateMap();
    }


    public void ValidateMap()
    {
        NavMeshRebaker.instance.BuildNavMesh();
        TerrainAR.instance.CreateSlot();
        UIManager.instance.ValideSize();
        isTerrainSet = true;
    }

    public void CheckTowerInSLot(int towerVariation)
    {
        towerPlaced += towerVariation;
        if (towerPlaced == 2)
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
        //NavMeshRebaker.instance.BuildNavMesh();
        //TerrainAR.instance.CreateSlot();
        //distanceBetweenTower = TeamManager.instance.SetupDistanceBetweenTowers();
        UIManager.instance.ValidPlacement();
    }
}
