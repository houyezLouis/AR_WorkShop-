using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter), typeof(MeshRenderer))]
public class TerrainAR : MonoBehaviour
{
    public static TerrainAR instance;
    public GameObject slotPrefab;
    public NavMeshSurface surface;

    public int terrainFractionNumber;
    public float myWidth;
    public float myHeigth;

    private float  baseHeigth , baseWidth;

    public static float terrainHeigth;
    public static float terrainWidth;
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
        baseWidth = myWidth;
        baseHeigth = myHeigth;
    }

    public void SetWidth(Slider mySlider)
    {
        //myWidth = terrainWidth + mySlider.value;
        myWidth = baseWidth + mySlider.value;
        transform.localScale = new Vector3(myHeigth, myWidth, 0.1f);
        //spawnZoneHeigth = terrainHeigth / terrainFractionNumber;
    }
    public void SetHeigth(Slider mySlider)
    {

         myHeigth = baseHeigth +  mySlider.value;
        //myHeigth = terrainHeigth + mySlider.value;
        transform.localScale = new Vector3(myHeigth, myWidth, 0.1f);
        spawnZoneHeigth = myHeigth / terrainFractionNumber;

    }


    public void CreateSlot()
    {

        float fractionWidth = myWidth / GameManager.instance.slotNumber;
        float fractionHeigth = myHeigth / terrainFractionNumber;

        for (int i = 0; i < 2; i++)
        {
            float posX = transform.position.x - myHeigth / 2 + fractionHeigth / 2 + i * (fractionHeigth * (terrainFractionNumber - 1));
            float posY = transform.position.z ;
            Vector3 pos = new Vector3(posX, transform.position.y + 0.2f, posY);
            GameObject newSlot = Instantiate(slotPrefab, pos, Quaternion.Euler(90f, 0f, 0f));
            newSlot.transform.localScale = new Vector3(fractionHeigth - fractionHeigth / 20, myWidth - fractionWidth / 20, 1);
            BuildingSlot slotScript = newSlot.GetComponent<BuildingSlot>();
            slotScript.teamNumber = i;
        }
    }

}
