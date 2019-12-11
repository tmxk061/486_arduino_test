using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenSegChild : MonoBehaviour
{
    SevenSegChildChild ChildChild;

    public MeshRenderer SegmentColor;  //연결 된 color
    public GameObject Leg;  //연결 된 다리

    public bool DigitalConnect;
    public bool Connect;    //자식의 연결 여부
    public int Signal;
    


    // Start is called before the first frame update
    void Start()
    {
        SegmentColor = transform.GetChild(1).GetComponent<MeshRenderer>();
        ChildChild = gameObject.GetComponentInChildren<SevenSegChildChild>();

        DigitalConnect = false;
        Connect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ChildChild.Connect == true  && DigitalConnect == true)
        {
            SegmentColor.material.color = Color.red;
            Connect = true;
        }
        else
        {
            SegmentColor.material.color = Color.white;
            Connect = false;
        }
    }
}
