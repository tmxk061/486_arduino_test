using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DC : MonoBehaviour
{
    public bool VccConnect {  private get;  set; }
    public bool GNDConnect {  private get;  set; }
    public bool DigitalConnectPlus { get; set; }
    public bool DigitalConnectMinus { get; set; }

    public int VccPower = 0;
    public int Speed = 10;
    public bool OUT1 = false;
    public bool OUT2 = false;
    public bool OUT3 = false;
    public bool OUT4 = false;
    public bool direction = false;
    public GameObject parant;
    public int power=10;
    public Transform[] Child { get; set; }
    public bool l298connect1 = false;
    public bool l298connect2 = false;
    public bool RunOn = false;
    public bool First = false;

    float distance = 10;
    public bool MouseClick = false;


    private List<IEnumerator> coroutinelist = new List<IEnumerator>();
    // Start is called before the first frame update
    void Start()
    {
        VccConnect = false;
        GNDConnect = false;
        DigitalConnectPlus = false;
        DigitalConnectMinus = false;



        Child = this.gameObject.GetComponentsInChildren<Transform>();
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
    }
    #endregion


    public void Run()
    {


        // coroutinelist.Add(w);


        if (First == false)
        {
            RunOn = true;

            First = true;
            StartCoroutine(Work());
            


        }
       

    }
  

    IEnumerator Work()
    {
      
        
        if ((l298connect1 == true) && (l298connect2 == true))
        {
                if (direction == true)
                {
                    Child[1].transform.Rotate(Vector3.up * power);
                }
                else if (direction == false)
                {
                    Child[1].transform.Rotate(Vector3.down * power);
                }


            }

        yield return new WaitForSeconds(0.3f);
      

        if (RunOn == true) StartCoroutine(Work());

    }
    public void Work2()
    {

        if ((l298connect1 == true) && (l298connect2 == true))
        {
            if (direction == true)
            {
                Child[0].transform.Rotate(Vector3.up * power);
            }
            else if (direction == false)
            {
                Child[0].transform.Rotate(Vector3.down * power);
            }


        }

        if (RunOn == true) Work2();
    }
    public void Pause()
    {
        RunOn = false;
        First = false;
        StopCoroutine(Work());
            
        
    }


}
