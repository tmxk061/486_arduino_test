using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashEventScript : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        TrashCollider(other);
    }

    public void TrashCollider(Collider2D other)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(other.tag == "Block")
            {
                return;
            }
            Destroy(other.transform.gameObject);
        }
    }
}
