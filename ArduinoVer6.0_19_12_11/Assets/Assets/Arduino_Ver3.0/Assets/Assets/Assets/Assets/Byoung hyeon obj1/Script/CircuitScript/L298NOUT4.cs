using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L298NOUT4 : MonoBehaviour
{
    public bool VccConnect { get; set; }
    public bool GNDConnect { get; set; }
    public bool DigitalConnect3 { get; set; }
    public bool DigitalConnect4 { get; set; }
    public int POWER { get; set; }
    public GameObject Around;
    public LineManager Line;
    public L298N_MANAGER manager;
    // Start is called before the first frame update
    public DIGITAL_PARENT DCPin;
    void Start()
    {
        VccConnect = false;
        GNDConnect = false;
        DigitalConnect3 = false;
        DigitalConnect4 = false;
        POWER = 0;
        manager = GetComponentInParent<L298N_MANAGER>();
    }

    // Update is called once per frame
    void Update()
    {
        VccConnect = manager.VccConnect;
        GNDConnect = manager.GNDConnect;
        DigitalConnect3 = manager.DigitalConnect3;
        DigitalConnect4 = manager.DigitalConnect4;
        POWER = manager.POWER;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Line")
        {
            Line = other.gameObject.GetComponentInParent<LineManager>();
           

            OnArround(false);

            if (Line.parent != null)
            {
                
                if (Line.parent.name == "DCPinPlus")
                {
                    
                    DCPin = Line.parent.GetComponentInParent<DCPlus>();
                  
                }
                else if(Line.parent.name=="DCPinMin")
                {
                    
                    DCPin = Line.parent.GetComponentInParent<DCMin>();
                }
            }
        }
    }


    public void Run()
    {
        if(DCPin != null)
        {
            DCPin.Run();
        }
    }
    public void Pause()
    {
        if (DCPin != null)
        {
            DCPin.Pause();
        }
    }
    public void OnArround(bool b)
    {
        try
        {
            Around.SetActive(b);

        }
        catch (Exception)
        {
            Func(delegate () { return true; });
        }

    }

    void Func(Func<bool> callback)
    {
        callback();
    }
}
