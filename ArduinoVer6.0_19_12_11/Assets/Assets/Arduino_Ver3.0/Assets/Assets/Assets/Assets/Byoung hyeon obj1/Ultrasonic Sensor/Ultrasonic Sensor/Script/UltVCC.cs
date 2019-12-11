using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltVCC : PlusMinus
{
    public float VccPower = 0;
    public bool Connect = false;
    public float Electro;

    public GameObject Around;
    public LineManager Line;

    UltValue ultmanager;
    Resist resi;

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

    /*rivate void OnTriggerEnter(Collider other)
    {        //전력을 받는다 
        if (other.tag == "Line")
        {
            Connect = true;
            OnArround(false);
            Line = other.gameObject.GetComponentInParent<LineManager>();
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        
      

        if ((other.tag == "Line"))
        {
            Connect = true;
            OnArround(false);
            Line = other.gameObject.GetComponentInParent<LineManager>();
            LineObject = other.gameObject.GetComponent<Transform>();
            LineCheck = true;

            if (Line.parent != null)
            {
               

                if (Line.parent.tag == "VCC")
                {

                    //ledmanager.parant = other.gameObject;
                    ultmanager.VccConnect = true;


                }
                else if (Line.parent.tag == "BreadPlus")
                {

                    ultmanager.VccConnect = true;

                }
               
              /*  else if (Line.parent.tag == "resister")
                {
                    
                    resi = Line.parent.GetComponentInParent<Resist>();
                   
                    ultmanager.VccPower = resi.Power;
                    if (resi.LineParent.tag == "VCC")
                    {
                       ultmanager.VccConnect = true;
                    }
                }*/
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
            if (b == true)
            {
                ultmanager.VccConnect = false;
                LineCheck = false;
            }
            
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
