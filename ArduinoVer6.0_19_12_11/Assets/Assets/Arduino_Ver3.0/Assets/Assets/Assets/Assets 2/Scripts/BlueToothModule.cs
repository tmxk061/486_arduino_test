using UnityEngine;

public class BlueToothModule : MonoBehaviour
{
    public GameObject LED;
  

    public bool VCCConnect = false;
    public bool GNDConnect = false;
    public bool TXDConnect = false;
    public bool RXDConnect = false;


    // Start is called before the first frame update
    void Start()
    {

    }

  

    public void Run(float s)
    {
        if(VCCConnect && GNDConnect && TXDConnect && RXDConnect)
            LED.GetComponent<MeshRenderer>().material.color = Color.red;
    
    }

    public void Pause()
    {
        
            LED.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
