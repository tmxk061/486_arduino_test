using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCMin : DIGITAL_PARENT
{
    public int VccPower = 0;
    public bool Connect = false;
    public float Electro;
    public int POWER;
    public GameObject Around;
    public LineManager Line;

    DC dcmanager;
    bool LineCheck = false;
    Transform LineObject;

    private void Start()
    {
        dcmanager = GetComponentInParent<DC>();
        OnArround(true);
    }

    //private void OnTriggerEnter(Collider other)
    //{        //전력을 받는다 
    //    if (other.tag == "Line")
    //    {
    //        Connect = true;
    //        OnArround(false);
    //        Line = other.gameObject.GetComponentInParent<LineManager>();
    //    }
    //}
    void Update()
    {
        if (LineObject == isActiveAndEnabled)
        {
            if (LineCheck == true && dcmanager.MouseClick == true)
            {
                LineObject.GetComponent<BoxCollider>().enabled = false;
                LineObject.transform.position = this.Around.transform.position;

                //StartCoroutine(LineMove());
            }
            else if (LineCheck == true && dcmanager.MouseClick == false)
            {
                LineObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    public override void Run()
    {
        dcmanager.direction = false;
        dcmanager.Run();
    }
    private void OnTriggerExit(Collider other)
    {
        
        OnArround(true);
        dcmanager.DigitalConnectMinus = false;
  
    }
    public override void Pause()
    {
        dcmanager.Pause();
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Line")
        {
            Connect = true;
            OnArround(false);
            Line = other.gameObject.GetComponentInParent<LineManager>();
            LineObject = other.gameObject.GetComponent<Transform>();
            LineCheck = true;

            if (Line != null)
            {

                if (Line.L298N_OUTCONNECT==true)
                {
                    dcmanager.l298connect2 = true;

                }


            }
            //================================================
            //else if (LineCheck == true)
            //{
            //    OnArround(true);
            //}
            //================================================

        }


    }

    private void OnConnect(bool c)
    {
        //Connect = c;
    }

    public override void OnArround(bool b)
    {
        try
        {
            if (b == true)
            {
                dcmanager.GNDConnect = false;
                dcmanager.VccConnect = false;
                dcmanager.DigitalConnectMinus = false;
                dcmanager.l298connect2 = false;
                dcmanager.First = false;
                dcmanager.Pause();
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
