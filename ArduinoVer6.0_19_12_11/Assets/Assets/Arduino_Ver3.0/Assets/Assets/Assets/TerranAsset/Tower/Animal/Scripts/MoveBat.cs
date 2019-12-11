using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBat : MonoBehaviour
{

    protected Vector3 mo;
    Quaternion rotation;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
        mo = new Vector3(Random.Range(-5, 5) * Time.deltaTime, Random.Range(-5, 5) * Time.deltaTime, Random.Range(-5, 5) * Time.deltaTime);
        rotation = Quaternion.LookRotation(mo);
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.transform.position.z <= 16.0f)
        {
            mo = new Vector3(0,0
                , -5 * Time.deltaTime * 4f);
            rotation = Quaternion.LookRotation(mo);
            rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, 3 * Time.deltaTime);

        }
        this.transform.position -= mo;
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, 3 * Time.deltaTime);
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
        mo = new Vector3(
            Random.Range(-5, 5) * Time.deltaTime * 4f
            , Random.Range(-5, 5) * Time.deltaTime * 4f
            , Random.Range(-5, 5) * Time.deltaTime * 4f
            );
        rotation = Quaternion.LookRotation(mo);
        StartCoroutine(Move());
    }
}
