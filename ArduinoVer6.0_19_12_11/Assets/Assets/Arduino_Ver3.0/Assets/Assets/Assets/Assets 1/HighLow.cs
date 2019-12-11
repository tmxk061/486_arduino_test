using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
public class HighLow : MonoBehaviour
{
    [SerializeField]
    public Dropdown drop;

    public DragImage image;


    // Start is called before the first frame update 
    void Start()
    {
        image = this.gameObject.GetComponentInParent<DragImage>();

        // image.SetNum(0);
    }

    

    public void SelectContent()
    {

        if (drop.value == 0)
        {
            image.highlowsel(true);
        }
        else if(drop.value==1)
        {
            image.highlowsel(false);
        }

      
    }
}
