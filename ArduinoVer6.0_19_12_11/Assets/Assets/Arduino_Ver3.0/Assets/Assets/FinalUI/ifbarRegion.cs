using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ifbarRegion : MonoBehaviour
{
    // Start is called before the first frame update
    ifBlock ifblock;
    public int count = 0;
    
    Vector3 Firstlocation;
    Vector3 FirstScale;
   
    List<GameObject> objlist = new List<GameObject>();

    RectTransform thisrect;

    Vector2 Firstpos;
    BoxCollider2D box;
    Vector2 Firstbox;

    private void Start()
    {
        ifblock = this.gameObject.GetComponentInParent<ifBlock>();

        Firstlocation = this.transform.localPosition;
       
        FirstScale = this.gameObject.transform.localScale;

        thisrect = this.gameObject.GetComponent<RectTransform>();

        Firstpos = thisrect.sizeDelta;
        box = this.GetComponent<BoxCollider2D>();
        Firstbox = box.size;
    }

    public Vector3 GetLocalScale()
    {

        return this.transform.localScale;
    }

    public Vector3 GetLocalPosition()
    {
        return this.transform.localPosition;
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "ifBlock"&& collision.tag != "ifBar")
        {
            for (int i = 0; i < objlist.Count; i++)
            {
                if (objlist[i] == collision.gameObject)
                    return;
            }

            count += 1;

            // this.transform.localPosition = Firstlocation - count*new Vector3(0, 1, 0); //위치 변경
            if (count >= 1)
            {
                box.size = new Vector2(Firstbox.x, Firstbox.y + (49 * (count - 1)));// 컬라이더 사이즈 증가/감소
                box.offset = new Vector2(0, 4 + (-24.5f * (count - 1)));
            }
            else if (count == 0)
            {
                box.size = new Vector2(Firstbox.x, 75);// 컬라이더 사이즈 증가/감소
                box.offset = new Vector2(0, 4);
            }

            //thisrect.sizeDelta = new Vector2(this.thisrect.sizeDelta.x, Firstpos.y + count * 300);

            if (count >= 1)
            { ifblock.ChangeBar(-(count-1) * 51); }
            else if(count ==0)
            {
                ifblock.ChangeBar(-(count) * 51);
            }
            objlist.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "ifBlock" && collision.tag != "ifBar")
        {
            for (int i = 0; i < objlist.Count; i++)
            {
                if (objlist[i] == collision.gameObject)
                {
                    objlist.Remove(objlist[i]);
                    count -= 1;
                }
            }

            // this.transform.localPosition = Firstlocation - new Vector3(0, 0.3f, 0);
            if (count >= 1)
            {
                box.size = new Vector2(Firstbox.x, Firstbox.y + (49 * (count - 1)));// 컬라이더 사이즈 증가/감소
                box.offset = new Vector2(0, 4 + (-24.5f * (count - 1)));
            }
            else if(count == 0)
            {
                box.size = new Vector2(Firstbox.x, 75);// 컬라이더 사이즈 증가/감소
                box.offset = new Vector2(0, 4);
            }

            // thisrect.sizeDelta = new Vector2(this.thisrect.sizeDelta.x, Firstpos.y + count * 300);

            if (count >= 1)
            { ifblock.ChangeBar(-(count -1) * 51); }
            else if (count == 0)
            {
                ifblock.ChangeBar(-(count) * 51);
            }
        }
    }

}
