using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownMenu : MonoBehaviour
{
    public UnityEngine.UI.Dropdown dropdown;
    public GameObject dumy;
    public GameObject[] list;

    //기본 환경에 맞는 설정
    [Header("조도")]
    public float llluminance;
    [Header("온도")]
    public float temperature;
    [Header("습도")]
    public float humidity;

    public float lll = 0;
    public float tem = 0;
    public float hum = 0;


    int temp;

    private void Start()
    {
        //평균 조도 10000룩스
        //평균 온도 12.5도
        //평균 습도 60%

        llluminance = 10000f;
        temperature = 12.5f;
        humidity = 60;
        temp = 0;
        //list[0] = dumy;
        dropdown = this.gameObject.GetComponent<UnityEngine.UI.Dropdown>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(lll + ":" + tem + ":" + hum);
        }
    }

    public void Check()
    {

        //DestroyImmediate(GameObject.Find(list[temp].name + "(Clone)"));

        list[temp].SetActive(false);

        temp = dropdown.value;

        switch (list[dropdown.value].gameObject.name)
        {
            //동굴
            //조도 0룩스
            //온도 12.5도
            //습도 80%
            case "Cave":
                list[dropdown.value].SetActive(true);
                llluminance = 0f;
                temperature = 12.5f;
                humidity = 80f;
                break;

            //남극 https://m.blog.naver.com/PostView.nhn?blogId=kma_131&logNo=220926140555&proxyReferer=https%3A%2F%2Fwww.google.com%2F
            //조도 100000룩스
            //온도 -18.5도
            //습도 5%
            case "South":
                list[dropdown.value].SetActive(true);
                llluminance = 100000f;
                temperature = -18.5f;
                humidity = 5f;
                break;

            //연못
            //평균 조도 10000룩스
            //평균 온도 25.9도
            //평균 습도 60%
            case "Pond":
                list[dropdown.value].SetActive(true);
                llluminance = 1000f;
                temperature = 25.9f;
                humidity = 60f;
                break;

            //사막
            //조도 100000룩스
            //온도 40도
            //습도 25%https://www.facebook.com/karipr/posts/1103030683138179/
            case "Desert":
                list[dropdown.value].SetActive(true);
                llluminance = 100000f;
                temperature = 40f;
                humidity = 25f;
                break;

            //해변 http://www.weather.go.kr/special/CRP/beach/rpt_beach_233.html
            //조도 100000룩스
            //온도 24도
            //습도 평균 대략 65도
            case "SeaSide2":
                list[dropdown.value].SetActive(true);
                llluminance = 100000f;
                temperature = 24f;
                humidity = 65f;
                break;

            case "Desk":
                list[dropdown.value].SetActive(true);
                llluminance = 10000f;
                temperature = 12.5f;
                humidity = 60;
                break;
        }

        lll = llluminance;
        tem = temperature;
        hum = humidity;

    }
    //비 최대량 400 강수량 대략 2000mm예상
    public void AddRainHumidity(float RainValue)
    {
        lll = llluminance;
        tem = temperature;
        hum = humidity;

        switch (list[dropdown.value].gameObject.name)
        {

            //동굴
            //조도 0룩스
            //온도 12.5도
            //습도 80%
            case "Cave":
                tem += RainValue * Random.Range(0.0015f,0.001f);
                hum += RainValue * 0.001f;
                return;

            //남극 https://m.blog.naver.com/PostView.nhn?blogId=kma_131&logNo=220926140555&proxyReferer=https%3A%2F%2Fwww.google.com%2F
            //조도 100000룩스
            //온도 -18.5도
            //습도 5%
            case "South":
                tem += RainValue * 0.05f;
                hum += RainValue * 0.05f;
                return;

            //연못
            //평균 조도 10000룩스
            //평균 온도 25.9도
            //평균 습도 60%
            case "Pond":
                tem += RainValue * 0.01f;
                hum += RainValue * 0.1f;
                return;

            //사막
            //조도 100000룩스
            //온도 40도
            //습도 25%https://www.facebook.com/karipr/posts/1103030683138179/
            case "Desert":
                tem -= RainValue * 0.04f;
                hum += RainValue * 0.1f;
                return;

            //해변 http://www.weather.go.kr/special/CRP/beach/rpt_beach_233.html
            //조도 100000룩스
            //온도 24도
            //습도 평균 대략 65도
            case "SeaSide2":
                tem += RainValue * 0.008f;
                hum += RainValue * 0.07f;
                return;

            case "Desk":
                llluminance = 10000f;
                temperature = 12.5f;
                humidity = 60;
                return;
            default:
                return;
        }
    }

    //눈 최대량 400
    public void AddSnowHumidity(float SnowValue)
    {
        lll = llluminance;
        tem = temperature;
        hum = humidity;

        switch (list[dropdown.value].gameObject.name)
        {
            //동굴
            //조도 0룩스
            //온도 12.5도
            //습도 80%
            case "Cave":
                tem -= SnowValue * Random.Range(0.0015f, 0.001f); //0.6 ~ 0.4
                hum -= SnowValue * Random.Range(0.001f, 0.025f); //0.4 ~ 10
                if (hum <= 0)
                    hum = 0;

                return;

            //남극 https://m.blog.naver.com/PostView.nhn?blogId=kma_131&logNo=220926140555&proxyReferer=https%3A%2F%2Fwww.google.com%2F
            //조도 100000룩스
            //온도 -18.5도
            //습도 5%
            case "South":
                tem -= SnowValue * 0.04f; //16
                hum = 0f;
                if (hum <= 0)
                    hum = 0;

                return;

            //연못
            //평균 조도 10000룩스
            //평균 온도 25.9도
            //평균 습도 60%
            case "Pond":
                tem -= SnowValue * Random.Range(0.06f, 0.07f); //24 ~ 28
                hum -= SnowValue * 0.25f; //100
                if (hum <= 0)
                    hum = 0;

                return;

            //사막
            //조도 100000룩스
            //온도 40도
            //습도 25%https://www.facebook.com/karipr/posts/1103030683138179/
            case "Desert":
                tem -= SnowValue * 0.1f; //40
                hum += SnowValue * 0.05f; //20
                if (hum <= 0)
                    hum = 0;

                return;

            //해변 http://www.weather.go.kr/special/CRP/beach/rpt_beach_233.html
            //조도 100000룩스
            //온도 24도
            //습도 평균 대략 65도
            case "SeaSide2":
                tem -= SnowValue * Random.Range(0.06f, 0.07f); //24 ~ 28
                hum -= SnowValue * 0.25f; //100
                if (hum <= 0)
                    hum = 0;

                return;

            case "Desk":
                llluminance = 10000f;
                temperature = 12.5f;
                humidity = 60;
                return;
            default:
                return;
        }

        
    }
}


