using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L298N_MANAGER : MonoBehaviour
{

    public bool VccConnect { get; set; }
    public bool GNDConnect { get; set; }
    public bool DigitalConnect1 { get; set; }
    public bool DigitalConnect2 { get; set; }
    public bool DigitalConnect3 { get; set; }
    public bool DigitalConnect4 { get; set; }
    public int POWER { get; set; }

    public List<L298NOUT4> outlist;

    // Start is called before the first frame update
    void Start()
    {
        
        outlist.Add(transform.Find("OUT1").GetComponent<L298NOUT4>());
        outlist.Add(transform.Find("OUT2").GetComponent<L298NOUT4>());
        outlist.Add(transform.Find("OUT3").GetComponent<L298NOUT4>());
        outlist.Add(transform.Find("OUT4").GetComponent<L298NOUT4>());


        VccConnect = false;
        GNDConnect = false;
        DigitalConnect1 = false;
        DigitalConnect2 = false;
        DigitalConnect3 = false;
        DigitalConnect4 = false;
        POWER = 0;


    }

  


}
