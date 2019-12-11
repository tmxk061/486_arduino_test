using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundParent : MonoBehaviour
{
    /* 아두이노 보드 용 연결
    private bool SoundPlus = false;
    private bool SoundMin = false;
    private bool SoundDig = false;
    private int SoundVccPower = 0;
    */

    public bool GNDConnect;
    public bool VCCConnect;
    public bool DigitalConnect;

    public float Data { get; set; }

    AudioSource audioSource;

    public GameObject Parent;
    float distance = 10;
    public bool MouseClick = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

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


    public void Run()
    {
        if (GNDConnect == true && VCCConnect == true && DigitalConnect==true)
        {
            audioSource.Play();
        }
    }
    public void Pause()
    {
        audioSource.Pause();
    }
}
