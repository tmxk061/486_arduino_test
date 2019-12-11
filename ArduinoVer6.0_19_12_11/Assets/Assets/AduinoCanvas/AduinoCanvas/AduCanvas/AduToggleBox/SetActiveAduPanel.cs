using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetActiveAduPanel : MonoBehaviour
{
    public GameObject obj;

    public Toggle tog;

    private void Start()
    {
        tog = GetComponent<Toggle>();
    }

    public void ClickEvent()
    {
        if(tog.isOn)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
