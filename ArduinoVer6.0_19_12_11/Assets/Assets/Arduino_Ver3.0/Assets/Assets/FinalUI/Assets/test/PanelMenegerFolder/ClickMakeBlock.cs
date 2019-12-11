using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMakeBlock : MonoBehaviour
{
    public GameObject obj;
    public GameObject parent;

    public void ClickEvent()
    {
        obj.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1));
        Instantiate(obj).transform.SetParent(parent.transform);

        //obj.transform.position = new Vector3(0, 0);
        //obj.transform.localPosition = new Vector2(0, 0);
    }
}
