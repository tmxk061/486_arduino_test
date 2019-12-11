using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Test : MonoBehaviour
{

    public GameObject[] BoxPrefab;
    
    // public GameObject cube;
    public Vector3 pos;

    public void OnMouseDown()
    {
        SaveData();
        Debug.Log("작동");
    }



    public void SaveData()
    {
        
        BoxPrefab = GameObject.FindGameObjectsWithTag("Temperature-HumiditySensor");

        if (BoxPrefab != null)
        {

            //BoxPrefab = BoxPrefab;
            //BoxPrefab = this.transform.gameObject;

            for (int i = 0; i < BoxPrefab.Length; i++)
            {
                string sentance = "BoxPrefab" + i.ToString();
                Debug.Log(sentance);
                PlayerPrefs.SetString(sentance, "Exist");

                PlayerPrefs.SetFloat("x", BoxPrefab[i].transform.position.x);
                PlayerPrefs.SetFloat("y", BoxPrefab[i].transform.position.y);
                PlayerPrefs.SetFloat("z", BoxPrefab[i].transform.position.z);
            }

           
        }
        else
        {
            Debug.Log("no");
        }
    }
   

}
