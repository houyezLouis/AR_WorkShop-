using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject instruction, btn_ValidatePlacement, btn_ValidateTaille, btn_Play;
    public Slider sld_Width, sld_Heigth;

    public GameObject end_Panel, btn_end;
    public Text end_TextMain, end_Text2;
    public Image end_Flag1, end_Flag2;


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
        GameManager.instance.gameIsStart = true;
    }

    public void DisplayEndPanel(string textValue, Color colorValue)
    {
        end_Panel.SetActive(true);
        end_TextMain.text = textValue;
        end_Text2.text = textValue;

        end_TextMain.color = colorValue;
        end_Flag1.color = colorValue;
        end_Flag2.color = colorValue;
    }

    public void Rematch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
