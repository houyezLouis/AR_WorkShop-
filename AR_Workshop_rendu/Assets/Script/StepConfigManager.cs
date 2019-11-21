using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepConfigManager : MonoBehaviour
{

    #region global attributes

    #region public attributes

    public static StepConfigManager instance;

    public GameObject panelDetectMap;
    public GameObject panelNeedValidateMap;

    public bool instantiatePrefab;

    // Steps
    public bool mapDetected = false;
    public bool mapInstanciated;
    public bool mapSized;

    public bool configFinished;

    # endregion public attributes

    #region protected attributes

    protected GameObject map;
    protected int actualStep;

    #endregion protected attributes

    # endregion global public

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            init();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mapDetected)
        {
            panelDetectMap.SetActive(false);
            panelNeedValidateMap.SetActive(true);
        }
        else
        {
            panelDetectMap.SetActive(true);
            panelNeedValidateMap.SetActive(false);
        }
    }

    private void init()
    {
        actualStep = 0;

        instantiatePrefab = false;

        mapDetected = false;
        mapInstanciated = false;
        mapSized = false;

        configFinished = false;

        map = GameObject.Find("MapTarget");
    }

    public void instantiate()
    {
        instantiatePrefab = true;
        actualStep++;
    }

    public void SetMapDetector(bool state)
    {
        mapDetected = state;
    }
}
