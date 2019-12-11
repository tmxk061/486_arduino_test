using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArduino : MonoBehaviour
{
    public List<Socket> PinList = new List<Socket>();
    private Socket Pin0;
    private Socket Pin1;
    private Socket Pin2;
    private Socket Pin3;
    private Socket Pin4;
    private Socket Pin5;
    private Socket Pin6;
    private Socket Pin7;
    private Socket Pin8;
    private Socket Pin9;
    private Socket Pin10;
    private Socket Pin11;
    private Socket Pin12;
    private Socket Pin13;
    private Socket PinA0;
    private Socket PinA1;
    private Socket PinA2;
    private Socket PinA3;
    private Socket PinA4;
    private Socket PinA5;
    private TurnOnArduino light1;
    private TurnOnArduino light2;
    // Start is called before the first frame update
    void Start()
    {
        Pin0 = transform.GetChild(0).GetComponent<Socket>();
        Pin1 = transform.GetChild(1).GetComponent<Socket>();
        Pin2 = transform.GetChild(2).GetComponent<Socket>();
        Pin3 = transform.GetChild(3).GetComponent<Socket>();
        Pin4 = transform.GetChild(4).GetComponent<Socket>();
        Pin5 = transform.GetChild(5).GetComponent<Socket>();
        Pin6 = transform.GetChild(6).GetComponent<Socket>();
        Pin7 = transform.GetChild(7).GetComponent<Socket>();
        Pin8 = transform.GetChild(8).GetComponent<Socket>();
        Pin9 = transform.GetChild(9).GetComponent<Socket>();
        Pin10 = transform.GetChild(10).GetComponent<Socket>();
        Pin11 = transform.GetChild(11).GetComponent<Socket>();
        Pin12 = transform.GetChild(12).GetComponent<Socket>();
        Pin13 = transform.GetChild(13).GetComponent<Socket>();
        PinA0 = transform.GetChild(23).GetComponent<Socket>();
        PinA1 = transform.GetChild(22).GetComponent<Socket>();
        PinA2 = transform.GetChild(21).GetComponent<Socket>();
        PinA3 = transform.GetChild(20).GetComponent<Socket>();
        PinA4 = transform.GetChild(19).GetComponent<Socket>();
        PinA5 = transform.GetChild(18).GetComponent<Socket>();

        PinList.Add(Pin0);
        PinList.Add(Pin1);
        PinList.Add(Pin2);
        PinList.Add(Pin3);
        PinList.Add(Pin4);
        PinList.Add(Pin5);
        PinList.Add(Pin6);
        PinList.Add(Pin7);
        PinList.Add(Pin8);
        PinList.Add(Pin9);
        PinList.Add(Pin10);
        PinList.Add(Pin11);
        PinList.Add(Pin12);
        PinList.Add(Pin13);
        PinList.Add(PinA0);
        PinList.Add(PinA1);
        PinList.Add(PinA2);
        PinList.Add(PinA3);
        PinList.Add(PinA4);
        PinList.Add(PinA5);
        


        light1 = GameObject.FindWithTag("arduinolight1").GetComponent<TurnOnArduino>();
        light2 = GameObject.FindWithTag("arduinolight2").GetComponent<TurnOnArduino>();

    }

    // Update is called once per frame
    public void PauseAll()
    {

        foreach(Socket s in PinList)
        {
            s.SocketPause();

        }
    }
}
