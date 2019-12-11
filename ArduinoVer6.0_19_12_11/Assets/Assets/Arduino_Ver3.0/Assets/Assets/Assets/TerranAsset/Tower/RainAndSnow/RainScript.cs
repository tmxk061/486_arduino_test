using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    //파티클 량
    public UnityEngine.UI.Toggle RainStart;
    public UnityEngine.UI.Slider Slide;
    public DropDownMenu TempValue;

    ParticleSystem ps;
    public ParticleSystem.MinMaxCurve rate;

    private void OnEnable()
    {
        //껏다 키는 부분
        ps = GetComponent<ParticleSystem>();
        rate = ps.emission.rateOverTime.constant;

        //TempValue = GetComponent<Test>();
    }

    private void Update()
    {
        //UI로 값 바꿀 곳
        MakeRain();
    }

    public void MakeRain()
    {
        if (RainStart.isOn == true)
        {
            ps.Play();
            ParticleSystem.EmissionModule e = ps.emission;
            e.enabled = ps.GetComponent<Renderer>().enabled = true;

            rate = e.rateOverTime;
            rate.mode = ParticleSystemCurveMode.Constant;
            rate.constantMin = rate.constantMax = Slide.value * 20f;
            e.rateOverTime = rate;

            TempValue.AddRainHumidity(e.rateOverTime.constant);
        }
        else
        {
            ps.Stop();
            ParticleSystem.EmissionModule e = ps.emission;
            e.enabled = ps.GetComponent<Renderer>().enabled = true;

            rate = e.rateOverTime;
            rate.mode = ParticleSystemCurveMode.Constant;
            rate.constantMin = rate.constantMax = 0f;
            e.rateOverTime = rate;

        }
    }

    /*private void OnParticleTrigger()
    {

        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        //파티클 량을 가지고 온도와 적절히 조합하여 습도를 만들어낸다.
        //TempHumiParent에 연결해서 사용


        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            p.startColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            enter[i] = p;
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
    }*/
}
