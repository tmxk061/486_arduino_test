using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public LineManager Manager;
    public GameObject EndPoint;

    LineRenderer lr;
    Vector3 distance;
    RaycastHit rayHit;
    Ray ray;

    public bool Connect = false;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.25f;
        lr.endWidth = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, GetComponentInParent<Transform>().position);

        lr.SetPosition(1, new Vector3(
            EndPoint.transform.position.x,
            EndPoint.transform.position.y,
            EndPoint.transform.position.z));

        distance = new Vector3
            (lr.GetPosition(1).x - lr.GetPosition(0).x, 
            lr.GetPosition(1).y - lr.GetPosition(0).y, 
            lr.GetPosition(1).z - lr.GetPosition(0).z);

        ray = new Ray(transform.position, transform.forward);
        ray.origin = this.transform.position;//시작값
        ray.direction = new Vector3(lr.GetPosition(1).x, lr.GetPosition(1).y, lr.GetPosition(1).z);

        if (Physics.Raycast(ray,out rayHit,5) && Connect == true)
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }


    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin,distance,Color.red);
    }

}
