using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetValueInputFieldScript : MonoBehaviour
{
    private Text text;
    private InputField input;

    string OpenName = "";

    public void Start()
    {
        input = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            text.text = input.text;
            input.text = "";

            input.transform.gameObject.SetActive(false);
        }
    }

    private void GetString(string name)
    {
        OpenName = name;
    }

    private void GetText(Text text1)
    {
        text = text1;
    }
}
