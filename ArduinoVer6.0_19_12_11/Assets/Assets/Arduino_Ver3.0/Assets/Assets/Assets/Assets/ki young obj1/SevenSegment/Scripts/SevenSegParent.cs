using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenSegParent : MonoBehaviour
{
    /*  아두이노 보드 용 연결
    private bool SevensegPlus = false;
    private bool SevensegMin = false;
    private bool SevensegDig = false;
    private int SevensegVccPower = 0;
    */

    public Renderer SevenSegmentParent;
    public SevenSegChild[] Children;

    // Start is called before the first frame update
    private void Start()
    {
        SevenSegmentParent = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Run(3);
    }

    void Run(int power)
    {
        /*if (Children[0].Connect == false)
        {
            Children[0].Color.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            Children[0].Color.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (Children[1].Connect == false)
        {
            Children[1].Color.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            Children[1].Color.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (Children[2].Connect == false)
        {
            Children[2].Color.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            Children[2].Color.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (Children[3].Connect == false)
        {
            Children[3].Color.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            Children[3].Color.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (Children[4].Connect == false)
        {
            Children[4].Color.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            Children[4].Color.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (Children[5].Connect == false)
        {
            Children[5].Color.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            Children[5].Color.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (Children[6].Connect == false)
        {
            Children[6].Color.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            Children[6].Color.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        if (Children[7].Connect == false)
        {
            Children[7].Color.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else
        {
            Children[7].Color.GetComponent<MeshRenderer>().material.color = Color.red;
        }*/

    }
}
