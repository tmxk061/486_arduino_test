using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        LoadData();
    }

    [ExecuteInEditMode]
    public List<GameObject> SensorList = new List<GameObject>();
    public GameObject genSensor = null;
    public GameObject childSensor = null;
    
    public void LoadData()
    {
        var save = GameObject.Find("SaveButton").GetComponent<SaveButton>();

        GameObject targetSensor = null;
        genSensor = null;
        int length = PlayerPrefs.GetInt("SENSOR_LENGTH");

        float x, y, z;
        float rx, ry, rz;

        Vector3 pos;
        Quaternion rot;

        for (int i = 0; i < length; i++)
        {
            string sensorName = PlayerPrefs.GetString("SENSOR_" + i.ToString());

            switch (sensorName)
            {
                case "Temperature-HumiditySensor(Clone)":
                    targetSensor = Resources.Load<GameObject>("Temperature-HumiditySensor");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "Ultrasonic Sensor(Clone)":
                    targetSensor = Resources.Load<GameObject>("Ultrasonic Sensor");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "Sub Motor(Clone)":
                    targetSensor = Resources.Load<GameObject>("Sub Motor");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "SoundSensor(Clone)":
                    targetSensor = Resources.Load<GameObject>("SoundSensor");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "IlluminanceSensor(Clone)":
                    targetSensor = Resources.Load<GameObject>("IlluminanceSensor");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "L298N(Clone)":
                    targetSensor = Resources.Load<GameObject>("L298N");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "DC Motor(Clone)":
                    targetSensor = Resources.Load<GameObject>("DC Motor");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "LED Senser(Clone)":
                    targetSensor = Resources.Load<GameObject>("LED Senser");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "LED Senser(1)(Clone)":
                    targetSensor = Resources.Load<GameObject>("LED Senser(1)");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "LED Senser(2)(Clone)":
                    targetSensor = Resources.Load<GameObject>("LED Senser(2)");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;
                case "LED Senser(3)(Clone)":
                    targetSensor = Resources.Load<GameObject>("LED Senser(3)");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);

                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");
                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    genSensor.transform.position = pos;
                    break;

                case "LineManager(Clone)":
                    targetSensor = Resources.Load<GameObject>("LineManager");
                    genSensor = Instantiate(targetSensor);
                    SensorList.Add(genSensor);


                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");


                    pos = new Vector3(x, y, z);
                    rot = new Quaternion(rx, ry, rz, 0);
                    genSensor.transform.rotation = rot;
                    SensorList[i].transform.position = pos;
                    Debug.Log(SensorList.Count);

                    Debug.Log(SensorList[i].transform.position);


                    SensorList.Add(targetSensor.transform.GetChild(1).gameObject);
                    i++;
                    sensorName = PlayerPrefs.GetString("SENSOR_" + i.ToString());


                    // 좌표
                    x = PlayerPrefs.GetFloat(sensorName + i + "X");
                    y = PlayerPrefs.GetFloat(sensorName + i + "Y");
                    z = PlayerPrefs.GetFloat(sensorName + i + "Z");
                    rx = PlayerPrefs.GetFloat(sensorName + i + "RX");
                    ry = PlayerPrefs.GetFloat(sensorName + i + "RY");
                    rz = PlayerPrefs.GetFloat(sensorName + i + "RZ");

                    //childSensor = genSensor.transform.Find("End").gameObject;
                    childSensor = genSensor.transform.GetChild(1).gameObject;

                    childSensor.GetComponent<End>().savepos[0] = x;
                    childSensor.GetComponent<End>().savepos[1] = y;
                    childSensor.GetComponent<End>().savepos[2] = z;
                    childSensor.GetComponent<End>().savepos[3] = rx;
                    childSensor.GetComponent<End>().savepos[4] = ry;
                    childSensor.GetComponent<End>().savepos[5] = rz;

                    childSensor.GetComponent<End>().LoadLine = true;
                    Debug.Log(targetSensor.transform.GetChild(1).transform.localPosition);
                    break;

                    //case "End":

                    //    SensorList.Add(targetSensor.transform.GetChild(1).gameObject);

                    //    // 좌표
                    //    x = PlayerPrefs.GetFloat(sensorName + "X");
                    //    y = PlayerPrefs.GetFloat(sensorName + "Y");
                    //    z = PlayerPrefs.GetFloat(sensorName + "Z");
                    //    pos = new Vector3(x, y, z);
                    //    targetSensor.transform.position = pos;
                    //    break;
            }
        }
    }
}
