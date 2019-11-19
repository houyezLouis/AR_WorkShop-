using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLife : MonoBehaviour
{
    public int life = 1000;


    public void TakeDamage(int value)
    {
        life += value;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
