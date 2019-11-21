using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class CustomVuforiaButton : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject vbButton;

    public UnityEvent eventsOnPressed;

    public UnityEvent eventsOnRelease;



    // Start is called before the first frame update
    void Awake()
    {
        vbButton = GameObject.Find("VirtualButton");
        vbButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    public void OnButtonPressed (VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Is Pressed");
        eventsOnPressed.Invoke();
        
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Is Released");
        eventsOnRelease.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
