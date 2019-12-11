using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class OnButtonClick : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    public Camera FirstCamera;
    [SerializeField]
    public Camera SecondCamera;
    public Canvas can;

    OnCubeClick cube;
    RunButton button;


    [SerializeField]
    public GameObject panel1;
    [SerializeField]
    public GameObject panel2;


    [SerializeField]
    public Toggle Button1;
    [SerializeField]
    public Toggle Button2;
    [SerializeField]
    public Toggle Button3;
    [SerializeField]
    public Toggle Button4;
  

    public Image panel1Image;
    public Image panel2Image;


    public Image Button1Image;
    public Image Button2Image;
    public Image Button3Image;
    public Image Button4Image;
    
    // Start is called before the first frame update
    void Start()
    {

        Button1Image = Button1.GetComponent<Image>();
        Button2Image = Button2.GetComponent<Image>();
        Button3Image = Button3.GetComponent<Image>();
        Button4Image = Button4.GetComponent<Image>();
       


        can = canvas.gameObject.GetComponent<Canvas>();
        cube = GameObject.FindWithTag("BlockCoding").GetComponent<OnCubeClick>();
        button = GameObject.FindWithTag("RunBlock").GetComponent<RunButton>();


        panel1Image = panel1.GetComponent<Image>();
        panel2Image = panel2.GetComponent<Image>();


        Button1Image.raycastTarget = false;
        Button2Image.raycastTarget = false;
        Button3Image.raycastTarget = false;
        Button4Image.raycastTarget = false;
      
    }

    public void Click()
    {
        if (GameManager.RunBlock == true)
        {
            Button1Image.raycastTarget = false;
            Button2Image.raycastTarget = false;
            Button3Image.raycastTarget = false;
            Button4Image.raycastTarget = false;
           
            panel1Image.raycastTarget = false;
            panel2Image.raycastTarget = false;
            GameManager.RunBlock = false;
            can.renderMode = RenderMode.WorldSpace;

            FirstCamera.transform.position = GameManager.FirstMainCameraPosition;

            can.transform.position = GameManager.canvasposition;

            button.SearchBlock();

            FirstCamera.transform.rotation = GameManager.FirstMainCameraRotation;

            GameManager.PcOn = false;

        }
    }
}
