using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHumiDigital : PlusMinus
{
    public float VccPower { get; set; }
    public float Data { get; set; }

    public GameObject Around;
    //public LineManager Line;

    TempHumiParent temphumiparent;
    public LineManager Line;
    bool LineCheck = false;
    Transform LineObject;

    // Start is called before the first frame update
    void Start()
    {
        temphumiparent = GetComponentInParent<TempHumiParent>();
        Data = 0;
    }
    void Update()
    {
        if (LineObject == isActiveAndEnabled)
        {
            if (LineCheck == true && temphumiparent.MouseClick == true)
            {
                LineObject.GetComponent<BoxCollider>().enabled = false;
                LineObject.transform.position = this.Around.transform.position;
                //StartCoroutine(LineMove());
            }
            else if (LineCheck == true && temphumiparent.MouseClick == false)
            {
                LineObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    // Update is called once per frame


    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Line")
    //    {
    //        OnArround(false);
    //        //Line = other.GetComponentInParent<LineManager>();
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Line" )
        {

            OnArround(false);
            Line = other.gameObject.GetComponentInParent<LineManager>();
            LineObject = other.gameObject.GetComponent<Transform>();
            LineCheck = true;

            if (Line.parent != null)
            {

                if (Line.parent.tag == "DIGITAL")
                {


                    temphumiparent.DigitalConnect = true;


                }
                else if (Line.parent.tag == "BreadDIGITAL")
                {

                    temphumiparent.DigitalConnect = true;

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

    public override void OnArround(bool b)
    {
        try
        {
            if (b == true)
            { 
                temphumiparent.DigitalConnect = false;
            }
            Around.SetActive(b);

            //=================================================
            //if (temphumiparent.MouseClick == true)
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
