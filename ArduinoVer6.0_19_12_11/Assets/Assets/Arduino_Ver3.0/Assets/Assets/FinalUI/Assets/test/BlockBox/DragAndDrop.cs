using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IDropHandler
{
    private Outline outline;

    private void Start()
    {
        this.transform.localPosition = new Vector2(0, 100);

        outline = transform.Find("Image").gameObject.GetComponent<Outline>();
    }

    public void OnMouseDown()
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        outline.enabled = true;
        //outline.effectDistance.Set(2, 2);
    }

    public void OnDrop(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        outline.enabled = false;
        //outline.effectDistance.Set(0, 0);
    }
}