using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UltBlock : Block, IDragHandler
{
    #region 변수

    //[SerializeField]
    //public Canvas canvas;
    //public bool UpConncet = false;
    //public bool DownConnect = false;
    //[SerializeField]
    //public Camera secondCamera;

    private GameObject UpObj = null;
    private GameObject DownObj;
    private Collider2D[] colliders;
    private Collider2D UpCollider;
    private Collider2D DownCollider;
    private ControlArduino arduino;
    public int selectnum = 0;
    public int selectnum2 = 0;
    public Socket selectSecket;
    public Socket selectSecket2;

    public bool selectRun = true;
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
        selectSecket2 = arduino.PinList[0];
    }

    #region 필수 구현 부분

    public override IEnumerator Run(float s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        GetChild = false;

        if (selectSecket2 != null && selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:

                    selectSecket.SocketRun(0);

                    break;

                    //  selectSecket.SocketRun(0);
            }

            switch (selectSecket2.SocketType)
            {
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:

                    float? value = selectSecket2.floatSocketRun();
                    float value3 = float.Parse(value.ToString());

                    GameManager.Setdistancetext("핀" + selectnum + " : " + Mathf.RoundToInt(value3) + "cm");
                    GameManager.distance = value;

                    break;

                    //  selectSecket.SocketRun(0);
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
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        Block block = null;

        GameManager.DigitalWrite(selectnum.ToString() + selectnum2.ToString());

        yield return new WaitForSecondsRealtime(2f);
        GameManager.ReadArduinoValue();

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
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

    public override IEnumerator GetCode(bool s)
    {
        GetChild = false;
        if (selectSecket2 != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket2.SocketType)
                {
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        UltCode();
                        break;
                }
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
        if (selectSecket2 != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket2.SocketType)
                {
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        syncUltCode();
                        break;
                }
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

        yield return new WaitForSecondsRealtime(1f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.syncMergeCode();
        }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;
        if (selectSecket2 != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket2.SocketType)
                {
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        syncBTUltCode();
                        break;
                }
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

        yield return new WaitForSecondsRealtime(1f);

        if (GetChild == false && s == true)
        {
            GameManager.connectArduino.SetMeshMaterial(false);
            GameManager.syncBTMergeCode();
        }
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
                                if (sample.CheckParentObj() == this.gameObject)
                                {
                                    DownObj = collision.gameObject;
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

                    case "UltBlock":
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

    public void UltCode()
    {
        GameManager.AddValueLis("long duration=0;\n");
        GameManager.AddValueLis("long distance=0;\n");
        GameManager.Addsetup("Serial.begin(9600);");
        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");
        GameManager.Addsetup("pinMode(" + selectnum2 + ",INPUT);");
        GameManager.loop.Add("digitalWrite(" + selectnum + ",HIGH);\n");
        GameManager.loop.Add("delay(100);\n");
        GameManager.loop.Add("digitalWrite(" + selectnum + ",LOW);\n");
        GameManager.loop.Add("duration=pulseIn(" + selectnum2 + ",HIGH);\n");
        GameManager.loop.Add("distance=duration/58.2;\n");
        GameManager.loop.Add("Serial.println(distance);");
    }

    public void syncUltCode()
    {
        GameManager.AddValueLis("long duration=0;\n");
        GameManager.AddValueLis("long distance=0;\n");
        GameManager.Addsetup("Serial.begin(9600);");
        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");
        GameManager.Addsetup("pinMode(" + selectnum2 + ",INPUT);");

        string loopsentence = string.Format("");

        loopsentence += "if(sync==" + '"' + selectnum + selectnum2 + '"' + ")\n{";
        loopsentence += "digitalWrite(" + selectnum + ",HIGH);\n";
        loopsentence += "delay(100);\n";
        loopsentence += "digitalWrite(" + selectnum + ",LOW);\n";
        loopsentence += "duration=pulseIn(" + selectnum2 + ",HIGH);\n";
        loopsentence += "distance=duration/58.2;\n";
        loopsentence += "Serial.println(distance);\n}";

        GameManager.AddloopList(loopsentence);
    }

    public void syncBTUltCode()
    {
        GameManager.AddValueLis("long duration=0;\n");
        GameManager.AddValueLis("long distance=0;\n");
        GameManager.Addsetup("Serial.begin(9600);");
        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");
        GameManager.Addsetup("pinMode(" + selectnum2 + ",INPUT);");

        string loopsentence = string.Format("");

        loopsentence += "if(sync==" + '"' + selectnum + selectnum2 + '"' + ")\n{";
        loopsentence += "digitalWrite(" + selectnum + ",HIGH);\n";
        loopsentence += "delay(100);\n";
        loopsentence += "digitalWrite(" + selectnum + ",LOW);\n";
        loopsentence += "duration=pulseIn(" + selectnum2 + ",HIGH);\n";
        loopsentence += "distance=duration/58.2;\n";
        loopsentence += "btSerial.println(distance);\n}";

        GameManager.AddloopList(loopsentence);
    }

    public void SetNum(int _num)
    {
        selectnum = _num;

        selectSecket = arduino.PinList[_num];
    }

    public void GetNum(int num)
    {
        selectnum2 = num;

        selectSecket2 = arduino.PinList[num];
    }

    #endregion 고유 구현 부분
}