using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitManager : MonoBehaviour
{
    public float ConnectElectro = 0;

    public Component[] Circuit;
    public bool Connecting = false;

    private static CircuitManager instance;
    private static GameObject container;
    

    

    public void Start()
    { 
     
    }
   


    public static CircuitManager GetInstance()
    {
            if (!instance)
            {
                container = new GameObject();
                container.name = "CircuitManager";
                instance = container.AddComponent(typeof(CircuitManager)) as CircuitManager;
            }
        return instance;
    }

}
