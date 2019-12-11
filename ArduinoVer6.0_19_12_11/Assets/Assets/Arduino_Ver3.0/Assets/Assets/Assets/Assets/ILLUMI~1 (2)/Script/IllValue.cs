using System.Collections;
using UnityEngine;


public enum SensorType
{
    GL5516, GL5528, GL5537, CustomIii,
}


public class IllValue : MonoBehaviour
{
    public bool VccConnect = false;
    public bool GNDConnect = false;
    public bool AnalogConnect = false;

    [SerializeField] private float viewAngle; //시야각 120도
    [SerializeField] private float viewDistance; //시야거리 (10미터)
    [SerializeField] private LayerMask targetMask; //타겟 마스크(플레이어)

    public bool hitLight = false;
    public GameObject lightObject;
    public Light light2;
    public bool RunOn=false;

    public SensorType sensorType = SensorType.GL5516;

    //조도 측정
    [SerializeField] private float Value;
    //저항 측정
    [SerializeField] private float Ohm=0;

    public int CustomOhm = 0;

    void Start()
    {
        lightObject = GameObject.Find("Light");
        light2 = lightObject.GetComponent<Light>();
    }

    //private void Update()
    //{
    //    if (hitLight == true)
    //    {
    //        //빛으로 쏜 게임오브젝트의 위치를 받는다.
    //        Vector3 _direction = (lightObject.transform.position - transform.position).normalized;

    //        Debug.DrawLine(this.transform.position, _direction);



    //        float _angle = Vector3.Angle(transform.forward,_direction);

    //        float direct = (light.transform.position - transform.position).magnitude;


    //        //닿아서 찾았을 때
    //        if (_angle < viewAngle)
    //        {

    //            RaycastHit _hit;

    //            if (Physics.Raycast(transform.position, _direction, out _hit, light.range))
    //            {
    //                if (_hit.transform.name == "Light")
    //                {

    //                    Value = (light.intensity * (4 * Mathf.PI) / (direct))*1.1f;//* Mathf.Cos(_angle);

    //                    if (Value <= 0)
    //                        Value = -Value;

    //                    if (Value >= 1024)
    //                        Value = 1024;

    //                    switch (sensorType)
    //                    {
    //                        case SensorType.GL5516:

    //                            Ohm = 1023 * Value;
    //                            if (Ohm >= 1024) Ohm = 1023;

    //                            if (Ohm <= 0) Ohm = -Ohm;
    //                            Debug.Log(Ohm);
    //                            break;
    //                        case SensorType.GL5528:
    //                            Ohm = 1028 / Value;
    //                            break;
    //                        case SensorType.GL5537:
    //                            Ohm = 1033 / Value;
    //                            break;
    //                    }
    //                }
    //                else
    //                {
    //                    hitLight = false;
    //                }
    //            }
    //        }
    //    }
    //}

    public void Run()
    {
        RunOn = true;

        StartCoroutine(Work());
        
    }

    public float Read()
    {
        RunOn = true;

        StartCoroutine(Work());

        return Ohm;
    }

    IEnumerator Work()
    {
        if (GNDConnect == true && AnalogConnect == true && VccConnect == true)
        {
            if (hitLight == true)
            {
                //빛으로 쏜 게임오브젝트의 위치를 받는다.
                Vector3 _direction = (lightObject.transform.position - transform.position).normalized;
                //light2 = lightObject.GetComponent<Light>();

                Debug.DrawRay(this.transform.position, _direction);

                float _angle = Vector3.Angle(_direction, transform.forward);

                float direct = (light2.transform.position - transform.position).magnitude;

               
                //닿아서 찾았을 때
                if (_angle < viewAngle)
               {

                    RaycastHit _hit;

                    if (Physics.Raycast(transform.position, _direction, out _hit, light2.range))
                    {
                        if (_hit.transform.name == "Light")
                        {
                            Value = (light2.intensity * (4 * Mathf.PI) / direct) * Mathf.Cos(_angle)*20;

                            if (Value <= 0)
                                Value = -Value;

                            if (Value >= 1024)
                                Value = 1024;

                            if (Value == 0) Value = 1;

                            switch (sensorType)
                            {
                                case SensorType.GL5516:
                                    Ohm = 1023 / Value;
                                    if (Ohm >= 1024) { Ohm = 1023; }
                                    break;
                                case SensorType.GL5528:
                                    Ohm = 1028 / Value;
                                    if (Ohm >= 1028) { Ohm = 1028; }
                                    break;
                                case SensorType.GL5537:
                                    Ohm = 1033 / Value;
                                    if (Ohm >= 1033) { Ohm = 1033; }
                                    break;
                                case SensorType.CustomIii:
                                    Ohm = (1023 + CustomOhm) / Value;
                                    if (Ohm >= (1023 + CustomOhm)) { Ohm = 1023 + CustomOhm; }
                                    break;

                            }
                        }
                        else
                        {
                            hitLight = false;
                        }
                    }
                }
            }
        }

        yield return new WaitForSecondsRealtime(1.5f);

        if(RunOn==true)
        {
            StartCoroutine(Work());
        }
    }
    public void Pause()
    {
        RunOn = false;
    }
}
