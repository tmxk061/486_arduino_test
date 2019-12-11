using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPlus : PlusMinus
{
    public bool Connect=false;
    public GameObject Around;
    public int VccPower = 0;
    public LineManager Line;

    public ServoManager sub;

    bool LineCheck = false;
    Transform LineObject;

    // Start is called before the first frame update
    void Start()
    {
        sub = GetComponentInParent<ServoManager>();

        OnArround(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (LineObject == isActiveAndEnabled)
        {
            if (LineCheck == true && sub.MouseClick == true)
            {
                LineObject.GetComponent<BoxCollider>().enabled = false;
                LineObject.transform.position = this.Around.transform.position;
                //StartCoroutine(LineMove());
            }
            else if (LineCheck == true && sub.MouseClick == false)
            {
                LineObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Line" )
        {
            Connect = true;
            Line = other.gameObject.GetComponentInParent<LineManager>();
            LineObject = other.gameObject.GetComponent<Transform>();
            LineCheck = true;

            OnArround(false);

            if (Line.parent != null)
            {
                if (Line.parent.tag == "VCC")
                {

                    if (sub != null)
                        sub.VccConnect = true;

                    //  sub.GetComponentInChildren<SubSpin>().Run(3);


                }
                else if(Line.parent.tag=="BreadPlus")
                {
                    sub.VccConnect = true;
                }
                
            }



        }


    }

    private void OnTriggerExit(Collider other)
    {
        Line = other.gameObject.GetComponentInParent<LineManager>();
        OnArround(true);
        Line = null;
    }

    public override void OnArround(bool b)
    {
        try
        {
            if (b == true)
            { sub.VccConnect = false; }
            Around.SetActive(b);

                        //=================================================
            //if (sub.MouseClick == true)
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
