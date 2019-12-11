using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBread : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>().transform.rotation = Quaternion.Euler(-90, -90, 0);
    }
}
