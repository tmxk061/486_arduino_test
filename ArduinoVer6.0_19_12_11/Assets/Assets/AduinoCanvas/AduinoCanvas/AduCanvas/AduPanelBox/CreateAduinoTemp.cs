using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateAduinoTemp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject obj;

    public GameObject Tootip;

    public TemperToggle type;

    public void ClickEvent()
    {
        TempHumiParent ultval = Instantiate(obj, new Vector3(-37.5f, 135, 55), Quaternion.Euler(0, -180, 0)).GetComponent<TempHumiParent>();

        ultval.temperToggle = type;
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