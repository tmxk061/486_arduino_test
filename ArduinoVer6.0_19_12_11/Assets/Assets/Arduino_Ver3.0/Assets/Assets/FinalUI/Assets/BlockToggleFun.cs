using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockToggleFun : MonoBehaviour
{
    public Toggle MyToggle;
    public GameObject obj;

    public void ToggleOn()
    {
        if(MyToggle.isOn)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
