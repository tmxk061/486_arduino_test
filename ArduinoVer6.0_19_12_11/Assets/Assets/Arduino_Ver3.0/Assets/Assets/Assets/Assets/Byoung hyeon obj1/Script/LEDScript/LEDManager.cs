using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEDManager : Sensor
{
    public bool VccConnect=false;//plus
    public bool GNDConnect=false;//minus
    public bool DigitalConnect=false;//값 반환

    public int power=0;

    public GameObject parant;
    public GameObject AllObject;

    public float Electro = 0;
    public LightScript lux;
  
    MeshRenderer mesh;

    float distance = 10;
    public bool MouseClick = false;

    private void Start()
    {
        
        mesh = gameObject.GetComponent<MeshRenderer>();

        lux=GetComponentInChildren<LightScript>();
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

    public override void Run()
    {

        if ((DigitalConnect == true) && (GNDConnect == true))
        {
            lux.Run();
        }
  
    }

    public override void Pause()
    {
        lux.Pause();
    }
}
