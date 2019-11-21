using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject instruction, btn_ValidatePlacement, btn_ValidateTaille, btn_Play;
    public Slider sld_Width, sld_Heigth;


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

    private void Start()
    {
        TerrainInitialisation();
    }

    private void TerrainInitialisation()
    {
        TerrainAR.instance.SetWidth(sld_Width);
        TerrainAR.instance.SetHeigth(sld_Heigth);
    }

    public void ValideSize()
    {
        btn_ValidateTaille.SetActive(false);
        sld_Width.gameObject.SetActive(false);
        sld_Heigth.gameObject.SetActive(false);

        instruction.SetActive(true);

    }



    public void ValidPlacement()
    {
        instruction.SetActive(false);
        btn_ValidatePlacement.SetActive(false);
       // btn_Play.SetActive(true);

       // GameManager.instance.gameIsStart = true;
    }
}
