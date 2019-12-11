using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowScript : MonoBehaviour
{
    //파티클 량
    public UnityEngine.UI.Toggle SnowStart;
    public UnityEngine.UI.Slider Slide;
    public DropDownMenu TempValue;

    ParticleSystem ps;
    public ParticleSystem.MinMaxCurve rate;

    private void OnEnable()
    {
        //껏다 키는 부분

        ps = GetComponent<ParticleSystem>();
        rate = ps.emission.rateOverTime.constant;

    }

    private void Update()
    {
        //UI로 값 바꿀 곳
        MakeRain();
    }

    public void MakeRain()
    {
        if (SnowStart.isOn == true)
        {
            ps.Play();
            ParticleSystem.EmissionModule e = ps.emission;
            e.enabled = ps.GetComponent<Renderer>().enabled = true;

            rate = e.rateOverTime;
            rate.mode = ParticleSystemCurveMode.Constant;
            rate.constantMin = rate.constantMax = Slide.value * 20f;
            e.rateOverTime = rate;

            TempValue.AddSnowHumidity(e.rateOverTime.constant);
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
}
