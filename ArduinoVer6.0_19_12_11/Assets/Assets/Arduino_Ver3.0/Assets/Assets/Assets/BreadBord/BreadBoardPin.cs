using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadBoardPin : PlusMinus
{
    public bool VccConnect;
    public bool GNDConnect;
    public bool DigitalConnect;

    public GameObject Around;
    public LineManager Line;
    public PlusGroup group;
    public List<LineManager> managerlist = new List<LineManager>();
    public delegate void RunCollect(float s);
    public RunCollect pinruncollect;
    public delegate void PauseCollect();
    public PauseCollect pinpausecollect;
    
    // Start is called before the first frame update
    void Start()
    {
        OnArround(true);
        group = GetComponentInParent<PlusGroup>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        //if (other.tag == "Line")
        //{

        //    OnArround(false);
        //    Line = other.gameObject.GetComponentInParent<LineManager>();



        //    if (Line.parent != null)
        //    {

        //        if (Line.parent.tag == "VCC" || Line.parent.tag == "BreadPlus")
        //        {
        //            if (this.tag != "BreadGND" && this.tag != "BreadDIGITAL")
        //            {
        //                group.tag = "BreadPlus";
        //                this.tag = "BreadPlus";

        //                group.SetVcc(true);
        //            }

        //        }
        //        else if (Line.parent.tag == "GND" || Line.parent.tag == "BreadGND")
        //        {
        //            if (this.tag != "BreadPlus" && this.tag!= "BreadDIGITAL")
        //            {
        //                group.tag = "BreadGND";
        //                this.tag = "BreadGND";

        //                group.SetGND(true);
        //            }

        //        }
        //        else if(Line.parent.tag=="DIGITAL"||Line.parent.tag== "BreadDIGITAL")
        //        {
        //            if (this.tag != "BreadPlus" && this.tag != "BreadGND")
        //            {
        //                group.tag = "BreadDIGITAL";
        //                this.tag = "BreadDIGITAL";
        //                group.SetDigital(true);
        //            }
        //        }


        //        if(Line.parent.tag!="VCC"&& Line.parent.tag != "GND" && Line.parent.tag != "DIGITAL" )
        //        {
        //            pinruncollect = new RunCollect(Line.RunCollect);
        //            pinpausecollect = new PauseCollect(Line.PauseCollect);
        //        }

        //    }


        //}


        StartCoroutine(Work(other));

    }
    private IEnumerator Work(Collider other)
    {
        if (other.tag == "Line")
        {

            OnArround(false);
            Line = other.gameObject.GetComponentInParent<LineManager>();



            if (Line.parent != null)
            {

                if (Line.parent.tag == "VCC" || Line.parent.tag == "BreadPlus")
                {
                    if (this.tag != "BreadGND" && this.tag != "BreadDIGITAL")
                    {
                        group.tag = "BreadPlus";
                        this.tag = "BreadPlus";

                        group.SetVcc(true);
                    }

                }
                else if (Line.parent.tag == "GND" || Line.parent.tag == "BreadGND")
                {
                    if (this.tag != "BreadPlus" && this.tag != "BreadDIGITAL")
                    {
                        group.tag = "BreadGND";
                        this.tag = "BreadGND";

                        group.SetGND(true);
                    }

                }
                else if (Line.parent.tag == "DIGITAL" || Line.parent.tag == "BreadDIGITAL")
                {
                    if (this.tag != "BreadPlus" && this.tag != "BreadGND")
                    {
                        group.tag = "BreadDIGITAL";
                        this.tag = "BreadDIGITAL";
                        group.SetDigital(true);
                    }
                }


                if (Line.parent.tag != "VCC" && Line.parent.tag != "GND" && Line.parent.tag != "DIGITAL")
                {
                    pinruncollect = new RunCollect(Line.RunCollect);
                    pinpausecollect = new PauseCollect(Line.PauseCollect);
                }

            }


        }



        yield return new WaitForSeconds(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(group!=null)
        {
           
            this.tag = group.tag;
        }
       
    }
    public override void OnArround(bool b)
    {
        try
        {
            
            Around.SetActive(b);
          
            if (b == true)
            {
                pinruncollect = null;
                this.tag = "BreadPin";
                if (this.tag == "BreadPlus")
                {
                    group.SetVcc(false);
                }
                else if(this.tag== "BreadGND")
                {
                    group.SetGND(false);
                }
                else if(this.tag== "BreadDIGITAL")
                {
                    group.SetDigital(false);
                }

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
