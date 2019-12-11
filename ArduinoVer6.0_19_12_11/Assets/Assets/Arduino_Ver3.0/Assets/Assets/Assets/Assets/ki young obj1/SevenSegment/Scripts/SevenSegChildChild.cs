using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenSegChildChild : MonoBehaviour
{
    public bool Connect;
    public float Electro;
    public int signal;


    public GameObject Around;
    public LineManager Line;
    SevenSegChild sevensegparent;

    // Start is called before the first frame update
    void Start()
    {
        sevensegparent = gameObject.GetComponentInParent<SevenSegChild>();
        Connect = false;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Line")
        {
            OnArround(false);
            Connect = true;
            Line = other.gameObject.GetComponentInParent<LineManager>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(Connect == true)
            Run();
    }

    void Run()
    {
        if (Line.DigitalConnect == true)
        {
            sevensegparent.DigitalConnect = true;
        }

    }

    public void OnArround(bool b)
    {
        try
        {
            Around.SetActive(b);
            if(Connect == true)
            {
                sevensegparent.DigitalConnect = false;
                Connect = false;
            }
        }
        catch (Exception)
        {
            Connect = false;
            Func(delegate () { return true; });
        }
    }

    void Func(Func<bool> callback)
    {
        callback();
    }


}
