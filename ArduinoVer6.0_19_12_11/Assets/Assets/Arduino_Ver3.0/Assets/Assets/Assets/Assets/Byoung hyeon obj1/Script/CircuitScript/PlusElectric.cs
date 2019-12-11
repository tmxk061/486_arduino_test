using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusElectric : MonoBehaviour
{
    public float plusElectro = 0;
    public float Electro = 0;

    public GameObject Around;
    protected CircuitManager Circuit;
    protected LineManager Line;

    private void OnTriggerStay(Collider other)
    {
        Line = other.gameObject.GetComponentInParent<LineManager>();
        Circuit = FindObjectOfType<CircuitManager>();

        //전력의 값을 바꾼다.
        if (other.tag == "Line" && Line.ConnectSuccese == 1)
        {
            plusElectro = 1;
            Electro = 3.0f;
            Line.Electro = Electro;
            Circuit.ConnectElectro = Electro;
            Around.SetActive(false);
        }
        if (other.tag == "Line" && Line.ConnectSuccese == 0)
        {
            plusElectro = 0;
            Electro = 0;
            Line.Electro = Electro;
            Circuit.ConnectElectro = Electro;
            Around.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Line = other.gameObject.GetComponentInParent<LineManager>();

        if (other.tag == "Line")
        {
            plusElectro = 0;
            Electro = 0;
            Circuit.ConnectElectro = Electro;
            Around.SetActive(true);
        }
    }
}
