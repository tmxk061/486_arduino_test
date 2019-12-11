using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TemperToggle
{
    DHT11, RHT03, SHT15, CustomTemp,
}

public class TempHumiParent : MonoBehaviour
{
    public bool GNDConnect;
    public bool VCCConnect;
    public bool DigitalConnect { get; set; }

    public bool StartRun = false;
    public GameObject Parent;

    public TemperToggle temperToggle = TemperToggle.DHT11;

    public DropDownMenu rainscript;

    [Header("온도")]
    [Range(0f, 50.0f)]
    public float temperature = 0f;//온도

    [Header("비의 량")]
    [Range(20.0f, 90.0f)]
    public float temp = 20;//습도

    [Header("습도(%)")]
    public float Data = 0f;

    private List<float> temphumi = new List<float>();

    private float distance = 10;
    public bool MouseClick = false;

    public int tempminval = 0;
    public int tempmaxval = 100;
    public int dataminval = 0;
    public int datamaxval = 100;

    // Start is called before the first frame update
    private void Start()
    {
        GNDConnect = false;
        VCCConnect = false;
        DigitalConnect = false;
        Parent = gameObject.GetComponent<GameObject>();
        rainscript = GameObject.FindGameObjectWithTag("DropDownMenu").GetComponent<DropDownMenu>();
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

    private void OnMouseDrag()
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

    #endregion MouseDrag

    // Update is called once per frame

    private IEnumerator Work()
    {
        Debug.Log("Work");

        //for (int i = 0; i < temphumi.Count; i++)
        //{
        //    temphumi.Remove(i);
        //}

        temphumi.Clear();

        if (GNDConnect == true && VCCConnect == true && DigitalConnect == true)
        {
            if (rainscript.tem < 0)
            {
                temperature = 0;
            }
            temperature = rainscript.tem;
            Data = rainscript.hum;

            switch (temperToggle)
            {
                case TemperToggle.DHT11:
                    if (temperature < 0)
                        temperature = 0;
                    else if (temperature > 50)
                        temperature = 50;

                    if (Data < 20)
                        Data = 20;
                    else if (Data > 95)
                        Data = 95;
                    break;

                case TemperToggle.RHT03:
                    if (temperature < -40)
                        temperature = -40;
                    else if (temperature > 80)
                        temperature = 80;

                    if (Data < 0)
                        Data = 0;
                    else if (Data > 100)
                        Data = 100;
                    break;

                case TemperToggle.SHT15:
                    if (temperature < -40)
                        temperature = -40;
                    else if (temperature > 125)
                        temperature = 125;

                    if (Data < 0)
                        Data = 0;
                    else if (Data > 100)
                        Data = 100;
                    break;

                case TemperToggle.CustomTemp:
                    if (temperature < tempminval)
                        temperature = tempminval;
                    else if (temperature > tempmaxval)
                        temperature = tempmaxval;

                    if (Data < dataminval)
                        Data = dataminval;
                    else if (Data > datamaxval)
                        Data = datamaxval;
                    break;
            }
        }

        temphumi.Add(temperature); //온도

        temphumi.Add(Data); // 습도

        yield return null;

        //if (StartRun == true) StartCoroutine(Work());
    }

    public List<float> Read()
    {
        StartRun = true;

        StartCoroutine(Work());

        return temphumi;
    }

    public void Run()
    {
        //rainscript.Constant = temp;
        StartRun = true;

        StartCoroutine(Work());
    }

    public void Pause()
    {
        StartRun = false;
    }
}