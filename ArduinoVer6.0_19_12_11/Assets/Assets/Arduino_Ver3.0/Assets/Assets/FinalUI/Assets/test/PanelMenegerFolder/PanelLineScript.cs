using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLineScript : MonoBehaviour
{
    //테두리 구분
    private float AlphaThreshold = 0.1f;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.alphaHitTestMinimumThreshold = AlphaThreshold;
    }
}
