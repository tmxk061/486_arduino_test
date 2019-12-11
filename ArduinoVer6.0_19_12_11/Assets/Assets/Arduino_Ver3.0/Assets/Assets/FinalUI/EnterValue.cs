using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnterValue : MonoBehaviour
{
    [SerializeField]
    public InputField text;

    public ifBlock ifblock;

    public int val;
    // Start is called before the first frame update

    void Start()
    {
        ifblock = this.gameObject.GetComponentInParent<ifBlock>();
    }

    public void ChangeValue()
    {
       if(ChangeText()!=false)
        {
            ifblock.ThirdSel = val;
        }
       else
        {

        }

    }

    public bool ChangeText()
    {
        try
        {
            val = int.Parse(text.text);

            return true;
        }
        catch(Exception)
        {
            return false;
        }

    }
}
