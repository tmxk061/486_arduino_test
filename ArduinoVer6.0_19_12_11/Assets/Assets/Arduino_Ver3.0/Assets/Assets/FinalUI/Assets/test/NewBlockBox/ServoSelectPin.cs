using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ServoSelectPin : MonoBehaviour
{
    [SerializeField]
    public int selectnum = 0;
    ServoBlock Servo;
    [SerializeField]
    Dropdown drop;
    // Start is called before the first frame update
    void Start()
    {
        Servo = this.gameObject.GetComponentInParent<ServoBlock>();
    }

    public void SetContent()
    {

        selectnum = drop.value;

        Servo.SetNum(selectnum);


    }
}
