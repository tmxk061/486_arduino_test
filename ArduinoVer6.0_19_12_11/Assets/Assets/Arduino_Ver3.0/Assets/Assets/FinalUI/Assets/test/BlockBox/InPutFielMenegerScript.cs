using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InPutFielMenegerScript : MonoBehaviour
{
    private GameObject obj;
    private Text text;

    public void Start()
    {
        text = GetComponent<Text>();
        obj = GameObject.Find("BlockCodingCanvas").gameObject.transform.Find("InputField").gameObject;
    }

    public void ClickEvnet()
    {
        obj.SetActive(true);

        obj.SendMessage("GetString", this.name);
        obj.SendMessage("GetText", text);
    }
}
