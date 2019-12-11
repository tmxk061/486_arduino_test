using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ConnectArduino : MonoBehaviour
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

    // Update is called once per frame
    private void OnMouseDown()
    {
        SetMeshMaterial(true);

      StartCoroutine( blockgroup.GetCode(true));
    }


    public void SetMeshMaterial(bool on)
    {
        if (on == true)
            MeshPrint.material = TurnOn;
        else if (on == false)
            MeshPrint.material = TurnOff;

    }
}
