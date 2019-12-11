using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateLED : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject obj;

    [SerializeField]
    public GameObject obj2;

    [SerializeField]
    public GameObject obj3;

    [SerializeField]
    public GameObject obj4;


    public GameObject Tootip;

    List<GameObject> objlist = new List<GameObject>();

    public void Start()
    {
        objlist.Add(obj);
        objlist.Add(obj2);
        objlist.Add(obj3);
        objlist.Add(obj4);
    }

    public void ClickEvent()
    {
        int num = 0;

        num = Random.Range(0, 4);

        Instantiate(objlist[num], new Vector3(33.17457f, 127.0219f, 100.3321f), Quaternion.identity);
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
