using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookCamera : MonoBehaviour
{
    Camera cam;
    public face myFace;

    Vector3 direction;

    private void Start()
    {
        cam = Camera.main;

        switch (myFace)
        {
            case face.Up:
                direction = Vector3.up;
                break;

            case face.Down:
                direction = Vector3.down;
                break;

            case face.Forward:
                direction = Vector3.forward;
                break;

            case face.Left:
                direction = Vector3.left;
                break;

            case face.Right:
                direction = Vector3.right;
                break;
        }
    }


    void Update()
    {
        transform.LookAt(cam.transform, direction);
    }

    public enum face
    {
        Up,
        Forward,
        Down,
        Right,
        Left
    }
}
