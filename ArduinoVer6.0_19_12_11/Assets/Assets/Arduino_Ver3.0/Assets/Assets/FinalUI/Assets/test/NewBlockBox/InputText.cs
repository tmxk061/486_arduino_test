using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputText : MonoBehaviour
{
    WaitBlock waitblock;
    [SerializeField]
    InputField text;
    int blockcontent = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        waitblock = this.gameObject.GetComponentInParent<WaitBlock>();
    }

   public void SetContent()
    {
        
        
        if (text.text != null)
        {
            if (text.text != " ")
            {
                blockcontent = int.Parse(text.text);
                waitblock.setSecond(blockcontent);
            }
        }
        
    }
    
}
