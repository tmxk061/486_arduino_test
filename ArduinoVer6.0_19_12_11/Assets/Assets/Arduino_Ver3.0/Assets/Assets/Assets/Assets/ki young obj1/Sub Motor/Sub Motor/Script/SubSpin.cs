using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubSpin : MonoBehaviour
{
    public bool VccConnect = false;
    public bool GNDConnect = false;
    public bool DigitalConnect = false;

    public GameObject parent;
    public int VccPower = 0;

    public float direction = 1f; // initial direction 
    public float speed = 150f; // speed of rotation 
    public float work;
    ServoManager servo;
    // Start is called before the first frame update
    void Start()
    {
        servo = GetComponentInParent<ServoManager>();

        work = 0f;
        
        vec = Vector3.zero;
        lotateSpeed = 100.0f;
    }

    

   
    private Vector3 vec;
    private float lotateSpeed;

    

    private void Update()
    {
        VccConnect = servo.VccConnect;
        GNDConnect = servo.GNDConnect;
        DigitalConnect = servo.DigitalConnect;
       

        if (VccConnect && GNDConnect && DigitalConnect)
        {
            if (vec.y != work)
            {
                if (vec.y <= work)
                {
                    vec.y += Time.deltaTime * lotateSpeed;
                    transform.localRotation = Quaternion.Euler(vec);

                    if (work < vec.y + 0.5f && work > vec.y - 0.5f)
                    { vec.y = work; }


                }
                else if (vec.y >= work)
                {
                    vec.y -= Time.deltaTime * lotateSpeed;
                    transform.localRotation = Quaternion.Euler(vec);

                    if (work < vec.y + 0.5f && work > vec.y - 0.5f)
                    { vec.y = work; }

                }
               
            }
        }
    }

    public void Run(float s)
    {
        if(s<=180f && s>=0f)
        {
            work = s;
        }
    }
   
}