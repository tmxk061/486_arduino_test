using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunObject : MonoBehaviour
{
    public new Light light;

    private void Start()
    {
        light = gameObject.GetComponent<Light>();
    }
}
