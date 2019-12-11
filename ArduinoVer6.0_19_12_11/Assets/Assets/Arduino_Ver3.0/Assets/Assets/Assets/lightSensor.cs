using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSensor : MonoBehaviour
{
    // Start is called before the first frame update
    public IllValue value;
    float distance = 10;
    public bool MouseClick = false;

    void Start()
    {
        value = GetComponentInChildren<IllValue>();
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

        /*if (Input.GetKey(KeyCode.Q))
        {
            Quaternion objRotation = Camera.main.transform.rotation;
            transform.rotation = objRotation;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Quaternion objRotation = Camera.main.transform.rotation;
            transform.rotation = objRotation;
        }*/

    }
    #endregion

    public void Run()
    {
        value.Run();
    }
    public void Pause()
    {

        value.Pause();

    }
    public float Read()
    {

        return value.Read();
    }


}