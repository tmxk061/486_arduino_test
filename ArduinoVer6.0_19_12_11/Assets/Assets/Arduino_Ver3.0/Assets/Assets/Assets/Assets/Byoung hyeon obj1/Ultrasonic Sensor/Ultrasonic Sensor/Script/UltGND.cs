using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltGND : PlusMinus
{
    public float VccPower = 0;
    public bool Connect = false;
    public float Electro;

    public GameObject Around;
    public LineManager Line;

    UltValue ultmanager;
    bool LineCheck = false;
    Transform LineObject;

    private void Start()
    {
        ultmanager = GetComponentInParent<UltValue>();
        OnArround(true);
    }

    void Update()
    {
        if (LineObject == isActiveAndEnabled)
        {
            if (LineCheck == true && ultmanager.MouseClick == true)
            {
                LineObject.GetComponent<BoxCollider>().enabled = false;
                LineObject.transform.position = this.Around.transform.position;
                //StartCoroutine(LineMove());
            }
            else if (LineCheck == true && ultmanager.MouseClick == false)
            {
                LineObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Line" )
        {
            Connect = true;
            OnArround(false);
            Line = other.gameObject.GetComponentInParent<LineManager>();
            LineObject = other.gameObject.GetComponent<Transform>();
            LineCheck = true;

            if (Line.parent != null)
            {

                if (Line.parent.tag == "GND")
                {

                    //ledmanager.parant = other.gameObject;
                    ultmanager.GNDConnect = true;


                }
                else if (Line.parent.tag == "BreadGND")
                {
                    ultmanager.GNDConnect = true;
                }
                //================================================
                //else if (LineCheck == true)
                //{
                //    OnArround(true);
                //}
                //================================================
            }


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
            ultmanager.GNDConnect = false;
            Around.SetActive(b);


            //=================================================
            //if (ultmanager.MouseClick == true)
            //{
            //    LineObject.transform.position = Around.transform.position;
            //}
            //=================================================
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
