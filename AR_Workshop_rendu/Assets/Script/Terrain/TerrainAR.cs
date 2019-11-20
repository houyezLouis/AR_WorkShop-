using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter), typeof(MeshRenderer))]
public class TerrainAR : MonoBehaviour
{
    public static TerrainAR instance;
    public GameObject slotPrefab;

    public int terrainFractionNumber;
    public float width;

    public static float terrainHeigth;
    public static float spawnZoneHeigth;

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

    public void SetScale()
    {
        transform.localScale = new Vector3(terrainHeigth, width, 0);
        spawnZoneHeigth = terrainHeigth / terrainFractionNumber;
    }

    public void CreateSlot()
    {
        float fractionWidth = width / GameManager.instance.slotNumber;
        float fractionHeigth = terrainHeigth / terrainFractionNumber;
        for (int i = 0; i < 2; i++)
        {
            if (true)
            {

            }
            float posX = transform.position.x - terrainHeigth / 2 + fractionHeigth / 2 + i * (fractionHeigth * (terrainFractionNumber - 1));
            int currentTeam = i;

            for (int y = 0; y < GameManager.instance.slotNumber; y++)
            {
                float posY = transform.position.z - width / 2 + fractionWidth / 2 + fractionWidth * y;
                Vector3 pos = new Vector3(posX, transform.position.y + 0.2f, posY);
                GameObject newSlot = Instantiate(slotPrefab, pos, Quaternion.Euler(90f , 0f , 0f));
                newSlot.transform.localScale = new Vector3(fractionHeigth - fractionHeigth/20, fractionWidth - fractionWidth/20, 1);
                BuildingSlot slotScript = newSlot.GetComponent<BuildingSlot>();
                slotScript.teamNumber = i;
            }
        }

    }

}
