using UnityEngine;
using UnityEngine.UI;

public class DropValue : MonoBehaviour
{
    [SerializeField]
    public Dropdown drop;

    public ifBlock ifblock;
    // Start is called before the first frame update

    private void Start()
    {
        ifblock = this.gameObject.GetComponentInParent<ifBlock>();
    }

    public void ChangeValue()
    {
        ifblock.FirstSel = drop.value;
    }
}