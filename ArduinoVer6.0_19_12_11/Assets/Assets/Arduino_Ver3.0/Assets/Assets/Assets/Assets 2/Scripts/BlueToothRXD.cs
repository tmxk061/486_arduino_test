using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueToothRXD : PlusMinus
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
        //전력을 받는다 q
        if (other.tag == "Line")
        {

            OnArround(false);
            LineObject = other.gameObject.GetComponent<Transform>();
            Line = other.gameObject.GetComponentInParent<LineManager>();

            if (Line.parent != null)
            {

                if (Line.parent.tag == "DIGITAL")
                {
                    Debug.Log(Line.parent.name);
                    BTModule.RXDConnect = true;


                }
                else if (Line.parent.tag == "BreadDIGITAL")
                {
                    
                    BTModule.RXDConnect = true;
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
                BTModule.RXDConnect = false;
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
