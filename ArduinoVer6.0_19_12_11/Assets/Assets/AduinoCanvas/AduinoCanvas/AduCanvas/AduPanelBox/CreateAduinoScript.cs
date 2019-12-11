using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateAduinoScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public GameObject obj;




    public GameObject Tootip;



    public void Start()
    {
     
    }

    public void ClickEvent()
    {
        int num = 0;

         num = Random.Range(0, 4);

        Instantiate(obj, new Vector3(33.17457f, 127.0219f, 100.3321f), Quaternion.identity);
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
