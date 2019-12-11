using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnalogRead : Block, IDragHandler
{
    #region 변수

    //[SerializeField]
    //public Canvas canvas;
    //[SerializeField]
    //public Camera secondCamera;

    private GameObject UpObj = null;
    private GameObject DownObj;
    private Collider2D[] colliders;
    private Collider2D UpCollider;
    private Collider2D DownCollider;
    private ControlArduino arduino;
    public int selectnum = 0;
    public Socket selectSecket;

    public bool selectRun = true;
    public bool UpConncet = false;
    public bool DownConnect = false;

    public bool GetChild = false;

    private Block sample;

    [SerializeField]
    private GameObject parentobj;

    #endregion 변수

    private void Start()
    {
        arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();
        parentobj = GameObject.Find("PanelBlockCoding").gameObject.transform.Find("CodingPanel").gameObject.transform.Find("CodingMaskPanel").gameObject;
        colliders = this.GetComponents<Collider2D>();

        this.transform.position = new Vector3(930, 421);

        if (colliders != null)
        {
            DownCollider = colliders[0];

            UpCollider = colliders[1];
        }
        selectSecket = arduino.PinList[0];
    }

    #region 필수 구현 부분

    public override IEnumerator Run(float s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        GetChild = false;
        if (selectSecket != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket.SocketType)
                {
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:

                        float? value = selectSecket.floatSocketRun();
                        float value3 = float.Parse(value.ToString());

                        GameManager.Setdistancetext("핀" + selectnum + " : " + Mathf.RoundToInt(value3) + "cm");
                        GameManager.distance = value;

                        break;

                    case GameManager.SensorType.HumiTemp:

                        List<float> temphumilist = new List<float>();

                        temphumilist = selectSecket.listSocketRun();

                        GameManager.temp = temphumilist[1];
                        GameManager.humi = temphumilist[0];

                        float value1 = float.Parse(GameManager.temp.ToString());
                        float value2 = float.Parse(GameManager.humi.ToString());
                        GameManager.SetTemptext("핀" + selectnum + " : " + Mathf.RoundToInt(value1));
                        GameManager.SetHumitext("핀" + selectnum + " : " + Mathf.RoundToInt(value2));
                        break;

                    case GameManager.SensorType.Lux:

                        float? valuelux = selectSecket.floatSocketRun();

                        GameManager.setLuxtext("핀" + selectnum + " : " + valuelux);
                        GameManager.lux = valuelux;

                        break;

                        //  selectSecket.SocketRun(0);
                }
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        Block block = null;
        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.Run(0));
                    GetChild = true;
                    break;
            }
        }

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        if (GetChild == false && s == 0)
        {
            GameManager.RunbtnWork();
        }
    }

    public override IEnumerator SyncRun(bool s)
    {
        Block block = null;

        if (selectnum == 14)
        {
            GameManager.DigitalWrite("A0");
        }
        else if (selectnum == 15)
        {
            GameManager.DigitalWrite("A1");
        }
        else if (selectnum == 16)
        {
            GameManager.DigitalWrite("A2");
        }
        else if (selectnum == 17)
        {
            GameManager.DigitalWrite("A3");
        }
        else if (selectnum == 18)
        {
            GameManager.DigitalWrite("A4");
        }
        else if (selectnum == 19)
        {
            GameManager.DigitalWrite("A5");
        }
        else
        {
            GameManager.DigitalWrite(selectnum.ToString());
        }

        yield return new WaitForSecondsRealtime(1f);

        GameManager.ReadLuxArduinoValue();

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.SyncRun(s));
                    GetChild = true;
                    break;
            }
        }

        if (GetChild == false)
        {
            GameManager.closeArduino();
            GameManager.SyncRun();
        }
    }

    public override IEnumerator GetCode(bool s)
    {
        GetChild = false;
        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:

                    break;

                case GameManager.SensorType.HumiTemp:
                    HumiTemp();
                    break;

                case GameManager.SensorType.Lux:
                    LuxCode();
                    break;
            }
        }

        Block block = null;

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetCode(s));
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.MergeCode();
        }
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;
        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                // 값을 읽어 들이는 센서

                case GameManager.SensorType.HumiTemp:
                    syncHumiTemp();
                    break;

                case GameManager.SensorType.Lux:
                    syncLuxCode();
                    break;
            }
        }

        Block block = null;

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.syncMergeCode();
        }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;
        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                // 값을 읽어 들이는 센서

                case GameManager.SensorType.HumiTemp:
                    syncBTHumiTemp();
                    break;

                case GameManager.SensorType.Lux:
                    syncBTLuxCode();
                    break;
            }
        }

        Block block = null;

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.syncBTMergeCode();
        }
    }

    public override void SetDownColllider(bool s)
    {
        if (DownCollider != null)
        {
            DownCollider.isTrigger = s;
        }
    }

    public override void SetUPColllider(bool s)
    {
        if (UpCollider != null)
        {
            UpCollider.isTrigger = s;
        }
    }

    public override bool CheckUoCollider()
    {
        return UpCollider.isTrigger;
    }

    public override bool CheckDownCollider()
    {
        return DownCollider.isTrigger;
    }

    public override GameObject CheckParentObj()
    {
        return UpObj;
    }

    #endregion 필수 구현 부분

    #region 물리 구현 부분

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "region")
        {
            if (collision != null)
            {
                if (transform.position.y < collision.transform.position.y)//자기 위에 충돌할때
                {
                    if (UpCollider.isTrigger == true)
                    {
                        switch (collision.tag)
                        {
                            case "DigitalWrite":
                                sample = collision.GetComponent<DragImage>();
                                if (sample != null)
                                {
                                    if (sample.CheckDownCollider() == true)
                                    {
                                        transform.position = collision.transform.position + new Vector3(0, -51, 0);
                                        this.transform.SetParent(sample.transform);
                                        UpObj = collision.gameObject;
                                        UpCollider.isTrigger = false;
                                        sample.SetDownColllider(false);

                                        //   collision.transform.position = transform.position + new Vector3(0, -51, 0);
                                    }
                                }
                                break;

                            case "ServoBlock":
                                sample = collision.GetComponent<ServoBlock>();
                                if (sample != null)
                                {
                                    if (sample.CheckDownCollider() == true)
                                    {
                                        transform.position = collision.transform.position + new Vector3(0, -51, 0);
                                        this.transform.SetParent(sample.transform);
                                        UpObj = collision.gameObject;
                                        UpCollider.isTrigger = false;
                                        sample.SetDownColllider(false);

                                        //   collision.transform.position = transform.position + new Vector3(0, -51, 0);
                                    }
                                }
                                break;

                            case "ifBlock":
                                sample = collision.GetComponent<ifBlock>();
                                if (sample != null)
                                {
                                    if (sample.CheckDownCollider() == true)
                                    {
                                        transform.position = collision.transform.position + new Vector3(0, -51, 0);
                                        this.transform.SetParent(sample.transform);
                                        UpObj = collision.gameObject;
                                        UpCollider.isTrigger = false;
                                        sample.SetDownColllider(false);
                                    }
                                }
                                break;

                            case "ifBar":
                                sample = collision.GetComponent<ifBar>();
                                if (sample != null)
                                {
                                    if (sample.CheckDownCollider() == true)
                                    {
                                        transform.position = collision.transform.position + new Vector3(0, -51, 0);
                                        this.transform.SetParent(sample.transform);
                                        UpObj = collision.gameObject;
                                        UpCollider.isTrigger = false;
                                        sample.SetDownColllider(false);
                                    }
                                }
                                break;

                            case "Block":
                                sample = collision.GetComponent<StartBlock>();
                                if (sample != null)
                                {
                                    if (sample.CheckDownCollider() == true)
                                    {
                                        transform.position = collision.transform.position + new Vector3(0, -51, 0);
                                        this.transform.SetParent(sample.transform);
                                        UpObj = collision.gameObject;
                                        UpCollider.isTrigger = false;
                                        sample.SetDownColllider(false);
                                    }
                                }
                                break;

                            case "AnalogRead":
                                sample = collision.GetComponent<AnalogRead>();
                                if (sample != null)
                                {
                                    if (sample.CheckDownCollider() == true)
                                    {
                                        transform.position = collision.transform.position + new Vector3(0, -51, 0);
                                        this.transform.SetParent(sample.transform);
                                        UpObj = collision.gameObject;
                                        UpCollider.isTrigger = false;
                                        sample.SetDownColllider(false);

                                        //   collision.transform.position = transform.position + new Vector3(0, -51, 0);
                                    }
                                }
                                break;

                            case "WaitBlock":
                                sample = collision.GetComponent<WaitBlock>();
                                if (sample != null)
                                {
                                    if (sample.CheckDownCollider() == true)
                                    {
                                        transform.position = collision.transform.position + new Vector3(0, -51, 0);
                                        this.transform.SetParent(sample.transform);
                                        UpObj = collision.gameObject;
                                        UpCollider.isTrigger = false;
                                        sample.SetDownColllider(false);
                                    }
                                }
                                break;

                            case "UltBlock":
                                sample = collision.GetComponent<UltBlock>();
                                if (sample != null)
                                {
                                    if (sample.CheckDownCollider() == true)
                                    {
                                        transform.position = collision.transform.position + new Vector3(0, -51, 0);
                                        this.transform.SetParent(sample.transform);
                                        UpObj = collision.gameObject;
                                        UpCollider.isTrigger = false;
                                        sample.SetDownColllider(false);
                                    }
                                }
                                break;
                        }
                    }
                }
                else if (transform.position.y > collision.transform.position.y) // 자기 아랫부분에서 충돌할때
                {
                    switch (collision.tag)
                    {
                        case "DigitalWrite":
                            sample = collision.GetComponent<DragImage>();
                            if (sample != null)
                            {
                                if (sample.CheckParentObj() == this.gameObject)
                                {
                                    DownObj = collision.gameObject;

                                    //   collision.transform.position = transform.position + new Vector3(0, -51, 0);
                                }
                            }
                            break;

                        case "ifBlock":
                            sample = collision.GetComponent<ifBlock>();
                            if (sample != null)
                            {
                                if (sample.CheckParentObj() == this.gameObject)
                                {
                                    DownObj = collision.gameObject;
                                }
                            }
                            break;

                        case "Block":
                            sample = collision.GetComponent<StartBlock>();
                            if (sample != null)
                            {
                                if (sample.CheckParentObj() == true)
                                {
                                    DownObj = collision.gameObject;

                                    collision.transform.position = transform.position + new Vector3(0, -51, 0);
                                }
                            }
                            break;

                        case "AnalogRead":
                            sample = collision.GetComponent<AnalogRead>();
                            if (sample != null)
                            {
                                if (sample.CheckParentObj() == this.gameObject)
                                {
                                    DownObj = collision.gameObject;

                                    //   collision.transform.position = transform.position + new Vector3(0, -51, 0);
                                }
                            }
                            break;

                        case "WaitBlock":
                            sample = collision.GetComponent<WaitBlock>();
                            if (sample != null)
                            {
                                if (sample.CheckParentObj() == this.gameObject)
                                {
                                    DownObj = collision.gameObject;

                                    //   collision.transform.position = transform.position + new Vector3(0, -51, 0);
                                }
                            }
                            break;

                        case "ServoBlock":
                            sample = collision.GetComponent<ServoBlock>();
                            if (sample != null)
                            {
                                if (sample.CheckParentObj() == this.gameObject)
                                {
                                    DownObj = collision.gameObject;

                                    //   collision.transform.position = transform.position + new Vector3(0, -51, 0);
                                }
                            }
                            break;

                        case "UltBlock":
                            sample = collision.GetComponent<UltBlock>();
                            if (sample != null)
                            {
                                if (sample.CheckParentObj() == this.gameObject)
                                {
                                    DownObj = collision.gameObject;

                                    //   collision.transform.position = transform.position + new Vector3(0, -51, 0);
                                }
                            }
                            break;
                    }
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Block block = null;

        if (this.transform.parent != null)
        {
            if (UpObj != null)
            {
                switch (UpObj.tag)
                {
                    case "DigitalWrite":
                        block = UpObj.GetComponent<DragImage>();
                        block.SetDownColllider(true);
                        UpCollider.isTrigger = true;
                        break;

                    case "Block":
                        block = UpObj.GetComponent<StartBlock>();
                        block.SetDownColllider(true);
                        UpCollider.isTrigger = true;
                        break;

                    case "ifBlock":
                        block = UpObj.GetComponent<ifBlock>();
                        block.SetDownColllider(true);
                        UpCollider.isTrigger = true;
                        break;

                    case "ifBar":
                        block = UpObj.GetComponent<ifBar>();
                        block.SetDownColllider(true);
                        UpCollider.isTrigger = true;
                        break;

                    case "AnalogRead":
                        block = UpObj.GetComponent<AnalogRead>();
                        block.SetDownColllider(true);
                        UpCollider.isTrigger = true;
                        break;

                    case "WaitBlock":
                        block = UpObj.GetComponent<WaitBlock>();
                        block.SetDownColllider(true);
                        UpCollider.isTrigger = true;
                        break;

                    case "ServoBlock":
                        block = UpObj.GetComponent<ServoBlock>();
                        block.SetDownColllider(true);
                        UpCollider.isTrigger = true;
                        break;

                    case "UltBLock":
                        block = UpObj.GetComponent<UltBlock>();
                        block.SetDownColllider(true);
                        UpCollider.isTrigger = true;
                        break;
                }

                this.transform.SetParent(parentobj.transform);
            }
        }
        //var screenpoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f);

        if (GameManager.RunBlock == true)
            transform.position = Input.mousePosition; //secondCamera.ScreenToWorldPoint(screenpoint);
    }

    #endregion 물리 구현 부분

    #region 고유 구현 부분

    public void SetNum(int _num)
    {
        selectnum = _num;

        selectSecket = arduino.PinList[_num];
    }

    public void HumiTemp()
    {
        GameManager.AddHeader("#" + "include " + "DHT.h");
        GameManager.AddValueLis("#" + "define " + "DHTPIN " + selectnum);
        GameManager.AddValueLis("#" + "define " + "DHTTYPE " + "DHT11");
        GameManager.AddValueLis("DHT dht(DHTPIN,DHTTYPE);");

        GameManager.loop.Add("humi= dht.readHumidity();");
        GameManager.loop.Add("temp=dht.readTemperature();");
    }

    public void syncHumiTemp()
    {
        GameManager.AddHeader("#" + "include " + "DHT.h");
        GameManager.AddValueLis("#" + "define " + "DHTPIN " + selectnum);
        GameManager.AddValueLis("#" + "define " + "DHTTYPE " + "DHT11");
        GameManager.AddValueLis("DHT dht(DHTPIN,DHTTYPE);");
        GameManager.loop.Add("if(sync==" + selectnum + ")\n{");
        GameManager.loop.Add("float humi= dht.readHumidity();");
        GameManager.loop.Add("float temp=dht.readTemperature();");
        GameManager.loop.Add("Serial.println(humi);");
        GameManager.loop.Add("Serial.println(temp);");
        GameManager.loop.Add("\n}");
    }

    public void syncBTHumiTemp()
    {
        GameManager.AddHeader("#" + "include " + "DHT.h");
        GameManager.AddValueLis("#" + "define " + "DHTPIN " + selectnum);
        GameManager.AddValueLis("#" + "define " + "DHTTYPE " + "DHT11");
        GameManager.AddValueLis("DHT dht(DHTPIN,DHTTYPE);");
        GameManager.loop.Add("if(sync==" + selectnum + ")\n{");
        GameManager.loop.Add("float humi= dht.readHumidity();");
        GameManager.loop.Add("float temp=dht.readTemperature();");
        GameManager.loop.Add("btSerial.println(humi)");
        GameManager.loop.Add("btSerial.println(temp)");
        GameManager.loop.Add("\n}");
    }

    public void LuxCode()
    {
        GameManager.AddValueLis("int lux=0;");

        if (selectnum == 14)
            GameManager.loop.Add("lux=analogRead(A0);");
        else if (selectnum == 15)
            GameManager.loop.Add("lux=analogRead(A1);");
        else if (selectnum == 16)
            GameManager.loop.Add("lux=analogRead(A2);");
        else if (selectnum == 17)
            GameManager.loop.Add("lux=analogRead(A3);");
        else if (selectnum == 18)
            GameManager.loop.Add("lux=analogRead(A4);");
        else if (selectnum == 19)
            GameManager.loop.Add("lux=analogRead(A5);");
    }

    public void syncLuxCode()
    {
        GameManager.AddValueLis("int lux=0;");

        if (selectnum == 14)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A0" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A0);");
        }
        else if (selectnum == 15)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A1" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A1);");
        }
        else if (selectnum == 16)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A2" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A2);");
        }
        else if (selectnum == 17)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A3" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A3);");
        }
        else if (selectnum == 18)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A4" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A4);");
        }
        else if (selectnum == 19)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A5" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A5);");
        }

        GameManager.loop.Add("\nSerial.println(lux);");
        GameManager.loop.Add("\n}\n");
        GameManager.loop.Add("\n");
    }

    public void syncBTLuxCode()
    {
        GameManager.AddValueLis("int lux=0;");

        if (selectnum == 14)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A0" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A0);");
        }
        else if (selectnum == 15)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A1" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A1);");
        }
        else if (selectnum == 16)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A2" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A2);");
        }
        else if (selectnum == 17)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A3" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A3);");
        }
        else if (selectnum == 18)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A4" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A4);");
        }
        else if (selectnum == 19)
        {
            GameManager.loop.Add("if(sync==" + '"' + "A5" + '"' + ")\n{");
            GameManager.loop.Add("lux=analogRead(A5);");
        }

        GameManager.loop.Add("\nbtSerial.println(lux);");
        GameManager.loop.Add("\n}\n");
        GameManager.loop.Add("\n");
    }

    #endregion 고유 구현 부분
}