using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    Socket socket;

    private void Start()
    {
        socket = GetComponent<Socket>();
    }

    // Update is called once per frame
    void Update()
    {
        if (socket.Connect == true && socket.circuitManager.ConnectElectro >= 3.0f)
        {
                this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(socket.Connect == false || socket.circuitManager.ConnectElectro <= 2.0f)
        {
                this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }


    }

}
