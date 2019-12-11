using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ifBar : Block, IDragHandler
{
    #region 변수

    //private Vector3 mos, trans;
    //private Vector3 distance;
    //public Socket selectSecket;
    //private RectTransform rect;
    //private ifBlock block;

    private GameObject UpObj;
    private GameObject DownObj;
    private Collider2D[] colliders;
    private Collider2D UpCollider;

    [SerializeField]
    private Collider2D DownCollider;

    [SerializeField]
    public Canvas canvas;

    private Block sample;
    public bool GetChild = false;

    #endregion 변수

    private void Start()
    {
        DownCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    #region 필수 구현 부분

    public override IEnumerator Run(float s)
    {
        GetChild = false;
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
                    block = child.GetComponent<ifBlock>();
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

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false) GameManager.RunbtnWork();
    }

    public override IEnumerator SyncRun(bool s)
    {
        Block block = null;

        yield return new WaitForSecondsRealtime(1f);

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
    }

    public override void SetDownColllider(bool s)
    {
        if (DownCollider != null)
            DownCollider.isTrigger = s;
    }

    public override void SetUPColllider(bool s)
    {
        //코드 추가 바랍니다.

        //안씀q
    }

    public override bool CheckUoCollider()
    {
        return false;
    }

    public override bool CheckDownCollider()
    {
        return DownCollider.isTrigger;
    }

    public override IEnumerator GetCode(bool s)
    {
        GameManager.loop.Add("}\n");

        GetChild = false;
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
                    block = child.GetComponent<ifBlock>();
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
            }
        }

        yield return new WaitForSecondsRealtime(0.3f);

        if (GetChild == false && s == true)
        {
            GameManager.MergeCode();
        }
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        GameManager.loop.Add("\n}");
        GameManager.loop.Add("\n");

        GetChild = false;
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
                    block = child.GetComponent<ifBlock>();
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
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetSyncCode(s));
                    GetChild = true;
                    break;
            }
        }

        yield return new WaitForSecondsRealtime(1f);

        if (GetChild == false && s == true)
        {
            GameManager.syncMergeCode();
        }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GameManager.loop.Add("\n}");
        GameManager.loop.Add("\n");

        GetChild = false;
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
                    block = child.GetComponent<ifBlock>();
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
                    block = child.GetComponent<ServoBlock>();
                    StartCoroutine(block.GetBtCode(s));
                    GetChild = true;
                    break;
            }
        }

        yield return new WaitForSecondsRealtime(1f);

        if (GetChild == false && s == true)
        {
            GameManager.syncMergeCode();
        }
    }

    public override GameObject CheckParentObj()
    {
        return null;
    }

    #endregion 필수 구현 부분

    #region 물리 구현 부분

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "region")
        {
            if (collision != null)
            {
                //if (transform.position.y < collision.transform.position.y)//자기 위에 충돌할때
                //{
                //    this.transform.parent = collision.GetComponent<Transform>();
                //}
                //else
                if (transform.position.y > collision.transform.position.y) // 자기 아랫부분에서 충돌할때
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

    #endregion 물리 구현 부분
}