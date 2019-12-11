using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputField3 : MonoBehaviour
{
    public GameObject obj;

    public GameObject penel;

    public InputField input1;

    public SensorType type;

    public void ClickEvent()
    {
        if (int.Parse(input1.text) <= 0 || input1.text == null || input1.text == "")
            return;

        IllValue illval = Instantiate(obj, new Vector3(-40, 115, 35), new Quaternion(90, 0, 0, 0)).transform.Find("DetectLight").GetComponent<IllValue>();
        illval.sensorType = type;

        illval.CustomOhm = int.Parse(input1.text);

        penel.SetActive(false);
    }

    public void ClickEvnet2()
    {
        penel.SetActive(false);
    }
}