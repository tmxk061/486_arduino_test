using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateVariableBtn : MonoBehaviour
{
    public GameObject obj;

    public void ClickEvnet()
    {
        obj.SetActive(true);
    }
}
