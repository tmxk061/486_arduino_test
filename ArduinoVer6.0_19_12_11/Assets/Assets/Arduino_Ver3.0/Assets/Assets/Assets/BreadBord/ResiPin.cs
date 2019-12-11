using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResiPin : PlusMinus
{
    public GameObject Around;
    public Resist resi;
    public LineManager Line;
   



    // Start is called before the first frame update
    void Start()
    {
        resi = this.gameObject.GetComponentInParent<Resist>();
    }

   

    private void OnTriggerStay(Collider other)
    {

        if(other.tag=="Line")
        {
            Line = other.gameObject.GetComponentInParent<LineManager>();

            if (Line.parent != null)
            {
               
                if (Line.parent.tag == "VCC")
                {
                    resi.VccConnect = true;
                    resi.Power = Line.Power - 3;
                    resi.LineParent = Line.parent;
                }
                else if (Line.parent.tag != "GND")
                {
                    if (Line.run != null)
                    {
                        resi.run = new Resist.Run(Line.run);
                    }


                    if (Line.servorun != null)
                    {
                        resi.servorun = new Resist.RunServo(Line.servorun);
                    }


                    if (Line.plusGroup != null)
                    {

                        resi.plusgroup = Line.plusGroup;
                    }
                }

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

            }
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
