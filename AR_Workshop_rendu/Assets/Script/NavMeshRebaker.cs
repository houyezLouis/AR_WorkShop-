using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshRebaker : MonoBehaviour
{
    public static NavMeshRebaker instance;
    public NavMeshSurface[] surfaces;

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
    public void BuildNavMesh()
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
            Debug.Log("Baking NavMesh");
        }


    }
}

