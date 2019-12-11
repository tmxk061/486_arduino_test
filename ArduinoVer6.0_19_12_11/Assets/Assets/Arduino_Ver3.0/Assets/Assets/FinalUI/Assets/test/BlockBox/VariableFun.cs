using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VariableFun : MonoBehaviour, IDragHandler, IDropHandler
{
    Text childtext;

    private Outline outline;

    void Start()
    {
        this.transform.localPosition = new Vector2(0, 100);

        CreateVariableBlockScript script = GameObject.Find("BlockCodingCanvas").transform.Find("InputField (1)").GetComponent<CreateVariableBlockScript>();

        this.name = script.SaveName + "Block";

        childtext = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();

        childtext.text = script.SaveName;

        outline = transform.Find("Image").gameObject.GetComponent<Outline>();
    }

    public void OnMouseDown()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        outline.enabled = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        outline.enabled = false;
    }
}