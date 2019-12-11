using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGND : PlusMinus
{
    public float Electro;

    public GameObject Around;
    public LineManager Line;

    SoundParent soundparaent;
    bool LineCheck = false;
    Transform LineObject;

    // Start is called before the first frame update
    void Start()
    {
        OnArround(true);

        soundparaent = GetComponentInParent<SoundParent>();
    }

    void Update()
    {
        if (LineObject == isActiveAndEnabled)
        {
            if (LineCheck == true && soundparaent.MouseClick == true)
            {
                LineObject.GetComponent<BoxCollider>().enabled = false;
                LineObject.transform.position = this.Around.transform.position;
                //StartCoroutine(LineMove());
            }
            else if (LineCheck == true && soundparaent.MouseClick == false)
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


                    soundparaent.GNDConnect = true;


                }
                else if (Line.parent.tag == "BreadGND")
                {

                    soundparaent.GNDConnect = true;

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
            soundparaent.GNDConnect = false;
            Around.SetActive(b);

            //=================================================
            //if (soundparaent.MouseClick == true)
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
