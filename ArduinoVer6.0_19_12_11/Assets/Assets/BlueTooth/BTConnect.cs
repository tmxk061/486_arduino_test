using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class BTConnect : MonoBehaviour
{
    int trynum = 0;
    public enum PortNumber
    {
        COM1, COM2, COM3, COM4,
        COM5, COM6, COM7, COM8,
        COM9, COM10, COM11, COM12,
        COM13, COM14, COM15, COM16
    }

    // 연결된 포트, baud rate(통신속도)
    private SerialPort serial;

    [SerializeField]
    private PortNumber portNumber = PortNumber.COM4;        // 포트 넘버
    [SerializeField]
    private string baudRate = "9600";
    // Start is called before the first frame update
    

    public void BtnConnect()
    {
        serial = new SerialPort("COM4", int.Parse(baudRate));
        Debug.Log(serial.ToString());
        serial.ReadTimeout = 20000;
        serial.WriteTimeout = 20000;
        serial.DtrEnable = true;
        //  serial.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
        

        if (!serial.IsOpen)
            serial.Open();
    }

    public void BtnDisConnect()
    {
        if (serial.IsOpen) serial.Close();
    }

    private void OnMouseDown()
    {
        BtnConnect();
    }

    public void BtnSendData(string text)
    {
       /// if(serial.IsOpen)
        serial.Write(text);
    }
}
