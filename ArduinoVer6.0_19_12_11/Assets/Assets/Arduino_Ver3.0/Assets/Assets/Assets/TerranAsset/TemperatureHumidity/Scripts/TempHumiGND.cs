using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHumiGND : PlusMinus
{
    public float Electro;

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
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Line")
    //    {
    //        OnArround(false);
    //       // Line = other.GetComponentInParent<LineManager>();
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

                if (Line.parent.tag == "GND")
                {


                    temphumiparent.GNDConnect = true;


                }
                else if (Line.parent.tag == "BreadGND")
                {

                    temphumiparent.GNDConnect = true;

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
            { temphumiparent.GNDConnect = false; }
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
