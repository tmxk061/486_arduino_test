using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMove : MonoBehaviour
{
    public Vector2 shader;
    float Target_offset;


    // Update is called once per frame
    void Update()
    {
        Target_offset += Time.deltaTime * 0.05f;
        this.GetComponent<Renderer>().material.mainTextureOffset = new Vector2( Target_offset, Target_offset);

        this.transform.position = new Vector3(
           330
         , Mathf.PingPong(Time.time * 2, 10)
         , 500);
    }
}
