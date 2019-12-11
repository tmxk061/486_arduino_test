using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartBlockScript : MonoBehaviour, IDragHandler, IDropHandler
{
    private Outline outline;

    void Start()
    {
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
