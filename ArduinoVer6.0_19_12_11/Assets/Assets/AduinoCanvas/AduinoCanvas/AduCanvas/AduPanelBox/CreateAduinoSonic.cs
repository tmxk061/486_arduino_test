using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateAduinoSonic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject obj;

    public GameObject Tootip;

    public Ultrasonic type;

    public void ClickEvent()
    {
        UltValue ultval = Instantiate(obj, new Vector3(40, 150, 75), new Quaternion(0, 180, 0 ,0)).GetComponent<UltValue>();
        ultval.ultrasonic = type;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tootip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tootip.SetActive(false);
    }
}
