﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToothVCC : PlusMinus
{

    public GameObject Around;
    public CircuitManager circuitManager;
    public LineManager Line;
    Transform LineObject;
    public BlueToothModule BTModule;
    // Start is called before the first frame update
    void Start()
    {
        OnArround(true);

        BTModule = gameObject.GetComponentInParent<BlueToothModule>();


       
    }

    // Update is called once per frame


    private void OnTriggerStay(Collider other)
    {
        //전력을 받는다 
        if (other.tag == "Line")
        {
           
            OnArround(false);
            LineObject = other.gameObject.GetComponent<Transform>();
            Line = other.gameObject.GetComponentInParent<LineManager>();

            if (Line.parent != null)
            {

                if (Line.parent.tag == "VCC")
                {

                    BTModule.VCCConnect = true;


                }
                else if (Line.parent.tag == "BreadVCC")
                {

                    BTModule.VCCConnect = true;


                }
              


            }


        }
    }

    public override void OnArround(bool b)
    {
        try
        {


            Around.SetActive(b);
            if (b == true)
            {
                BTModule.VCCConnect = false;
            }
           

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
