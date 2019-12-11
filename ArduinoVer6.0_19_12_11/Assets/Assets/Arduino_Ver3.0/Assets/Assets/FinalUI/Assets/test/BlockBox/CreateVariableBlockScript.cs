using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateVariableBlockScript : MonoBehaviour
{
    private InputField input;

    public GameObject obj;
    public GameObject parent;

    public string SaveName;

    public int i = 160;

    public void Start()
    {
        input = GetComponent<InputField>();
        //parent = GameObject.Find("BlockCodingCanvas").transform.Find("PanelMeneger").transform.Find("PanelVariable").gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SaveName = input.text;

            obj.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, 1));
            Instantiate(obj).transform.SetParent(parent.transform);

            //obj.SendMessage("GetString", input.text);
            //obj.SendMessage("UpLoadScript");

            //obj.GetComponent<NewVariable>().GetString(input.text);
            //obj.GetComponent<NewVariable>().UpLoadScript();

            input.text = "";

            input.transform.gameObject.SetActive(false);

            i = i - 25;
        }
    }

    //버튼 동적 생성
    private void CrreateBlock()
    {
        var buttonObject = new GameObject(input.text);
        var image = buttonObject.AddComponent<Image>();
        image.transform.SetParent(parent.transform);
        image.rectTransform.sizeDelta = new Vector2(120, 20);
        image.rectTransform.anchoredPosition = Vector3.zero;
        image.color = new Color(1f, 1f, 1f, 1f);

        var sprite = Resources.Load<Sprite>("block1");
        image.sprite = sprite;

        var button = buttonObject.AddComponent<Button>();
        //button.targetGraphic = image;
        //button.onClick.AddListener(() => Debug.Log(Time.time));
        button.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, 1));

        var textObject = new GameObject("Text");
        textObject.transform.parent = buttonObject.transform;
        var text = textObject.AddComponent<Text>();
        text.rectTransform.sizeDelta = Vector2.zero;
        text.rectTransform.anchorMin = Vector2.zero;
        text.rectTransform.anchorMax = Vector2.one;
        text.rectTransform.anchoredPosition = new Vector2(.5f, .5f);
        text.text = input.text;
        text.font = Resources.FindObjectsOfTypeAll<Font>()[0];
        text.fontSize = 14;
        text.color = Color.black;
        text.alignment = TextAnchor.MiddleCenter;
        text.transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, 1));
    }
}
