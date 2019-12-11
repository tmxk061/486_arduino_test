using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltSig : PlusMinus
{
    public float VccPower = 0;
    public float Data;
    public bool Connect = false;

    public GameObject Around;
    public LineManager Line;

    UltValue ultmanager;
    bool LineCheck = false;
    Transform LineObject;

    // Start is called before the first frame update
    void Start()
    {
        ultmanager = GetComponentInParent<UltValue>();
        Data = 0;
        OnArround(true);
    }

    void Update()
    {
        if (ultmanager != null)
            Data = ultmanager.closeDistance;

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

                if (Line.parent.tag == "DIGITAL")
                {

                    
                    ultmanager.DigitalConnect = true;


                }
                else if (Line.parent.tag == "BreadDIGITAL")
                {

                    ultmanager.DigitalConnect = true;

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
            ultmanager.DigitalConnect = false;

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
