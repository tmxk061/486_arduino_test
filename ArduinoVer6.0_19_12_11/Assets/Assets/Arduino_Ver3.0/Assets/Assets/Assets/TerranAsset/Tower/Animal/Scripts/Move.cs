using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    int patten = 0;
    public float speed = 3f;
    public Vector3 fenceRightTop;
    public Vector3 fenceLeftDown;

    Quaternion quaternion;
    Vector3 movement;
    Animator animation;
    Rigidbody rigidbody;


    private void OnEnable()
    {
        StartCoroutine(MoveAnyWay());
        quaternion = Quaternion.identity;
        movement = Vector3.forward * Time.deltaTime * speed;
        animation = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (patten)
        {
            case 0:
                animation.SetInteger("Walk", patten);
                rigidbody.transform.Translate(Vector3.zero);
                return;
            case 1:
                animation.SetInteger("Walk", patten);

                /*//+로 올라가는 값
                if (rigidbody.transform.localPosition.x >= fenceRightTop.x)
                { quaternion = Quaternion.Euler(-5f, 0, 0); }
                if (rigidbody.transform.localPosition.z >= fenceRightTop.z)
                { quaternion = Quaternion.Euler(0,0,-5f); }
                //-로 내려가는 값
                if (rigidbody.transform.localPosition.x <= fenceLeftDown.x)
                { quaternion = Quaternion.Euler(5f, 0, 0); }
                if (rigidbody.transform.localPosition.z <= fenceLeftDown.z)
                { quaternion = Quaternion.Euler(0, 0, 5f); }*/

                /*else
                {
                    movement = Vector3.forward * Time.deltaTime * speed;
                }*/
                //this.transform.rotation = quaternion;
                rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, quaternion, 3 * Time.deltaTime);
                rigidbody.transform.Translate(movement);

                return;

        }
    }

    IEnumerator MoveAnyWay()
    {
        yield return new WaitForSeconds(Random.Range(1f,3f));
        patten = Random.Range(0, 2);
        quaternion = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        StartCoroutine(MoveAnyWay());
    }
}
