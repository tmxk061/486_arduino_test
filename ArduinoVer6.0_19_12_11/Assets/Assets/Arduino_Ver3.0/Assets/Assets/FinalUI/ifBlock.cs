using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ifBlock : Block, IDragHandler, IDropHandler
{
    #region 변수

    //private GameObject dragObject;
    //private RectTransform rect;
    //private Vector3 mos, trans;
    //private Vector3 distance;
    //public Socket selectSecket;
    //[SerializeField]
    //public Canvas canvas;
    //public bool selectRun = true;
    // public RectTransform barrect;
    //public Vector3 Firstlocation;

    private GameObject UpObj;
    private GameObject DownObj;
    private Collider2D[] colliders;
    private Collider2D UpCollider;

    [SerializeField]
    private Collider2D DownCollider;

    public int ThirdSel = 0;
    private bool okvalue = false;
    public int FirstSel = 0;
    public int SecondSel = 0;
    public ifBar bar;
    public RectTransform barlocation;

    [SerializeField]
    public ifbarRegion region;

    public Block sample;
    public Vector2 FirstAnchoredPosition;

    public GameObject ParentObj;
    private Outline outline;
    public bool GetChild = false;

    #endregion 변수

    private void Start()
    {
        bar = this.gameObject.GetComponentInChildren<ifBar>();

        barlocation = bar.transform.GetComponent<RectTransform>();
        FirstAnchoredPosition = barlocation.anchoredPosition;

        colliders = this.GetComponents<Collider2D>();

        ParentObj =
            GameObject.Find("PanelBlockCoding").gameObject.
            transform.Find("CodingPanel").gameObject.
            transform.Find("CodingMaskPanel").
            gameObject;

        outline = GameObject.Find("UnderBar").gameObject.GetComponent<Outline>();

        this.transform.position = new Vector3(930, 421);

        if (colliders != null)
        {
            DownCollider = colliders[1];

            UpCollider = colliders[0];
        }
    }

    #region 필수 구현부분

    public override IEnumerator Run(float s)
    {
        GetChild = false;
        okvalue = false;
        Block block = null;

        if (FirstSel == 0)
        {
            if (SecondSel == 0)
            {
                if (GameManager.distance >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.distance == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.distance <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 1)
        {
            if (SecondSel == 0)
            {
                if (GameManager.temp >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.temp == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.temp <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 2)
        {
            if (SecondSel == 0)
            {
                if (GameManager.humi >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.humi == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.humi <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 3)
        {
            if (SecondSel == 0)
            {
                if (GameManager.lux >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.lux == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.lux <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }

        if (okvalue == true)
        {
            foreach (Transform child in transform)
            {
                switch (child.tag)
                {
                    case "DigitalWrite":
                        block = child.GetComponent<DragImage>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "AnalogRead":
                        block = child.GetComponent<AnalogRead>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "ifBlock":
                        block = child.GetComponent<ifBlock>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "WaitBlock":
                        block = child.GetComponent<WaitBlock>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "ServoBlock":
                        block = child.GetComponent<ServoBlock>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "UltBlcok":
                        block = child.GetComponent<UltBlock>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;
                }
            }
        }
        else
        {
            yield return new WaitForSeconds(region.count * 0.4f);
            StartCoroutine(bar.Run(0));
        }
    }

    public override IEnumerator SyncRun(bool s)
    {
        Block block = null;

        okvalue = false;

        if (FirstSel == 0)
        {
            if (SecondSel == 0)
            {
                if (GameManager.distance >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.distance == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.distance <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 1)
        {
            if (SecondSel == 0)
            {
                if (GameManager.temp >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.temp == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.temp <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 2)
        {
            if (SecondSel == 0)
            {
                if (GameManager.humi >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.humi == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.humi <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }
        else if (FirstSel == 3)
        {
            if (SecondSel == 0)
            {
                if (GameManager.lux >= ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 1)
            {
                if (GameManager.lux == ThirdSel)
                {
                    okvalue = true;
                }
            }
            else if (SecondSel == 2)
            {
                if (GameManager.lux <= ThirdSel)
                {
                    okvalue = true;
                }
            }
        }

        if (okvalue == true)
        {
            GameManager.DigitalWrite(FirstSel.ToString() + SecondSel.ToString() + ThirdSel.ToString());

            foreach (Transform child in transform)
            {
                switch (child.tag)
                {
                    case "DigitalWrite":
                        block = child.GetComponent<DragImage>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "ifBlock":
                        block = child.GetComponent<ifBlock>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "AnalogRead":
                        block = child.GetComponent<AnalogRead>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "WaitBlock":
                        block = child.GetComponent<WaitBlock>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "ServoBlock":
                        block = child.GetComponent<ServoBlock>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;

                    case "UltBlock":
                        block = child.GetComponent<UltBlock>();
                        StartCoroutine(block.Run(1));
                        GetChild = true;
                        break;
                }
            }

            yield return new WaitForSecondsRealtime(region.count * 1f);
        }
        else if (okvalue == false)
        {
            yield return new WaitForSecondsRealtime(1f);
        }

        StartCoroutine(bar.SyncRun(s));
    }

    public override IEnumerator GetCode(bool s)
    {
        GetChild = false;
        okvalue = false;
        Block block = null;

        if (FirstSel == 0)
        {
            GameManager.AddValueLis("int lux = 0;");
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(lux>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(lux==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(lux<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 1)
        {
            GameManager.AddValueLis("int temp=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(temp>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(temp==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(temp<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 2)
        {
            GameManager.AddValueLis("int humi=0;");
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(humi>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(humi==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(humi<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 3)
        {
            GameManager.AddValueLis("int lux=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(lux >=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(lux ==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(lux <=" + ThirdSel + ")\n" + "{");
            }
        }

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;
            }
        }

        yield return new WaitForSecondsRealtime(region.count * 1f + 1f);

        StartCoroutine(bar.GetCode(s));
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;

        Block block = null;

        GameManager.loop.Add("if(sync==" + '"' + FirstSel.ToString() + SecondSel.ToString() + ThirdSel.ToString() + '"' + ")\n{");

        if (FirstSel == 0)
        {
            GameManager.AddValueLis("int lux = 0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(lux>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(lux==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(lux<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 1)
        {
            GameManager.AddValueLis("int temp=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(temp>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(temp==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(temp<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 2)
        {
            GameManager.AddValueLis("int humi=0;");
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(humi>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(humi==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(humi<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 3)
        {
            GameManager.AddValueLis("int lux=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(lux >=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(lux ==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(lux <=" + ThirdSel + ")\n" + "{");
            }
        }

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.GetCode(false));
                    GetChild = true;
                    break;
            }
        }

        yield return new WaitForSeconds(region.count * 1f + 1f);

        StartCoroutine(bar.GetSyncCode(s));
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;

        Block block = null;

        GameManager.loop.Add("if(sync==" + '"' + FirstSel.ToString() + SecondSel.ToString() + ThirdSel.ToString() + '"' + ")\n{");

        if (FirstSel == 0)
        {
            GameManager.AddValueLis("int lux = 0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(lux>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(lux==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(lux<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 1)
        {
            GameManager.AddValueLis("int temp=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(temp>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(temp==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(temp<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 2)
        {
            GameManager.AddValueLis("int humi=0;");
            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(humi>=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(humi==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(humi<=" + ThirdSel + ")\n" + "{");
            }
        }
        else if (FirstSel == 3)
        {
            GameManager.AddValueLis("int lux=0;");

            if (SecondSel == 0)
            {
                GameManager.loop.Add("if(lux >=" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 1)
            {
                GameManager.loop.Add("if(lux ==" + ThirdSel + ")\n" + "{");
            }
            else if (SecondSel == 2)
            {
                GameManager.loop.Add("if(lux <=" + ThirdSel + ")\n" + "{");
            }
        }

        foreach (Transform child in transform)
        {
            switch (child.tag)
            {
                case "DigitalWrite":
                    block = child.GetComponent<DragImage>();
                    StartCoroutine(block.GetBtCode(false));
                    GetChild = true;
                    break;

                case "AnalogRead":
                    block = child.GetComponent<AnalogRead>();
                    StartCoroutine(block.GetBtCode(false));
                    GetChild = true;
                    break;

                case "ifBlock":
                    block = child.GetComponent<ifBlock>();
                    StartCoroutine(block.GetBtCode(false));
                    GetChild = true;
                    break;

                case "WaitBlock":
                    block = child.GetComponent<WaitBlock>();
                    StartCoroutine(block.GetBtCode(false));
                    GetChild = true;
                    break;

                case "ServoBlock":
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetBtCode(false));
                    GetChild = true;
                    break;

                case "UltBlock":
                    block = child.GetComponent<UltBlock>();
                    StartCoroutine(block.GetBtCode(false));
                    GetChild = true;
                    break;
            }
        }

        yield return new WaitForSeconds(region.count * 1f + 1f);

        StartCoroutine(bar.GetBtCode(s));
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

    #endregion 필수 구현부분

    #region 물리 구현 부분

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "region")
        {
            if (collision != null)
            {
                if (transform.position.y < collision.transform.position.y)//자기 위에 충돌할때
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
                                    this.transform.SetParent(collision.gameObject.transform);
                                    UpObj = collision.gameObject;
                                    UpCollider.isTrigger = false;
                                    sample.SetDownColllider(false);
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
                                    this.transform.SetParent(collision.gameObject.transform);
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

                        case "Block":
                            sample = collision.GetComponent<StartBlock>();
                            if (sample != null)
                            {
                                if (sample.CheckDownCollider() == true)
                                {
                                    transform.position = collision.transform.position + new Vector3(0, -51, 0);
                                    this.transform.SetParent(collision.gameObject.transform);
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
                            Debug.Log("asda");
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
                                }
                            }
                            break;
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

                        case "ifBar":
                            sample = collision.GetComponent<ifBar>();
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

                this.transform.SetParent(ParentObj.transform);
            }
        }

        if (GameManager.RunBlock == true)
            transform.position = Input.mousePosition;

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        outline.effectColor = new Color(255, 0, 0, 255);
    }

    public void OnDrop(PointerEventData eventData)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
        outline.effectColor = new Color(255, 0, 0, 0);
    }

    #endregion 물리 구현 부분

    #region 고유 구현 부분

    public void ChangeBar(float vec)
    {
        barlocation.anchoredPosition = new Vector2(FirstAnchoredPosition.x, FirstAnchoredPosition.y + vec);
        // barlocation.offsetMin = new Vector2(firstTop.x, firstTop.y - vec);                                // Bottom
    }

    #endregion 고유 구현 부분
}