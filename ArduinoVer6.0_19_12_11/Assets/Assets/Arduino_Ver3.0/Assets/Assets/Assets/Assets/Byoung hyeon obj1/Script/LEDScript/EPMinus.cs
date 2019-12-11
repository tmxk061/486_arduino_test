using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPMinus : PlusMinus
{
    public bool Connect = false;
    public float Electro;

    public GameObject Around;
    public CircuitManager circuitManager;
    public LineManager Line;
    Transform LineObject;

    LEDManager ledmanager;

    bool LineCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        ledmanager = GetComponentInParent<LEDManager>();
        OnArround(true);
    }

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
        if(other.tag == "Line")
        {
            LineCheck = true;
            Connect = true;
            OnArround(false);
            LineObject = other.gameObject.GetComponent<Transform>();
            Line = other.gameObject.GetComponentInParent<LineManager>();

            if (Line.parent != null)
            {

                if (Line.parent.tag == "GND")
                {

                    ledmanager.GNDConnect = true;


                }
                else if (Line.parent.tag == "BreadGND")
                {

                    ledmanager.GNDConnect = true;


                }
                //else if (LineCheck == true)
                //{
                //    OnArround(true);
                //    Connect = false;
                //}


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
                ledmanager.GNDConnect = false;
                ledmanager.Pause();
            }
            //=================================================
            //else if (ledmanager.MouseClick == true)
            //{
            //    LineObject.transform.position = this.Around.transform.position;
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

    //IEnumerator LineMove()
    //{
    //    LineObject.transform.position = Around.transform.position;
    //    yield return null;
    //}
}
