using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAnimalSetting : MonoBehaviour
{
    public GameObject[] Animal;
    public Vector3[] AnimalLocation;

    private void OnEnable()
    {
        if (isActiveAndEnabled == true)
        {
            for (int i = 0; i <= Animal.Length-1; i++)
            {
                Animal[i].transform.localPosition = AnimalLocation[i];
            }
        }

    }

}
