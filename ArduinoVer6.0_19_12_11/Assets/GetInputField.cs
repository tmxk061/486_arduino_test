using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputField : MonoBehaviour
{
    public GameObject obj;

    public GameObject penel;

    public InputField input1;
    public InputField input2;

    public Ultrasonic type;

    public void ClickEvent()
    {
        if (int.Parse(input1.text) <= 0 || input1.text == null || input1.text == "")
            return;

        if (int.Parse(input2.text) <= 0 || input2.text == null || input2.text == "" || int.Parse(input2.text) > 180)
            return;

        UltValue ultval = Instantiate(obj, new Vector3(40, 150, 75), new Quaternion(0, 180, 0, 0)).GetComponent<UltValue>();
        ultval.ultrasonic = type;

        ultval.CustomDis = int.Parse(input1.text)*30;
        ultval.CustomWil = int.Parse(input2.text);

        penel.SetActive(false);
    }

    public void ClickEvnet2()
    {
        penel.SetActive(false);
    }
}