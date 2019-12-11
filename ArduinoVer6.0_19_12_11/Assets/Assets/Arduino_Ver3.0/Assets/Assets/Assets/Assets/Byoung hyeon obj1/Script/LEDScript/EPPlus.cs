using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPPlus : PlusMinus
{
    public bool Connect = false;
    public float Electro;

    public GameObject Around;
    public CircuitManager circuitManager;
    public LineManager Line;
    public Resist resi;
    LEDManager ledmanager;

    Transform LineObject;
    bool LineCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        OnArround(true);
        ledmanager = GetComponentInParent<LEDManager>();
    }

    // Update is called once per frame

    void Update()
    {
        if (LineObject == isActiveAndEnabled)
        {
            if (LineCheck == true && ledmanager.MouseClick == true)
            {
                LineObject.GetComponent<BoxCollider>().enabled = false;
                LineObject.transform.position = this.Around.transform.position;
                //StartCoroutine(LineMove());
            }
            else if (LineCheck == true && ledmanager.MouseClick == false)
            {
                LineObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //전력을 받는다 
        if (other.tag == "Line" )
        {
            Connect = true;
            Line = other.gameObject.GetComponentInParent<LineManager>();
            LineObject = other.gameObject.GetComponent<Transform>();
            LineCheck = true;
            OnArround(false);

            if (Line.parent != null)
            {
                if (Line.parent.tag == "DIGITAL")
                {
                    
                    ledmanager.DigitalConnect = true;
                    
                   
                }
                else if (Line.parent.tag == "BreadDIGITAL")
                {

                    ledmanager.DigitalConnect = true;
                    
                }
                else if(Line.parent.tag=="resister")
                {
                    resi = Line.parent.GetComponent<Resist>();
                    ledmanager.power = resi.Power;
                    if(resi.LineParent.tag=="DIGITAL")
                    {
                        ledmanager.DigitalConnect = true;
                    }
                }
                //================================================
                //else if (LineCheck == true)
                //{
                //    OnArround(true);
                //    Connect = false;
                //}
                //================================================
                ledmanager.power = Line.Power;

            }
           

            //배터리와 연결 완료 시
            if (Line.ConnectSuccese == 1 && Line.ConnectBattery == true && circuitManager.Connecting == true)
            {
                circuitManager.ConnectElectro = Electro;
            }

           
        }
    }

 

    public override void OnArround(bool b)
    {
        try
        {
            Around.SetActive(b);
            if(b==true)
            {
                ledmanager.DigitalConnect = false;
                ledmanager.Pause();
            }
            //=================================================
            //else if (ledmanager.MouseClick == true)
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

   /*Enumerator LineMove()
    {
        LineObject.transform.position = Around.transform.position;
        yield return null;
    }*/

}
