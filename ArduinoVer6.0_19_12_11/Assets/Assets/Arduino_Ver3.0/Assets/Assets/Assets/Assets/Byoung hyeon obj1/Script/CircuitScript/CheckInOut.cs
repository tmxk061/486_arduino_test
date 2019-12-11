using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInOut : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Line")
        {
            this.gameObject.GetComponentInChildren<GameObject>().SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Line")
        {
            this.gameObject.GetComponentInChildren<GameObject>().SetActive(false);
        }
    }
}
