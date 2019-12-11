using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusGroup : MonoBehaviour
{

    public bool VccConnect;
    public bool GNDConnect;
    public bool DigitalConnect;
    public List<BreadBoardPin> pinlist = new List<BreadBoardPin>();
    // Start is called before the first frame update
    void Start()  
    {
       
        for(int i=0;i<transform.childCount;i++)
        {
            pinlist.Add(transform.GetChild(i).GetComponent<BreadBoardPin>());
        }

        
    }
  

    public void PinGroupRun(float c)
    {
       
            for (int i = 0; i < transform.childCount; i++)
            {
               if(pinlist[i].pinruncollect !=null)
              {
                pinlist[i].pinruncollect(c);
              }
            }
     
    }

    public void PinGroupPause()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            if (pinlist[i].pinpausecollect != null)
            {
                pinlist[i].pinpausecollect();
            }
        }
    }
    public void SetDigital(bool _digi)
    {
        DigitalConnect = _digi;
    }
    public bool GetDigital()
    {
        return DigitalConnect;
    }
    public void SetVcc(bool _vcc)
    {
        VccConnect = _vcc;
    }
    public bool GetVcc()
    {
        return VccConnect;
    }

    public void SetGND(bool _vcc)
    {
        GNDConnect = _vcc;
    }
    public bool GetGND()
    {
        return GNDConnect;
    }

    // Update is called once per frame

}
