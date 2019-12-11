using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputField2 : MonoBehaviour
{
    public GameObject obj;

    public GameObject penel;

    public InputField input1;
    public InputField input2;
    public InputField input3;
    public InputField input4;

    public TemperToggle temptog;

    public void ClickEvent()
    {
        if (input1.text == null || input1.text == "")
            return;

        if (input2.text == null || input2.text == "" || int.Parse(input2.text) < int.Parse(input1.text))
            return;

        if (int.Parse(input3.text) <= 0 || input3.text == null || input3.text == "")
            return;

        if (int.Parse(input4.text) > 100 || input4.text == null || input4.text == "" || int.Parse(input4.text) < int.Parse(input3.text))
            return;

        TempHumiParent tempval = Instantiate(obj, new Vector3(-37.5f, 135, 55), new Quaternion(45, 180, 0, 0)).GetComponent<TempHumiParent>();
        tempval.temperToggle = temptog;

        tempval.tempminval = int.Parse(input1.text);    //최저 온도
        tempval.tempmaxval = int.Parse(input2.text);    //최고 온도
        tempval.dataminval = int.Parse(input3.text);    //최저 습도
        tempval.datamaxval = int.Parse(input4.text);    //최고 습도

        penel.SetActive(false);
    }

    public void ClickEvnet2()
    {
        penel.SetActive(false);
    }
}