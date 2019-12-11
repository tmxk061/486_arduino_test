using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverArround : MonoBehaviour
{
    public GameObject MakeLine;
    public Mousepoint mousepoint;

    //이곳에서 선을 만들어준다.
    private void Start()
    {
        MakeLine = Resources.Load("LineManager") as GameObject;
        mousepoint = Camera.main.GetComponent<Mousepoint>();
    }

    private void Update()
    {
        if (MakeLine == false)
        {
            MakeLine = Resources.Load("LineManager") as GameObject;
        }
    }

    private void OnMouseDown()
    {
        if (mousepoint.MouseChecking == false)
        {
            mousepoint.MouseChecking = true;
            MakeLine = (GameObject)Instantiate(MakeLine, transform.position, this.gameObject.transform.rotation) as GameObject;
            MakeLine.GetComponentInChildren<line>().gameObject.GetComponent<LineRenderer>().material.color = Random.ColorHSV();

        }
        else
            mousepoint.MouseChecking = false;

    }


    private void OnMouseEnter()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnDisable()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }


}
