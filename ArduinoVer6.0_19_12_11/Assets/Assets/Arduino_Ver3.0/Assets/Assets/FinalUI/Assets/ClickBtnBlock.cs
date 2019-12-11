using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBtnBlock : MonoBehaviour
{
    public GameObject obj;
    public GameObject per;

    public void ClickEvent()
    {
        Instantiate(obj).transform.SetParent(per.transform);
        //Instantiate(obj, new Vector2(0, 0), Quaternion.identity);
    }
}
