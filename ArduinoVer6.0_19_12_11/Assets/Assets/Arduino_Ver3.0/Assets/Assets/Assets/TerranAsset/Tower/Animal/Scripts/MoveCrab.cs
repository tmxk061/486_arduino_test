using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrab : MonoBehaviour
{
    int patten = 0;
    public float speed = 3f;
    public Vector3 UpRightFence;
    public Vector3 DownLeftFence;

    Vector3 movement;
    Animator animation;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(MoveAnyWay());
        movement = Vector3.zero;
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
                movement = Vector3.zero;
                this.transform.Translate(movement);
                return;
            case 1:
                animation.SetInteger("Walk", patten);
                if (this.transform.position.z >= UpRightFence.z)
                {
                    patten = 2;
                    return;
                }
                movement = Vector3.forward * Time.deltaTime * speed;
                this.transform.Translate(movement);
                return;
            case 2:
                animation.SetInteger("Walk", patten);
                if (this.transform.position.z <= DownLeftFence.z)
                {
                    patten = 1;
                    return;
                }
                movement = Vector3.back * Time.deltaTime * speed;
                this.transform.Translate(movement);
                return;
        }
    }

    IEnumerator MoveAnyWay()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        patten = Random.Range(0, 3);
        StartCoroutine(MoveAnyWay());
    }
}
