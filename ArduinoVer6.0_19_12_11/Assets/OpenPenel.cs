using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPenel : MonoBehaviour
{
    public GameObject penel;

    public void ClickEvent()
    {
        penel.SetActive(true);
    }
}