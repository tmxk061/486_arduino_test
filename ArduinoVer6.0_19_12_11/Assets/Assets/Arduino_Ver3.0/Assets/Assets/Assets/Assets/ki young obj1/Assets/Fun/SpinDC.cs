using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDC : MonoBehaviour
{
    public float speed = 25;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            tr.transform.Rotate(Vector3.up * speed);
        }
        if (Input.GetButton("Fire2"))
        {
            tr.transform.Rotate(Vector3.down * speed);
        }
    }
}