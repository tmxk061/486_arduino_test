using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L298N_VCC5v : MonoBehaviour
{

    L298N_MANAGER manager;
    public bool Connect = false;
    public GameObject Around;
    public LineManager Line;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<L298N_MANAGER>();
        OnArround(true);
    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerStay(Collider other)
    {


        if (other.tag == "Line")
        {
            Line = other.gameObject.GetComponentInParent<LineManager>();

           OnArround(false);

            if (Line.parent != null)
            {
                if (Line.parent.tag == "VCC")
                {
                    manager.VccConnect = true;

                    if (Connect == false)
                    {
                        if (Line.parent.name == "3V")
                        { manager.POWER += 3; }
                        else if (Line.parent.name == "5V")
                        { manager.POWER += 5; }

                        Connect = true;
                    }

                }
            }
            else if (Line.parent == null)
            {
                manager.GNDConnect = false;
                Connect = false;
            }


        }

    }




    public void OnArround(bool b)
    {
        try
        {
            manager.VccConnect = false;
            Around.SetActive(b);
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
