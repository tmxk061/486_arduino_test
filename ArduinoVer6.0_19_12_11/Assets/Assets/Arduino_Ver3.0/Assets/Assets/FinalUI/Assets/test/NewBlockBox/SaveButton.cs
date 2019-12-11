using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public List<GameObject> BoxPrefab = new List<GameObject>();

    public Vector3 pos;

    public void OnMouseDown()
    {
        SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.DeleteAll();

        BoxPrefab.Clear();



        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Sensor").Length; i++)
        {
            GameObject GO = GameObject.FindGameObjectsWithTag("Sensor")[i];

            BoxPrefab.Add(GO.gameObject);

            if (GO.gameObject.transform.GetChild(1).name == "End")
            {
                BoxPrefab.Add(GO.transform.GetChild(1).gameObject);
            }
        }


      

        if (BoxPrefab.Count > 0)
        {
            for (int i = 0; i < BoxPrefab.Count; i++)
            {
                PlayerPrefs.SetString("SENSOR_" + i.ToString(), BoxPrefab[i].name);
                string pos = PlayerPrefs.GetString("SENSOR_" + i.ToString());
              
                PlayerPrefs.SetFloat(pos + i + "X", BoxPrefab[i].transform.position.x);
                PlayerPrefs.SetFloat(pos + i + "Y", BoxPrefab[i].transform.position.y);
                PlayerPrefs.SetFloat(pos + i + "Z", BoxPrefab[i].transform.position.z);
                PlayerPrefs.SetFloat(pos + i + "RX", BoxPrefab[i].transform.rotation.x);
                PlayerPrefs.SetFloat(pos + i + "RY", BoxPrefab[i].transform.rotation.y);
                PlayerPrefs.SetFloat(pos + i + "RZ", BoxPrefab[i].transform.rotation.z);
                //LineManager(Clone)0X

                if (BoxPrefab[i].name == "LineManager(Clone)")
                {

                    Transform endLine = BoxPrefab[i].transform.GetChild(1);
                   

                    ++i;
                    PlayerPrefs.SetString("SENSOR_" + i.ToString(), BoxPrefab[i - 1].transform.GetChild(1).name);
                    string endpos = PlayerPrefs.GetString("SENSOR_" + i.ToString());

                    PlayerPrefs.SetFloat(endpos + i + "X", BoxPrefab[i].transform.GetComponent<End>().savepos[0]);
                    PlayerPrefs.SetFloat(endpos + i + "Y", BoxPrefab[i].transform.GetComponent<End>().savepos[1]);
                    PlayerPrefs.SetFloat(endpos + i + "Z", BoxPrefab[i].transform.GetComponent<End>().savepos[2]);
                    PlayerPrefs.SetFloat(endpos + i + "RX", BoxPrefab[i].transform.GetComponent<End>().savepos[3]);
                    PlayerPrefs.SetFloat(endpos + i + "RY", BoxPrefab[i].transform.GetComponent<End>().savepos[4]);
                    PlayerPrefs.SetFloat(endpos + i + "RZ", BoxPrefab[i].transform.GetComponent<End>().savepos[5]);
                   
                  
                }
            }
            PlayerPrefs.SetInt("SENSOR_LENGTH", BoxPrefab.Count);
        }
    }
}
