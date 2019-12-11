using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ServoAngle : MonoBehaviour
{
    [SerializeField]
    InputField input;

    ServoBlock servo;
    float angle = 0f;

    void Start()
    {
        servo = this.gameObject.GetComponentInParent<ServoBlock>();
    }


    public void SetContent()
    {
        if (input.text != null)
        {
            angle = int.Parse(input.text);

            servo.setAngle(angle);
        }
    }
}