using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSub : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        isLotation = false;
        isReverse = true;
        vec = Vector3.zero;
        lotateSpeed = 100.0f;
    }

    // Update is called once per frame
    public float direction = 1f; // initial direction 
    public float speed = 150f; // speed of rotation 

    void Update()
    {


        //float angle = transform.eulerAngles.z;
        //if (angle > 180f) angle -= 360f;

        //if ((angle < -55f) || (angle > 55f)) direction *= -1f; // reverse direction (toggles between 1 & -1) 

        //transform.Rotate(0, 0, speed * direction * Time.deltaTime);



        //float direction = 1f; // initial direction 
        //float speed = 150f; // speed of rotation 

        //float angle = transform.eulerAngles.z;

        //if (angle > 180f) angle -= 360f;



        //if ((angle < -55f) || (angle > 55f)) direction *= -1f; // reverse direction (toggles between 1 & -1) 

        //transform.Rotate(new Vector3(0, 1, 0), speed * direction * Time.deltaTime);
    }

    public bool isLotation;
    public bool isReverse;
    private Vector3 vec;
    private float lotateSpeed;

    private void LateUpdate()
    {

        if (isLotation)
        {
            if (isReverse) vec.y += Time.deltaTime * lotateSpeed;
            else vec.y -= Time.deltaTime * lotateSpeed;

            if (vec.y >= 90.0f) isReverse = false;
            else if (vec.y <= -90.0f) isReverse = true;

            transform.localRotation = Quaternion.Euler(vec);
        }
    }
}
