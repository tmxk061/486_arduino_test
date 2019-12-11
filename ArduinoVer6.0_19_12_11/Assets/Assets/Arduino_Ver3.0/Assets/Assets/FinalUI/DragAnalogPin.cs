using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAnalogPin : MonoBehaviour
{
    [SerializeField]
    public Dropdown drop;

    public AnalogRead image;


    // Start is called before the first frame update 
    void Start()
    {
        image = this.gameObject.GetComponentInParent<AnalogRead>();

        // image.SetNum(0);
    }



    public void SelectContent()
    {
        image.SetNum(drop.value);

    }
}
