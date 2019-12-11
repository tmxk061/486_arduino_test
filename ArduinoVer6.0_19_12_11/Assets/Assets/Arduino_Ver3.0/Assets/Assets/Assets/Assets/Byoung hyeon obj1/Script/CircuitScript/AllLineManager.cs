using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLineManager : MonoBehaviour
{
    public GameObject MakeLine;

    private void Start()
    {
        MakeLine = Resources.Load("LineManager") as GameObject;
    }

    public void OnButtonDown()
    {
        MakeLine = (GameObject)Instantiate(MakeLine,
             gameObject.transform.localPosition
            , Quaternion.identity) as GameObject;

        MakeLine.transform.parent = this.gameObject.transform;
        MakeLine.transform.position = new Vector3(0, 0, 0);
        MakeLine.GetComponentInChildren<line>().gameObject.GetComponent<LineRenderer>().material.color = Random.ColorHSV();

    }

    public void OnDeleteButtonDown()
    {
        int i = this.gameObject.transform.childCount;

        for (int j = 0; j < i; j++)
        {
            Destroy(this.gameObject.transform.GetChild(j).gameObject);
            MakeLine = Resources.Load("LineManager") as GameObject;

        }
    }
}
