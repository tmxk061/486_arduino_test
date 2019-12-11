using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllGND : PlusMinus
{
    public int VccPower = 0;
    public float Electro;

    public GameObject Around;
    //public LineManager Line;
    LineManager Line;
    lightSensor illvalue;
    bool LineCheck = false;
    Transform LineObject;

    // Start is called before the first frame update
    void Start()
    {
        illvalue = GetComponentInParent<lightSensor>();
        OnArround(true);
    }

    void Update()
    {
        if (LineObject == isActiveAndEnabled)
        {
            if (LineCheck == true && illvalue.MouseClick == true)
            {
                LineObject.GetComponent<BoxCollider>().enabled = false;
                LineObject.transform.position = this.Around.transform.position;
                //StartCoroutine(LineMove());
            }
            else if (LineCheck == true && illvalue.MouseClick == false)
            {
                LineObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Line")
        {
            OnArround(false);
            Line = other.gameObject.GetComponentInParent<LineManager>();
            LineObject = other.gameObject.GetComponent<Transform>();
            LineCheck = true;

            if (Line.parent != null)
            {

                if (Line.parent.tag == "GND")
                {


                    illvalue.value.GNDConnect = true;


                }
                else if (Line.parent.tag == "BreadGND")
                {

                    illvalue.value.GNDConnect = true;

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
            Around.SetActive(b);

            if (b == true)
            { illvalue.value.GNDConnect = false; }
            //=================================================
            //else if (illvalue.MouseClick == true)
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
