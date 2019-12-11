using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTDSendData : MonoBehaviour
{
    public BTConnect BT;
    // Start is called before the first frame update
    [SerializeField]
    StartBlock blockgroup;

    private MeshRenderer MeshPrint;
    private void Start()
    {
        BT = GameObject.Find("BlueToothConnect").GetComponent<BTConnect>();
        MeshPrint = this.gameObject.GetComponent<MeshRenderer>();
        blockgroup = GameObject.FindWithTag("Block").GetComponent<StartBlock>();
    }
    // Start is called before the first frame update

   
    private void OnMouseDown()
    {
        //  BT.BtnSendData("work");
        StartCoroutine(blockgroup.GetBtCode(true));
    }
}
