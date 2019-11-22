﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 1;

    public int damage = 10;
    public GameObject shooter;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10 || other.gameObject.layer == 13)
        {
            switch (other.gameObject.layer)
            {
                case 10:
                    other.gameObject.GetComponent<UnitInfo>().TakeDamage(-damage);
                    break;

                case 13:
                    other.gameObject.GetComponent<TowerInfo>().TakeDamage(-damage, shooter);
                    break;
            }
        }
        Destroy(gameObject);
    }
}
