using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropDownSel : MonoBehaviour
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

    private void Awake()
    {
        
    }

    public void SelectContent()
    {
        image.SetNum(drop.value);

    }

    
}
