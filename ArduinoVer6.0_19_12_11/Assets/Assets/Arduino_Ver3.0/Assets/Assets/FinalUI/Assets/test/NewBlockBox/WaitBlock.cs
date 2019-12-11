using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WaitBlock : Block, IDragHandler, IDropHandler
{
    #region 변수

    //public int selectnum = 0;
    //[SerializeField]
    //public Canvas canvas;
    //public bool selectRun = true;
    //public bool UpConncet = false;
    //public bool DownConnect = false;
    //[SerializeField]
    //public Camera secondCamera;
    //private WaitForSeconds waitForSeconds;

    private GameObject UpObj = null;
    private GameObject DownObj;
    private Collider2D[] colliders;
    private Collider2D UpCollider;
    private Collider2D DownCollider;
    private ControlArduino arduino;
    public GameObject ParentObj;

    public int TimeForWait = 0;

    private Block sample;
    private bool GetChild = false;

    #endregion 변수

    private void Start()
    {
        arduino = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>(); //아두이노 오브젝트 찾기
        ParentObj =
            GameObject.Find("PanelBlockCoding").
            gameObject.transform.Find("CodingPanel").
            gameObject.transform.Find("CodingMaskPanel"). //코딩마스크패널 찾기
            gameObject;

        this.transform.position = new Vector3(930, 421); //초기위치지정

        colliders = this.GetComponents<Collider2D>();//위, 아래 충돌 지정
        if (colliders != null)
        {
            DownCollider = colliders[0];

            UpCollider = colliders[1];
        }
    }

    #region 필수 구현부분

    public override IEnumerator Run(float s)
    {
        GetChild = false;
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(TimeForWait);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.Run(0));
            GetChild = true;
        }

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        if (GetChild == false && s == 0)
        {
            GameManager.RunbtnWork();
        }
    } //실행

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        yield return new WaitForSecondsRealtime(TimeForWait + 1f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.SyncRun(s));
            GetChild = true;
        }

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);

        if (GetChild == false && s == true)
        {
            GameManager.closeArduino();
            GameManager.SyncRun();
        }
    }

    public override IEnumerator GetBtCode(bool s)
    {
        GetChild = false;
       
        yield return new WaitForSeconds(0.3f);

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

    public override IEnumerator GetSyncCode(bool s)
    {
        GetChild = false;
      
        yield return new WaitForSeconds(0.3f);

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

    public override IEnumerator GetCode(bool s)
    {
        GetChild = false;

        GameManager.loop.Add("delay(" + TimeForWait * 1000 + ");\n");

        yield return new WaitForSeconds(0.3f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
        {
            StartCoroutine(block.GetCode(s));
            GetChild = true;
        }

        if (GetChild == false && s == true)
        {
            GameManager.MergeCode();
            GameManager.connectArduino.SetMeshMaterial(false);
        }
    } //코드 떼오기

    public override void SetDownColllider(bool s)
    {
        if (DownCollider != null)
        {
            DownCollider.isTrigger = s;
        }
    } //업 다운 콜라이더 트리거 설정

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
    } //위 충돌 트리거상태 리턴

    public override bool CheckDownCollider()
    {
        return DownCollider.isTrigger;
    } //아래 충돌 트리거 상태 리턴

    public override GameObject CheckParentObj()
    {
        return UpObj;
    } //위에 있는 블록 리턴

    #endregion 필수 구현부분

    #region 물리 구현 부분

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
    } //충돌시 붙히기 코드

    #endregion 물리 구현 부분

    #region 고유 구현 부분

    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(TimeForWait);
    } //몇초 대기

    public void setSecond(int i)
    {
        TimeForWait = i;
    }

    #endregion 고유 구현 부분
}