using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartBlock : Block, IDragHandler, IDropHandler
{
    #region 변수

    //private GameObject dragObject;
    //private RectTransform rect;
    //private Vector3 mos, trans;
    //private Vector3 distance;
    //private GameObject UpObj;
    //private bool First = true;

    private GameObject DownObj;
    private Collider2D Downcollider;
    private Block sample;
    private bool GetChild = false;

    #endregion 변수

    private void Start()
    {
        Downcollider = this.GetComponent<Collider2D>();
    }

    #region 필수 구현 부분

    public override IEnumerator Run(float s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);

        yield return new WaitForSeconds(0.3f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if(block != null)
            StartCoroutine(block.Run(0));

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
    }

    public override IEnumerator SyncRun(bool s)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
        GameManager.openArduino();

        GetChild = false;

        yield return new WaitForSecondsRealtime(1f);

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.SyncRun(s));

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
    }

    public override void SetUPColllider(bool s)
    {
    }

    public override void SetDownColllider(bool s)
    {
        if (DownObj != null)
        {
            Downcollider.isTrigger = s;
        }
    }

    public override bool CheckUoCollider()
    {
        return Downcollider.isTrigger;
    }

    public override bool CheckDownCollider()
    {
        if (Downcollider.isTrigger == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override IEnumerator GetCode(bool s)
    {
        bool GetChild = false;

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.GetCode(s));

        yield return new WaitForSeconds(0.3f);

        if (GetChild == false)
            GameManager.connectArduino.SetMeshMaterial(false);
    }

    public override IEnumerator GetSyncCode(bool s)
    {
        bool GetChild = false;

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.GetSyncCode(s));

        yield return new WaitForSeconds(0.3f);

        if (GetChild == false)
            GameManager.connectArduino.SetMeshMaterial(false);
    }

    public override IEnumerator GetBtCode(bool s)
    {
        bool GetChild = false;

        Block block = BlockManager.instance.BlockIdentity(transform);
        if (block != null)
            StartCoroutine(block.GetBtCode(s));

        yield return new WaitForSeconds(0.3f);

        if (GetChild == false)
            GameManager.connectArduino.SetMeshMaterial(false);
    }

    public override GameObject CheckParentObj()
    {
        return null;
    }

    #endregion 필수 구현 부분

    #region 물리 구현부분

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "region")
            return;

        if (collision == null)
            return;

        if (transform.position.y > collision.transform.position.y) //자기 밑에 충돌할때
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

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.RunBlock == true)
            transform.position = Input.mousePosition;

        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 255);
    }

    public void OnDrop(PointerEventData eventData)
    {
        this.GetComponent<Outline>().effectColor = new Color(255, 0, 0, 0);
    }

    #endregion 물리 구현부분
}