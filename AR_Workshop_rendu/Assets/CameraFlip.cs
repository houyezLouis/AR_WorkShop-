using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFlip : MonoBehaviour
{
    public Camera camera;
    public RenderTexture camText;
    public RawImage rImage;

    private void Awake()
    {
        rImage.texture = camText;
        rImage.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    void OnPreCull()
    {
        //camera.ResetWorldToCameraMatrix();
        //camera.ResetProjectionMatrix();
        //Vector3 scale = new Vector3(-1, 1, 1);
        //camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(scale);
        //camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera.targetTexture.width = Screen.width;
        camera.targetTexture.height = Screen.height;

        ScalableBufferManager.ResizeBuffers(Screen.width, Screen.height);
        //camera.targetTexture.Release();

        //camText = new RenderTexture(Screen.width, Screen.height, 24);
        //camera.targetTexture = camText;


        //camera.targetTexture = camText;
        
    }

    void OnPreRender()
    {
        //GL.invertCulling = true;
    }

    void OnPostRender()
    {
        //GL.invertCulling = false;
    }

    void OnGUI()
    {
        //VPToScreenPtExample();
    }


    void VPToScreenPtExample()
    {
        var origin = Camera.main.ViewportToScreenPoint(new Vector3(1, 1, 0));
        var extent = Camera.main.ViewportToScreenPoint(new Vector3(-1, -1, 0));

        //camText.width = Screen.width;
        //camText.height = Screen.height;


        //camera.targetTexture.width = Screen.width;


        //GUI.DrawTexture(new Rect(origin.x, origin.y, extent.x, extent.y), camera.targetTexture);
        

        //GUI.DrawTexture(new Rect(0, 0, 1000, 100), test);

        //Debug.Log(camera.ViewportToScreenPoint(new Vector3(0,0,0)));
    }
}
