using System;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    static public float? distance = 0f;
    static public float? temp = 0f;
    static public float? humi = 0f;
    static public float? lux = 0f;
    static public Vector3 canvasposition;
    static public Vector3 FirstMainCameraPosition;
    static public bool PcOn = false;
    static public bool RunBlock = false;
    static public Quaternion FirstMainCameraRotation;

    static public TextMesh temptext = GameObject.Find("TempValue").GetComponent<TextMesh>();

    static public List<string> ArduinoPortList = new List<string>();

    static public TextMesh humitext = GameObject.Find("HumiValue").GetComponent<TextMesh>();
    static public TextMesh distancetext = GameObject.Find("DistanceValue").GetComponent<TextMesh>();
    static public TextMesh Luxtext = GameObject.Find("LuxValue").GetComponent<TextMesh>();

    public enum SensorType { Servo, Led, DC, Sound, Bread, Ult, Lux, HumiTemp, l298n, normal };

    private static string codeM = null;

    static public RunButton runbtn = GameObject.Find("RunButton").GetComponent<RunButton>();
    static public ConnectArduino connectArduino = GameObject.Find("CodePaste").GetComponent<ConnectArduino>();
    static public PauseButton pausebtn = GameObject.Find("PauseButton").GetComponent<PauseButton>();
    static public SyncRunButton syncrunbutton = GameObject.Find("SyncRun").GetComponent<SyncRunButton>();
    static public SyncCodeButton syncCodebutton = GameObject.Find("SyncCode").GetComponent<SyncCodeButton>();

    //코드 추출에 필요한 것======================
    //
    //
    //
    //=================================================
    static public List<string> header = new List<string>();

    static public List<string> valuelist = new List<string>();
    static public List<string> setup = new List<string>();
    static public List<string> loop = new List<string>();

    private static SerialPort ArduinoPort = new SerialPort("COM5", 9600);
    private static string PortNo = "";
    private static int BaudNo = 0;
    static public bool AgainSyncRun = false;

    private void Awake()
    {
        instance = this;

        ArduinoPort.ReadTimeout = 1000;
        ArduinoPort.WriteTimeout = 1000;
    }

    static public void AddloopList(string s)
    {
        bool check = false;

        for (int i = 0; i < loop.Count; i++)
        {
            if (loop[i] == s) check = true;
        }

        if (check == false)
        {
            loop.Add(s);
        }
    }

    static public void SetHumitext(string _text)
    {
        humitext.text = _text;
    }

    static public void SetTemptext(string _text)
    {
        temptext.text = _text;
    }

    static public void Setdistancetext(string _text)
    {
        distancetext.text = _text;
    }

    static public void setLuxtext(string _text)
    {
        Luxtext.text = _text;
    }

    static public void RunbtnWork()
    {
        runbtn.Work();
    }

    static public void AddHeader(string s)
    {
        bool check = false;
        for (int i = 0; i < header.Count; i++)
        {
            if (header[i] == s) check = true;
        }

        if (check == false)
        {
            header.Add(s);
        }
    }

    static public void AddValueLis(string s)
    {
        bool check = false;
        for (int i = 0; i < valuelist.Count; i++)
        {
            if (valuelist[i] == s) check = true;
        }

        if (check == false)
        {
            valuelist.Add(s);
        }
    }

    static public void Addsetup(string s)
    {
        bool check = false;
        for (int i = 0; i < setup.Count; i++)
        {
            if (setup[i] == s) check = true;
        }

        if (check == false)
        {
            setup.Add(s);
        }
    }

    static public void MergeCode()
    {
        for (int i = 0; i < header.Count; i++)
        {
            codeM += header[i] + "\n";
        }

        for (int i = 0; i < valuelist.Count; i++)
        {
            codeM += valuelist[i] + "\n";
        }

        codeM += "void setup(){\n";

        for (int j = 0; j < setup.Count; j++)
        {
            codeM += setup[j] + "\n";
        }

        codeM += "}\n";

        codeM += "void loop(){" + "\n";

        for (int z = 0; z < loop.Count; z++)
        {
            codeM += loop[z] + "\n";
        }

        codeM += "}\n";

        GUIUtility.systemCopyBuffer = codeM;

        for (int i = 0; i < valuelist.Count; i++)
        {
            valuelist.RemoveAt(i);
        }

        for (int i = 0; i < setup.Count; i++)
        {
            setup.RemoveAt(i);
        }

        for (int i = 0; i < loop.Count; i++)
        {
            loop.RemoveAt(i);
        }

        for (int i = 0; i < header.Count; i++)
        {
            header.RemoveAt(i);
        }

        codeM = null;
    }

    static public void syncBTMergeCode()
    {
        Addsetup("Serial.begin(9600);");
        AddHeader("#include <SoftwareSerial.h>");
        AddHeader("SoftwareSerial btSerial(2,3);");
        Addsetup("btSerial.begin(9600);");
        for (int i = 0; i < header.Count; i++)
        {
            codeM += header[i] + "\n";
        }

        for (int i = 0; i < valuelist.Count; i++)
        {
            codeM += valuelist[i] + "\n";
        }

        codeM += "void setup(){\n";

        for (int j = 0; j < setup.Count; j++)
        {
            codeM += setup[j] + "\n";
        }

        codeM += "}\n";

        codeM += "void loop(){" + "\n";

        codeM += "String sync=btSerial.readString();\n";

        for (int z = 0; z < loop.Count; z++)
        {
            codeM += loop[z] + "\n";
        }

        codeM += "}\n";

        GUIUtility.systemCopyBuffer = codeM;

        for (int i = 0; i < valuelist.Count; i++)
        {
            valuelist.RemoveAt(i);
        }

        for (int i = 0; i < setup.Count; i++)
        {
            setup.RemoveAt(i);
        }

        for (int i = 0; i < loop.Count; i++)
        {
            loop.RemoveAt(i);
        }

        for (int i = 0; i < header.Count; i++)
        {
            header.RemoveAt(i);
        }

        codeM = null;
    }

    static public void syncMergeCode()
    {
        //  AddValueLis("String sync;");
        Addsetup("Serial.begin(9600);");

        for (int i = 0; i < header.Count; i++)
        {
            codeM += header[i] + "\n";
        }

        for (int i = 0; i < valuelist.Count; i++)
        {
            codeM += valuelist[i] + "\n";
        }

        codeM += "void setup(){\n";

        for (int j = 0; j < setup.Count; j++)
        {
            codeM += setup[j] + "\n";
        }

        codeM += "}\n";

        codeM += "void loop(){" + "\n";

        codeM += "String sync=Serial.readString();\n";

        for (int z = 0; z < loop.Count; z++)
        {
            codeM += loop[z] + "\n";
        }

        codeM += "}\n";

        GUIUtility.systemCopyBuffer = codeM;

        for (int i = 0; i < valuelist.Count; i++)
        {
            valuelist.RemoveAt(i);
        }

        for (int i = 0; i < setup.Count; i++)
        {
            setup.RemoveAt(i);
        }

        for (int i = 0; i < loop.Count; i++)
        {
            loop.RemoveAt(i);
        }

        for (int i = 0; i < header.Count; i++)
        {
            header.RemoveAt(i);
        }

        codeM = null;
    }

    static public void ReadArduinoValue()
    {
        string s = ArduinoPort.ReadLine();
        if (s != null) Setdistancetext(s);
        else if (s == null) Debug.Log("없다");
    }

    static public void ReadLuxArduinoValue()
    {
        string s = ArduinoPort.ReadLine();
        if (s != null) setLuxtext(s);
        else if (s == null) Debug.Log("없다");
    }

    static public void GetPort()
    {
        for (int i = 0; i < ArduinoPortList.Count; i++)
        {
            ArduinoPortList.RemoveAt(i);
        }

        foreach (string comport in SerialPort.GetPortNames())
        {
            ArduinoPortList.Add(comport);
        }

        if (ArduinoPortList[0] != null)
        {
            ArduinoPort = new SerialPort(ArduinoPortList[0], 9600);
        }
    }

    static public void closeArduino()
    {
        if (ArduinoPort.IsOpen == true)
        {
            ArduinoPort.Close();
        }
    }

    static public void openArduino()
    {
        try
        {
            ArduinoPort.Open();
        }
        catch (Exception)
        {
            syncrunbutton.blockgroupException();
        }
    }

    static public void DigitalWrite(string num)
    {
        ArduinoPort.Write(num);

        // GameManager.closeArduino();
    }

    static public void SyncPause()
    {
        AgainSyncRun = false;
        syncrunbutton.blockgrouppause();
    }

    static public void SyncRun()
    {
        if (AgainSyncRun == true)
        { syncrunbutton.blockgrouprun(); }
    }
}