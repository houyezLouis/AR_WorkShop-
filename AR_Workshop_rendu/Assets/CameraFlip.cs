using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlip : MonoBehaviour
{
    public Camera camera;


    void OnPreCull()
    {
        //camera.ResetWorldToCameraMatrix();
        //camera.ResetProjectionMatrix();
        //Vector3 scale = new Vector3(-1, 1, 1);
        //camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(scale);
    }

    void OnPreRender()
    {
        //GL.invertCulling = true;
    }

    void OnPostRender()
    {
        //GL.invertCulling = false;
    }

    private void Update()
    {
        VPToScreenPtExample();
    }

    Texture2D bottomPanel;

    void VPToScreenPtExample()
    {
        var origin = Camera.main.ViewportToScreenPoint(new Vector3(0.25f, 0.1f, 0));
        var extent = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.2f, 0));

        GUI.DrawTexture(new Rect(origin.x, origin.y, extent.x, extent.y), bottomPanel);

        //Debug.Log(camera.ViewportToScreenPoint(new Vector3(0,0,0)));
    }
}
