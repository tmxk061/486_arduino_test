using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewVariable : MonoBehaviour
{
    private GameObject obj;
    public string SaveName = "";

    Text childtext;

    public GameObject CreatObj;
    public GameObject parent;

    void Start()
    {
        //parent = GameObject.Find("BlockCodingCanvas").transform.Find("PanelBlockCoding").transform.Find("CodingPanel").transform.Find("CodingMaskPanel").gameObject;

        obj = GetComponent<GameObject>();

        childtext = transform.GetChild(0).GetComponent<Text>();

        CreateVariableBlockScript script = GameObject.Find("BlockCodingCanvas").transform.Find("InputField").GetComponent<CreateVariableBlockScript>();

        this.transform.name = script.SaveName;
        childtext.text = script.SaveName;

        SaveName = script.SaveName;

        //this.transform.position = new Vector3(0, 0);
        this.transform.localPosition = new Vector2(0, script.i);
    }

    public void ClickEvent()
    {
        CreatObj.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, 1));
        Instantiate(CreatObj).transform.SetParent(parent.transform);
    }
}
