using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class suuiVariable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //자기 자신 토글
    private Toggle tog;

    //자기 이미지
    private Image obj;
    private Image obj2;

    //테두리 구분
    private float AlphaThreshold = 0.1f;

    //아웃라인 객체
    private Outline outline;
    private Outline outline2;

    //텍스트 객체
    private Text text;

    //활성화 시킬 패널
    public GameObject activePanel;

    //저장할 텍스트 값
    private string strtext;

    void Start()
    {
        //토글 자신 객체 얻기
        tog = GetComponent<Toggle>();

        //토글의 자식 이미지 객체 얻기
        obj = GetComponent<Image>();
        obj2 = tog.transform.Find("Checkmark").GetComponent<Image>();

        //토글의 자식 텍스트 객체 얻기
        text = tog.transform.Find("Label").GetComponent<Text>();

        //외각선 히트박스 처리
        obj.alphaHitTestMinimumThreshold = AlphaThreshold;
        obj2.alphaHitTestMinimumThreshold = AlphaThreshold;

        //아웃라인 객체 얻기
        outline = obj.GetComponentInChildren<Outline>();
        outline2 = obj2.GetComponentInChildren<Outline>();

        //텍스트값 저장
        strtext = text.text;
    }

    //커서위치가 오브젝트에 들어옴
    public void OnPointerEnter(PointerEventData eventData)
    {
        //사이즈 증가
        obj.rectTransform.sizeDelta = new Vector2(75, 75);
        obj2.rectTransform.sizeDelta = new Vector2(75, 75);

        //outline.enabled = true;

        //아웃라인 컬러 변경
        outline.effectColor = new Color(255, 0, 0);
        outline2.effectColor = new Color(255, 0, 0);

        //폰트 사이즈 증가
        text.fontSize = 17;
    }

    //커서위치가 오브젝트에서 나감
    public void OnPointerExit(PointerEventData eventData)
    {
        //사이즈 조정
        obj.rectTransform.sizeDelta = new Vector2(65, 65);
        obj2.rectTransform.sizeDelta = new Vector2(65, 65);

        //outline.enabled = false;

        //아웃라인 컬러 변경
        outline.effectColor = new Color(0, 0, 0);
        outline2.effectColor = new Color(0, 0, 0);

        //폰트 사이즈 조정
        text.fontSize = 14;
    }

    //토글 활성화 이벤트
    public void ToggleActiveEvent()
    {
        if (tog.isOn)
        {
            //패널 활성화
            activePanel.SetActive(true);

            //텍스트 조정
            text.color = new Color(255, 255, 255);
            text.text = "취소";
        }
        else
        {
            //패널 비활성화
            activePanel.SetActive(false);

            //텍스트 조정
            text.color = new Color(0, 0, 0);
            text.text = strtext;
        }
    }
}
