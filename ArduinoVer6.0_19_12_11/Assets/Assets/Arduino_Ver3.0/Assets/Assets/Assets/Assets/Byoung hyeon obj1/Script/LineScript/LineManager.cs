using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public float plusElectric = 0;
    public float minusElectric = 0;

    public bool ConnectBattery = false;
    public int ConnectSuccese = 0;
    public int Connect1 = 0;
    public int Connect2 = 0;

    public delegate void RunDelegate();
    public RunDelegate run;
    public delegate void PauseDelegate();
    public PauseDelegate pause;
    public delegate void RunServo(float s);
    public RunServo servorun;
    public delegate float LuxRead();
    public LuxRead luxRead;
    public delegate float UltRead();
    public UltRead ultRead;
    public delegate List<float> HumiTempRead();
    public HumiTempRead humitempRead;


    public GameManager.SensorType type = GameManager.SensorType.normal;

    public bool L298N_OUTCONNECT = false;

    //========================================
    [HideInInspector]
    public bool VccConnect;//plus
    [HideInInspector]
    public bool GNDConnect;//minus
    [HideInInspector]
    public bool DigitalConnect;//값 반환
    //========================================
    public GameObject child;

    public float Electro = 0.0f;

    public GameObject parent;
    public StartLine start;
    public PlusGroup plusGroup;
    public int Power = 0;


    private void Start()
    {
        VccConnect = false;
        GNDConnect = false;
        DigitalConnect = false;
        start = GetComponentInChildren<StartLine>();

    }

    public void RunCollect(float s)
    {

        if (run != null)
            run();

        if (servorun != null)
            servorun(s);



    }
    public void PauseCollect()
    {
        if (pause != null)
            pause();
    }


    public void SetParents(GameObject gameObject)
    {

        transform.SetParent(gameObject.transform);
    }

    private void FixedUpdate()
    {

        if (Connect1 == 1 && Connect2 == 1)
        {
            ConnectSuccese = 1;
            //transform.SetParent(parent.transform);
        }
        else if ((Connect1 == 0 || Connect2 == 0) && ConnectBattery == true)
        {
            Electro = 0;
            ConnectSuccese = 0;
        }
        else if ((Connect1 == 0 || Connect2 == 0) && ConnectBattery == false)
        {
            Electro = 0;
            ConnectSuccese = 0;
        }
    }

    private void OnDisable()
    {
        Connect1 = 0;
        Connect2 = 0;
        ConnectSuccese = 0;
        ConnectBattery = false;
        DigitalConnect = false;
        GNDConnect = false;
        VccConnect = false;

    }

    public void DestroyObject()
    {
        // gameObject.transform.DetachChildren();
        Destroy(this.gameObject);
    }
}
