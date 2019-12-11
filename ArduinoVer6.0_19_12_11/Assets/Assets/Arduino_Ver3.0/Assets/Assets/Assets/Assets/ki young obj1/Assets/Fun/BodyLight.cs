using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyLight : MonoBehaviour
{
   
    LightScript parentmesh;
    [SerializeField]
    private Material TurnOnM=null;
    [SerializeField]
    private Material TurnOffM=null;
    // Start is called before the first frame update
    void Start()
    {
       
        parentmesh = GetComponentInParent<LightScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(parentmesh.CheckRun)
        {
            this.GetComponent<MeshRenderer>().material = TurnOnM;
        
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = TurnOffM;
           

        }


        /*Material mymat = GetComponent<Renderer>().material;
        if (Input.GetButton("Fire1"))
        {
            mymat.DisableKeyword("_EMISSION");
        }
        if (Input.GetButton("Fire2"))
        {
            mymat.EnableKeyword("_EMISSION");
            mymat.SetColor("_EmissionColor", Color.red);
        }
        */
    }
}
