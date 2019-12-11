using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Canvas can;

    // Start is called before the first frame update
    void Start()
    {
        can = GameObject.Find("BlockCodingCanvas").GetComponent<Canvas>();
    }

    public void ButtonClickEvent()
    {
        can.renderMode = RenderMode.WorldSpace;

        can.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 10);
        can.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - 30f);
    }
}
