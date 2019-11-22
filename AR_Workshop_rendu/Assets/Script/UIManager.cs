using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject instruction, btn_ValidateTaille, btn_ValidateGround, btn_ValidateTower, btn_Ready;

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
        TerrainAR.instance.SetWidth(0);
        TerrainAR.instance.SetHeigth(0);
    }

    public void ValideSize()
    {
        btn_ValidateTaille.SetActive(false);
        instruction.SetActive(true);
    }


    public void HideInstruction()
    {
        btn_Ready.SetActive(false);
        instruction.SetActive(false);
    }

    public void DisplayRemoveGroundCard()
    {
        instruction.GetComponent<Text>().text = "Nice !! Remove the ground card !";
        btn_ValidateTaille.SetActive(false);
        btn_ValidateGround.SetActive(true);
    }

    public void DisplayTowerPlaceInstruction()
    {
        btn_ValidateGround.SetActive(false);
        instruction.GetComponent<Text>().text = "Please place your towers card!";
        btn_ValidateTower.SetActive(false);
    }

    public void DisplayRemoveTowerCard()
    {
        instruction.GetComponent<Text>().text = "Nice !! Remove the tower cards !";
        btn_ValidateTower.SetActive(false);
        btn_Ready.SetActive(true);
    }

    public void ValidPlacement()
    {
        instruction.SetActive(false);
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
        GameManager.instance.previewMat.color = new Color32(11, 255, 0, 100);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
