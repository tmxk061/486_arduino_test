using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resist:MonoBehaviour
{
    // Start is called before the first frame update
    public bool Connect1 = false;
    public bool Connect2 = false;
    public bool VccConnect = false;
    public bool GNDConnect = false;
    public int Power = 0;
    public GameObject LineParent;

    public delegate void RunServo(float s);
    public RunServo servorun;
    public delegate void Run();
    public Run run;
    public PlusGroup plusgroup;

    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
