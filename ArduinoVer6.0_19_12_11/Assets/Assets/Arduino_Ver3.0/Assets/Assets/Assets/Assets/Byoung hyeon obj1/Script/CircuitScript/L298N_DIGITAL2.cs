using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L298N_DIGITAL2 : DIGITAL_PARENT
{

    L298N_MANAGER manager;
    public bool Connect = false;
    public GameObject Around;
    public LineManager Line;
    // Start is called before the first frame update
    

    void Start()
    {
        manager = GetComponentInParent<L298N_MANAGER>();
        OnArround(true);
    }

    // Update is called once per frame
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Line")
        {
            Line = other.gameObject.GetComponentInParent<LineManager>();
            Connect = true;

            OnArround(false);
            if (Line.parent != null)
            {
                if (Line.parent.tag == "DIGITAL")
                {
                    manager.DigitalConnect2 = true;
                }
            }
        }
    }

    public override void Run()
    {
        if (manager.VccConnect == true && manager.GNDConnect == true)
        { manager.outlist[1].Run(); }
    }

    public override void Pause()
    {
        manager.outlist[1].Pause();
    }
    public override void OnArround(bool b)
    {
        try
        {
            if (b == true)
            {
                Connect = false;
                manager.DigitalConnect2 = false;
            }
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
