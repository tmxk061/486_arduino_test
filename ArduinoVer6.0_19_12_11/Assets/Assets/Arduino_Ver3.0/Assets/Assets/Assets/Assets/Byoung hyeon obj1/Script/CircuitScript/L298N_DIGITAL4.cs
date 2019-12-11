using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L298N_DIGITAL4 : DIGITAL_PARENT
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
    
    private void OnTriggerExit(Collider other)
    {
        manager.DigitalConnect4 = false;
        OnArround(true);
    }
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
                    manager.DigitalConnect4 = true;
                }
            }
        }
    }
    public override void Run()
    {
        if (manager.VccConnect == true && manager.GNDConnect == true)
        { manager.outlist[3].Run(); }
    }
    public override void Pause()
    {
        manager.outlist[3].Pause();
    }
    public override void OnArround(bool b)
    {
        try
        {
            if (b == true)
            {
                Connect = false;
                manager.DigitalConnect4 = false;
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
