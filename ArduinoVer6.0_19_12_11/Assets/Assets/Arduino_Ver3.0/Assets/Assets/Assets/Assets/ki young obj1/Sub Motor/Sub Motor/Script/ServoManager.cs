using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServoManager : MonoBehaviour
{

    public bool VccConnect = false;
    public bool GNDConnect = false;
    public bool DigitalConnect = false;
    private SubSpin sub;

    float distance = 10;
    public bool MouseClick = false;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 270, 0);
        sub = GetComponentInChildren<SubSpin>();
    }

    #region MouseDrag
    private void OnMouseDown()
    {
        distance = this.transform.position.z - Camera.main.transform.position.z;
    }

    private void OnMouseUp()
    {
        MouseClick = false;
    }

    void OnMouseDrag()
    {
        MouseClick = true;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance -= 10;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance += 10;
        }

        if (this.gameObject.layer == LayerMask.NameToLayer("Sensor"))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    Quaternion objRotation = Camera.main.transform.rotation;
        //    transform.rotation = objRotation;
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    Quaternion objRotation = Camera.main.transform.rotation;
        //    transform.rotation = objRotation;
        //}

    }
    #endregion

    // Update is called once per frame
    public void Run(float s)
    {
        sub.Run(s);
    }
}
