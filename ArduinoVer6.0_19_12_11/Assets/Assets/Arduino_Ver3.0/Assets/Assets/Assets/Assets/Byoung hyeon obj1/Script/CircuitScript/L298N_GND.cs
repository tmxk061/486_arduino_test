using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L298N_GND : MonoBehaviour
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
     
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Line")
        {
            Line = other.gameObject.GetComponentInParent<LineManager>();
          

            OnArround(false);
           // Debug.Log(other.tag);
           
            if (Line.parent != null)
            {
             //   Debug.Log(Line.parent.tag);
                if (Line.parent.tag == "GND")
                {
                    Connect = true;
                    manager.GNDConnect = true;
                }
            }
            else if(Line.parent==null)
            {
                manager.GNDConnect = false;
            }
           

        }
      
    }

    public void OnArround(bool b)
    {
        try
        {
            manager.GNDConnect = false;
            Connect = false;
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
