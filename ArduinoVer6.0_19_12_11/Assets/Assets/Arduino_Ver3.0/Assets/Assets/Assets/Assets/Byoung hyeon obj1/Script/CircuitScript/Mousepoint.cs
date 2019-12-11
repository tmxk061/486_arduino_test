using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class Mousepoint : MonoBehaviour
{

    

    public GameObject MakeLine;

    public new Camera camera;
    public RaycastHit hit;
    public Ray ray;
    public Vector3 pointting;//위치를 가져옴
    public bool MouseChecking;//마우스 클릭확인

    private static Mousepoint instance;
    private static GameObject container;

    int CameraState = 1;

    private void Start()
    {
        MakeLine = Resources.Load("LineManager") as GameObject;

        camera = Camera.main;
        MouseChecking = false;
    }

    // Update is called once per frame
    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        float rayLength = 500f;
        int floorMask = 1;

        //오브젝트에 레이가 걸릴 때
        if (Physics.Raycast(ray, out hit, rayLength, floorMask))
        {
            Debug.DrawLine(ray.origin, hit.transform.position, Color.red);

            if (hit.transform.tag == "Arround" && Input.GetMouseButtonDown(0))
            {
                    //MouseChecking = true;
                    pointting = hit.transform.position;
              
                    //TestBox.transform.position = hit.transform.position;
            }

        }

        //화면 퀵 전환
        if (Input.GetKey(KeyCode.Tab))
        {
            if (CameraState == 1)
            {
                this.transform.position = new Vector3(-215, 162.5f, -104);
                this.transform.rotation = Quaternion.Euler(0, -90, 0);

                CameraState = 2;

                System.Threading.Thread.Sleep(500);
            }
            else if (CameraState == 2)
            {
                this.transform.position = new Vector3(24, 135, -34);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);

                CameraState = 3;

                System.Threading.Thread.Sleep(500);
            }
            else if (CameraState == 3)
            {
                this.transform.position = new Vector3(-155, 162.5f, 315);
                this.transform.rotation = Quaternion.Euler(0, -90, 0);

                CameraState = 4;

                System.Threading.Thread.Sleep(500);
            }
            else if (CameraState == 4)
            {
                this.transform.position = new Vector3(50, 160, -92);
                this.transform.rotation = Quaternion.Euler(0, 90, 0);

                CameraState = 5;

                System.Threading.Thread.Sleep(500);
            }
            else if (CameraState == 5)
            {
                this.transform.position = new Vector3(-105, 285, 58);
                this.transform.rotation = Quaternion.Euler(0, -90, 0);

                CameraState = 1;

                System.Threading.Thread.Sleep(500);
            }
        }

        //Move();
    }

    private void Move()
    {
        if (GameManager.RunBlock == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(Vector3.forward * 100 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(Vector3.back * 100 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(Vector3.right * 100 * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(Vector3.left * 100 * Time.deltaTime);
            }
            //if (Input.GetKey(KeyCode.Space))
            //{
            //    this.transform.Translate(Vector3.up * 100 * Time.deltaTime);
            //}
            //if (Input.GetKey(KeyCode.V))
            //{
            //    this.transform.Translate(Vector3.down * 100 * Time.deltaTime);
            //}
            //if (Input.GetKey(KeyCode.Q))
            //{
            //    this.transform.Rotate(new Vector3(0, -30, 0) * Time.deltaTime);
            //}
            //if (Input.GetKey(KeyCode.E))
            //{
            //    this.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
            //}
            
        }
    }

    public static Mousepoint MouseInstance()
    {
        if (!instance)
        {
            container = new GameObject();
            container.name = "CircuitManager";
            instance = container.AddComponent(typeof(Mousepoint)) as Mousepoint;
        }
        return instance;
    }


}
