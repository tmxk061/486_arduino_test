using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    Ray ray;
    RaycastHit[] hitArray;
    public new Light light;


    float radius = 15f;
    public Vector3 ForwardDirection;
    public Vector3 direct;
    public float angle;

    public bool LightOn;//빛 닿았을 때

    // Start is called before the first frame update
    void Start()
    {
        LightOn = false;
        angle = 0;
        light = GetComponent<Light>();
        ForwardDirection = transform.TransformDirection(0, 0, 1);
    }

    private void Update()
    {
        hitArray = Physics.SphereCastAll(
               this.transform.position,
               radius,
               ForwardDirection,
               light.range);


        for (int i = 0; i < hitArray.Length; i++)
        {
            StartCoroutine("Corrutine", i);
        }

        ForwardDirection = transform.TransformDirection(0, 0, 1);
    }


    IEnumerator Corrutine(int i)
    {
        angle = Vector3.Angle(this.transform.forward, direct);
        direct = hitArray[i].transform.position - this.transform.position;

        if (hitArray[i].transform.tag == "LightObject")
        {
            if (angle <= 12.5f && this.gameObject.GetComponent<Light>().enabled == true)
            {
                LightOn = true;
                hitArray[i].transform.GetComponent<IllValue>().hitLight = true;
                hitArray[i].transform.GetComponent<IllValue>().lightObject = this.gameObject;
                hitArray[i].transform.GetComponent<IllValue>().light2 = this.gameObject.GetComponent<Light>();
            }
            else
            {
                LightOn = false;
                hitArray[i].transform.GetComponent<IllValue>().hitLight = false;
                hitArray[i].transform.GetComponent<IllValue>().lightObject = null;
                hitArray[i].transform.GetComponent<IllValue>().light2 = null;
            }


        }
        yield return new WaitForSeconds(3f);
    }
}