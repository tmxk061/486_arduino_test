using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncCodeButton : MonoBehaviour
{
    [SerializeField]
    StartBlock blockgroup;

    [SerializeField]
    public Material TurnOn;

    [SerializeField]
    public Material TurnOff;

    private MeshRenderer MeshPrint;
    // Start is called before the first frame update
    void Start()
    {
        MeshPrint = this.gameObject.GetComponent<MeshRenderer>();
        blockgroup = GameObject.FindWithTag("Block").GetComponent<StartBlock>();
    }

    private void OnMouseDown()
    {
       StartCoroutine(blockgroup.GetSyncCode(true));
    }
}
