using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image Life;
    public Image Damage;

    public float startLife = 100;
    float life = 1;

    public bool isUnit = false;

    // Update is called once per frame
    void Update()
    {
        Life.fillAmount = life;

        Damage.fillAmount = Mathf.Lerp(Damage.fillAmount, life, 0.2f);

        if (isUnit)
        {
            if(1 == life)
            {
                if (Life.gameObject.activeSelf)
                {
                    Life.gameObject.SetActive(false);
                    Damage.gameObject.SetActive(false);
                    gameObject.GetComponent<Image>().enabled = false;
                }
            }
            else {
                if (!Life.gameObject.activeSelf)
                {
                    Life.gameObject.SetActive(true);
                    Damage.gameObject.SetActive(true);
                    gameObject.GetComponent<Image>().enabled = true;
                }
            }
        }
    }

    public void SetLife(float value)
    {
        life = value / startLife;
        life = Mathf.Clamp(life, 0, 1);
    }
}
