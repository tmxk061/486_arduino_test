using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragImage : Block, IDragHandler, IDropHandler
{
    #region 필수

    private GameObject UpObj = null;
    private GameObject DownObj;
    private Collider2D[] colliders;
    private Collider2D UpCollider;
    private Collider2D DownCollider;
    private ControlArduino arduino;
    public int selectnum = 0;
    public Socket selectSecket;

    [SerializeField]
    public Canvas canvas;

    public bool selectRun = true;
    public bool UpConncet = false;
    public bool DownConnect = false;

    [SerializeField]
    public Camera secondCamera;

    public GameObject ParentObj;

    #endregion 필수

    private Block sample;
    private bool GetChild = false;

    public void SyncDigitalWrite()
    {
        string sen = null;

        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");

        if (selectRun == true)
        {
            sen += "if(sync==" + '"' + selectnum + "True" + '"' + ")\n{";
            sen += "digitalWrite(" + selectnum + ",HIGH);";
        }
        else if (selectRun == false)
        {
            sen += "if(sync==" + '"' + selectnum + "False" + '"' + ")\n{";
            sen += "digitalWrite(" + selectnum + ",LOW);";
        }

        sen += "\n}\n";

        GameManager.AddloopList(sen);
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;

        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                case GameManager.SensorType.Bread:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.normal:
                    break;
                //  DC모터 LED  Servo 등등 작동만 하는 것
                case GameManager.SensorType.DC:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.l298n:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.Led:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.Servo:
                    break;

                case GameManager.SensorType.Sound:
                    Tone();
                    break;
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:
                    //추후 추가 예정
                    break;

                case GameManager.SensorType.HumiTemp:

                    break;

                case GameManager.SensorType.Lux:
                    break;
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
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
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

        if (GetChild == false && s == true)
        {
            GameManager.syncMergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }

    private void Start()
    {
        arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();
        ParentObj = GameObject.Find("PanelBlockCoding").gameObject.transform.Find("CodingPanel").gameObject.transform.Find("CodingMaskPanel").gameObject;

        this.transform.position = new Vector3(930, 421);

        colliders = this.GetComponents<Collider2D>();
        if (colliders != null)
        {
            DownCollider = colliders[0];

            UpCollider = colliders[1];
        }
    }

    public void SetNum(int _num)
    {
        selectnum = _num;

        selectSecket = arduino.PinList[_num];
    }

    public void highlowsel(bool s)
    {
        selectRun = s;
    }

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
                        }
                    }
                }
                else if (transform.position.y > collision.transform.position.y) // 자기 아랫부분에서 충돌할때
                {
                    switch (collision.tag)
                    {
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

    public override GameObject CheckParentObj()
    {
        return UpObj;
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

                this.transform.SetParent(ParentObj.transform);
            }
        }
        //var screenpoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f);

        if (GameManager.RunBlock == true)
            transform.position = Input.mousePosition; //secondCamera.ScreenToWorldPoint(screenpoint);

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
    }

    public override IEnumerator Run(float s)
    {
        GetChild = false;

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        if (selectSecket != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket.SocketType)
                {
                    case GameManager.SensorType.Bread:
                        selectSecket.SocketRun(0);

                        break;

                    case GameManager.SensorType.normal:
                        selectSecket.SocketRun(0);
                        break;
                    //  DC모터 LED  Servo 등등 작동만 하는 것
                    case GameManager.SensorType.DC:
                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.l298n:
                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Led:

                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Servo:
                        break;

                    case GameManager.SensorType.Sound:
                        selectSecket.SocketRun(0);
                        break;
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.HumiTemp:
                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Lux:
                        selectSecket.SocketRun(0);
                        break;

                        //  selectSecket.SocketRun(0);
                }
            }
            else if (selectRun == false)
            {
                selectSecket.SocketPause();
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
                    StartCoroutine(block.Run(0)); ;
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

    public override bool CheckUoCollider()
    {
        return UpCollider.isTrigger;
    }

    public override bool CheckDownCollider()
    {
        return DownCollider.isTrigger;
    }

    public void OnDrop(PointerEventData eventData)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
    }

    public void DigitalWrite()
    {
        GameManager.Addsetup("pinMode(" + selectnum + ",OUTPUT);");

        if (selectRun == true)
        { GameManager.loop.Add("digitalWrite(" + selectnum + ",HIGH);"); }
        else if (selectRun == false)
        { GameManager.loop.Add("digitalWrite(" + selectnum + ",LOW);"); }
    }

    public void Tone()
    {
        GameManager.AddValueLis("int speakerPin =" + selectnum + ";");

        GameManager.loop.Add("tone(speakerPin,261);" + '\n' + "delay(500);" + "noTone(speakerPin);");
    }

    public override IEnumerator GetCode(bool s)
    {
        GetChild = false;

        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                case GameManager.SensorType.Bread:
                    DigitalWrite();
                    break;

                case GameManager.SensorType.normal:
                    break;
                //  DC모터 LED  Servo 등등 작동만 하는 것
                case GameManager.SensorType.DC:
                    DigitalWrite();
                    break;

                case GameManager.SensorType.l298n:
                    DigitalWrite();
                    break;

                case GameManager.SensorType.Led:
                    DigitalWrite();
                    break;

                case GameManager.SensorType.Servo:
                    break;

                case GameManager.SensorType.Sound:
                    Tone();
                    break;
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:
                    //추후 추가 예정
                    break;

                case GameManager.SensorType.HumiTemp:

                    break;

                case GameManager.SensorType.Lux:
                    break;
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
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetCode(s));
                    GetChild = true;
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

        if (GetChild == false && s == true)
        {
            GameManager.MergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        GetChild = false;

        Block block = null;

        //  GameManager.DigitalWrite(selectnum.ToString());
        GameManager.DigitalWrite(selectnum + selectRun.ToString());

        if (selectSecket != null)
        {
            if (selectRun == true)
            {
                switch (selectSecket.SocketType)
                {
                    case GameManager.SensorType.Bread:
                        selectSecket.SocketRun(0);

                        break;

                    case GameManager.SensorType.normal:
                        selectSecket.SocketRun(0);
                        break;
                    //  DC모터 LED  Servo 등등 작동만 하는 것
                    case GameManager.SensorType.DC:
                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.l298n:
                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Led:

                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Servo:
                        break;

                    case GameManager.SensorType.Sound:
                        selectSecket.SocketRun(0);
                        break;
                    // 값을 읽어 들이는 센서
                    case GameManager.SensorType.Ult:
                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.HumiTemp:
                        selectSecket.SocketRun(0);
                        break;

                    case GameManager.SensorType.Lux:
                        selectSecket.SocketRun(0);
                        break;

                        //  selectSecket.SocketRun(0);
                }
            }
            else if (selectRun == false)
            {
                selectSecket.SocketPause();
            }
        }

        yield return new WaitForSecondsRealtime(2.0f);

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
        { GameManager.closeArduino(); GameManager.SyncRun(); }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;

        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                case GameManager.SensorType.Bread:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.normal:
                    break;
                //  DC모터 LED  Servo 등등 작동만 하는 것
                case GameManager.SensorType.DC:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.l298n:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.Led:
                    SyncDigitalWrite();
                    break;

                case GameManager.SensorType.Servo:
                    break;

                case GameManager.SensorType.Sound:
                    Tone();
                    break;
                // 값을 읽어 들이는 센서
                case GameManager.SensorType.Ult:
                    //추후 추가 예정
                    break;

                case GameManager.SensorType.HumiTemp:

                    break;

                case GameManager.SensorType.Lux:
                    break;
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
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
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

        if (GetChild == false && s == true)
        {
            GameManager.syncBTMergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }
}