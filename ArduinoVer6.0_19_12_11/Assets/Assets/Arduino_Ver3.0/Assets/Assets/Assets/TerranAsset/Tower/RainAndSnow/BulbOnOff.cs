using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbOnOff : MonoBehaviour
{
    new Light light;
    public UnityEngine.UI.Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        light = this.gameObject.GetComponent<Light>();
    }

    public void Update()
    {
        if(toggle.isOn == true)
        {
            light.enabled = true; 
        }
        else
        {
            light.enabled = false;
        }
    }
}
