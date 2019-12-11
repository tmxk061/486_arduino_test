using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnCubeClick : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    public Camera FirstCamera;
    [SerializeField]
    public Camera SecondCamera;
    public Vector3 FistPosition;
    public Vector3 FirstCanvasPosition;
    bool First = false;
    Canvas can;
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

        panel1Image = panel1.GetComponent<Image>();
        panel2Image = panel2.GetComponent<Image>();
        Button1Image = Button1.GetComponent<Image>();
        Button2Image = Button2.GetComponent<Image>();
        Button3Image = Button3.GetComponent<Image>();
        Button4Image = Button4.GetComponent<Image>();
    
        // panel3Image = panel3.GetComponent<Image>();

        GameManager.FirstMainCameraPosition = FirstCamera.transform.position;
        can = canvas.GetComponent<Canvas>();
        FirstCanvasPosition = can.transform.position;
        GameManager.canvasposition = FirstCanvasPosition;

        //canvas.SetActive(false);
        FirstCamera.enabled = true;
        // SecondCamera.enabled = false;


        can.renderMode = RenderMode.WorldSpace;
        // can.renderMode = RenderMode.ScreenSpaceCamera;
        // can.worldCamera = ThirdCamera;
        panel1Image.raycastTarget = false;
        panel2Image.raycastTarget = false;
        // panel3Image.raycastTarget = false;
        Button1Image.raycastTarget = false;
        Button2Image.raycastTarget = false;
        Button3Image.raycastTarget = false;
        Button4Image.raycastTarget = false;
      
    }
    private void OnMouseDown()
    {
        Button1Image.raycastTarget = true;
        Button2Image.raycastTarget = true;
        Button3Image.raycastTarget = true;
        Button4Image.raycastTarget = true;
       
        panel1Image.raycastTarget = true;
        panel2Image.raycastTarget = true;
        //  panel3Image.raycastTarget = true;
        GameManager.FirstMainCameraRotation = FirstCamera.transform.rotation;
        FirstCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
        GameManager.RunBlock = true;
        GameManager.FirstMainCameraPosition = FirstCamera.transform.position;

        FirstCamera.transform.position = SecondCamera.transform.position;
       
        // SecondCamera.enabled = true;
        //  FirstCamera.enabled = false;
        can.renderMode = RenderMode.ScreenSpaceOverlay;
        // canvas.SetActive(true);
        GameManager.PcOn = true;


    }

}
