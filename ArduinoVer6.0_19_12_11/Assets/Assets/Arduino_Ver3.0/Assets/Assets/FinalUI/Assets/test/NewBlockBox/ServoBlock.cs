using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ServoBlock : Block, IDragHandler, IDropHandler
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
    public bool UpConncet = false;
    public bool DownConnect = false;

    public GameObject ParentObj;
    public float value = 0f;

    private Block sample;
    private bool GetChild = false;

    #endregion 변수

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

    #region 필수 구현 부분

    public override IEnumerator Run(float s)
    {
        GetChild = false;
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                case GameManager.SensorType.Servo:
                    selectSecket.SocketRun(value);
                    break;

                    //  selectSecket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.Run(0));
            GetChild = true;
        }

        if (GetChild == false && s == 0)
        {
            GameManager.RunbtnWork();
        }
    }

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        GetChild = false;

       
        GameManager.DigitalWrite(selectnum.ToString() + value);

        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                case GameManager.SensorType.Servo:
                    selectSecket.SocketRun(value);
                    break;

                    //  selectSecket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(2.0f);

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.SyncRun(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        { GameManager.closeArduino(); GameManager.SyncRun(); }
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

        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                case GameManager.SensorType.Servo:
                    ServoRunCode();
                    break;

                    //  selectSecket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetCode(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        {
            GameManager.MergeCode(); GameManager.connectArduino.SetMeshMaterial(false);
        }
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;

        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                case GameManager.SensorType.Servo:
                    syncServoRunCode();
                    break;

                    //  selectSecket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(1f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetSyncCode(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        {
            GameManager.syncMergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;

        if (selectSecket != null)
        {
            switch (selectSecket.SocketType)
            {
                case GameManager.SensorType.Servo:
                    syncServoRunCode();
                    break;

                    //  selectSecket.SocketRun(0);
            }
        }

        yield return new WaitForSecondsRealtime(1f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetBtCode(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        {
            GameManager.syncBTMergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
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
            if (collision == null)
                return;

            if (transform.position.y < collision.transform.position.y)//자기 위에 충돌할때
            {
                if (UpCollider.isTrigger == true)
                {
                    sample = BlockManager.instance.BlockIdentity(collision);
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
                }
            }
            else if (transform.position.y > collision.transform.position.y) // 자기 아랫부분에서 충돌할때
            {
                sample = BlockManager.instance.BlockIdentity(collision);
                if (sample != null)
                {
                    if (sample.CheckParentObj() == this.gameObject)
                    {
                        DownObj = collision.gameObject;
                    }
                }
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this.transform.parent != null)
        {
            if (UpObj != null)
            {
                Block block = BlockManager.instance.BlockIdentity(UpObj);
                block.SetDownColllider(true);
                UpCollider.isTrigger = true;

                this.transform.SetParent(ParentObj.transform);
            }
        }

        if (GameManager.RunBlock == true)
            transform.position = Input.mousePosition; //secondCamera.ScreenToWorldPoint(screenpoint);

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
    }

    #endregion 물리 구현 부분

    #region 고유 구현 부분

    private void ServoRunCode()
    {
        GameManager.AddHeader("#include<Servo.h>");
        GameManager.AddValueLis("Servo servo;");
        GameManager.Addsetup("servo.attach(" + selectnum + ");");

        GameManager.loop.Add("servo.write(" + value + ");");
    }

    private void syncServoRunCode()
    {
        GameManager.AddHeader("#include<Servo.h>");
        GameManager.AddValueLis("Servo servo;");

        GameManager.Addsetup("servo.attach(" + selectnum + ");");
        GameManager.loop.Add("if(sync==" + '"' + selectnum + value + '"' + ")\n{");
        GameManager.loop.Add("servo.write(" + value + ");");
        GameManager.loop.Add("\n}");
        GameManager.loop.Add("\n");
    }

    private void syncBTServoRunCode()
    {
        GameManager.AddHeader("#include<Servo.h>");
        GameManager.AddValueLis("Servo servo;");

        GameManager.Addsetup("servo.attach(" + selectnum + ");");
        GameManager.loop.Add("if(sync==" + '"' + selectnum + value + '"' + ")\n{");
        GameManager.loop.Add("servo.write(" + value + ");");
        GameManager.loop.Add("\n}");
        GameManager.loop.Add("\n");
    }

    public void SetNum(int _num)
    {
        selectnum = _num;

        selectSecket = arduino.PinList[_num];
    }

    public void setAngle(float s)
    {
        value = s;
    }

    #endregion 고유 구현 부분
}