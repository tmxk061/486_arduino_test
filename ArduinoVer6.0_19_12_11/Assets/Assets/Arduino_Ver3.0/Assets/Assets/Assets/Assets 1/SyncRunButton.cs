using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncRunButton : MonoBehaviour
{
    [SerializeField]
    StartBlock blockgroup;

    [SerializeField]
    public Material TurnOn;

    [SerializeField]
    public Material TurnOff;

    [SerializeField]
    public Material ExceptionMaterial;

    private MeshRenderer MeshPrint;

    private bool First = true;

    // Start is called before the first frame update
    void Start()
    {
        MeshPrint = this.gameObject.GetComponent<MeshRenderer>();
        blockgroup = GameObject.FindWithTag("Block").GetComponent<StartBlock>();
    }

    


    private void OnMouseDown()
    {

            if (First == true)
            {
                GameManager.AgainSyncRun = true;
                GameManager.GetPort();
                StartCoroutine(blockgroup.SyncRun(true));
                MeshPrint.material = TurnOn;
                First = false;
            }
    }


    public void blockgrouprun()
    {
      
        StartCoroutine(blockgroup.SyncRun(true));

    }

    public void blockgrouppause()
    {

        MeshPrint.material = TurnOff;
        First = true;
    }

    public void blockgroupException()
    {

        MeshPrint.material = ExceptionMaterial;

    }
}
