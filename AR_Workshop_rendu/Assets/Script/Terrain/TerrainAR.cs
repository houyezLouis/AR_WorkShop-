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

    private float baseHeigth, baseWidth;

    public static float terrainHeigth;
    public static float terrainWidth;


    private void Awake()
    {
        if (instance)
        {
            Destroy(instance);
            instance = this;
        }
        else
        {
            instance = this;
        }

        baseHeigth = myHeigth;
        baseWidth = myWidth;
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

        myHeigth = baseHeigth + mySlider.value;
        //myHeigth = terrainHeigth + mySlider.value;
        transform.localScale = new Vector3(myHeigth, myWidth, 0.1f);

    }


    public void CreateSlot()
    {
        terrainFractionNumber = this.terrainFractionNumber;

        float fractionHeigth = 1f / (float)terrainFractionNumber;

        for (int i = 0; i < 2; i++)
        {
            Debug.Log("fractionHeigth : " + fractionHeigth);


            float posZ = -0.5f +  fractionHeigth / 2 + i * (fractionHeigth * (terrainFractionNumber - 1));          
            Vector3 pos = new Vector3(0, 0.55f, posZ);

            //GameObject newSlot = Instantiate(slotPrefab, pos, Quaternion.Euler(90f, 0f, 0f), transform);

            GameObject newSlot = Instantiate(slotPrefab, transform);
            //newSlot.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            newSlot.transform.localPosition = pos;

            //newSlot.transform.localScale = new Vector3(fractionHeigth - fractionHeigth / 20, myWidth/2 - fractionWidth / 20, 1);
            newSlot.transform.localScale = new Vector3(1, fractionHeigth, 1);
            BuildingSlot slotScript = newSlot.GetComponent<BuildingSlot>();
            slotScript.teamNumber = i;
        }
    }

}
