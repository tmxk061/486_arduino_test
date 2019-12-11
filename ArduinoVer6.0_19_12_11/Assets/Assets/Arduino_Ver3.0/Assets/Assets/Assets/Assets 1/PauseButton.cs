using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    RunButton runbtn;

    
    // Start is called before the first frame update
    public bool RunOn = true;
    ControlArduino control;

    //animation
    public UnityEngine.UI.Toggle AllLightToggle;
    public UnityEngine.UI.Toggle CenterLightToggle;
    public Animator PannelDown;
    [SerializeField]
    public Material TurnOn;

    [SerializeField]
    public Material TurnOff;

    private MeshRenderer MeshPrint;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.FindWithTag("Arduino").GetComponent<ControlArduino>();
        runbtn = GameObject.FindWithTag("RunBlock").GetComponent<RunButton>();
        MeshPrint = this.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
       
        //====================================
        PannelDown.SetBool("PannelMove", false);
        AllLightToggle.isOn = true;
        CenterLightToggle.isOn = false;
        //====================================
        runbtn.RunOn = false;

        control.PauseAll();

        GameManager.runbtn.SetMeshMaterial(false);
    }

    public void SetMeshMaterial(bool on)
    {
        if (on == true)
            MeshPrint.material = TurnOn;
        else if (on == false)
            MeshPrint.material = TurnOff;

    }
}
