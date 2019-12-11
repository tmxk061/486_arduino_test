using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    //public GameObject LEDLight;

    private Light[] lightlist = null;
    public bool CheckRun = false;
   
    // Start is called before the first frame update

 
    void Start()
    {
        lightlist = GetComponentsInChildren<Light>();
       
        
    }

    // Update is called once per frame
   
    public void Run()
    {
        foreach (Light l in lightlist)
        {
            l.enabled = true;
            

        }
        CheckRun = true;
        
      
    }

    public void Pause()
    {
        foreach (Light l in lightlist)
        {
            l.enabled = false;
        }
        CheckRun = false;
        
    }
}

