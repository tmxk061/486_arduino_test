using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExam : MonoBehaviour
{
    bool re = true;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (re)
        {
            this.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime*20);
            if (this.transform.position.z > 100) re = false;

        }
        else
        {
            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime*20);
            if (this.transform.position.z < 60) re = true;
        }

    }
}
