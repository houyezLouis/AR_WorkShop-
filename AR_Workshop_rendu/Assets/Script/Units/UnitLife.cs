using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLife : MonoBehaviour
{
    public int life = 100;


    public void TakeDamage(int value)
    {
        life += value;

        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
