using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool move = false;
    float xLocal = 1;

    // Update is called once per frame
    void Update()
    {
        if(move == true)
            this.transform.localPosition += new Vector3(xLocal, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.transform.localPosition.x <= -80f)
            xLocal *= -1f;
        if (this.transform.localPosition.x >= 80f)
            xLocal *= -1f;
    }

    public void moveObject()
    {
        if (move == false)
            move = true;
        else
            move = false;
    }
}
