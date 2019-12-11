using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;

    public float rotateSpeed = 5f;

    public float cameraRotationLimit = 80f;

    private Vector3 rotation = Vector3.zero;
    private float cameraRotation = 0f;
    private float currentCameraRotation = 0f;

    void Update()
    {
        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");

        rotation = new Vector3(0f, yRot, 0f) * rotateSpeed; //x
        cameraRotation = xRot * rotateSpeed; //y (카메라만 위로 돌아감)

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameManager.lux = 500;
        //    Debug.Log(GameManager.lux);
        //}
    }

    void FixedUpdate() //Movement Rotation
    {
        if (GameManager.RunBlock == false)
        {
            PreformRotation();
            Move();
        }
    }

    void PreformRotation() //X, Y회전
    {

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            currentCameraRotation -= cameraRotation;
            currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);
            cam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0f, 0f);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, 100 * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, 100 * Time.deltaTime * -1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(100 * Time.deltaTime * -1, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(100 * Time.deltaTime, 0, 0));
        }

    }
}
