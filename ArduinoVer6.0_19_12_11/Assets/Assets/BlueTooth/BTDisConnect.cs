using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTDisConnect : MonoBehaviour
{

    public BTConnect BT;
    // Start is called before the first frame update

    private void Start()
    {
        BT= GameObject.Find("BlueToothConnect").GetComponent<BTConnect>();
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        BT.BtnDisConnect();
    }
}
