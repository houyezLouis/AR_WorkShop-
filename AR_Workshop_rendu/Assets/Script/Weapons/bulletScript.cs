using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 1;

    public int damage = 10;

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
                    other.gameObject.GetComponent<UnitLife>().TakeDamage(-damage);
                    break;

                case 13:
                    other.gameObject.GetComponent<TowerLife>().TakeDamage(-damage);
                    break;
            }
        }
        Destroy(gameObject);
    }
}
