using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Canvas;
    bool active = false;

    private void OnMouseDown()
    {
        if (active == false)
        {
            Canvas.SetActive(true);
            active = true;
        }
        else if(active == true)
        {
            Canvas.SetActive(false);
            active = false;
        }
    }
}
