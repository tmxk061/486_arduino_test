using System;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public bool Connect = false;
    public float Electro;

    public GameObject Around;
    public CircuitManager circuitManager;
    public LineManager Line;
    public float Work = 0;
    public GameManager.SensorType SocketType;

    private void Start()
    {
        circuitManager = CircuitManager.GetInstance();
        OnArround(true);
    }

    private void OnTriggerStay(Collider other)
    {        //전력을 받는다
        if (other.tag == "Line")
        {
            Connect = true;

            OnArround(false);

            Line = other.gameObject.GetComponentInParent<LineManager>();

            SocketType = Line.type;
        }
    }

    public List<float> listSocketRun()
    {
        List<float> list;

        if (Line != null)
        {
            list = Line.humitempRead?.Invoke();
            return list;
        }

        return null;
    }

    public float? floatSocketRun()
    {
        if (Line != null)
        {
            switch (Line.type)
            {
                case GameManager.SensorType.Lux:
                    {
                        float? value = Line.luxRead?.Invoke();

                        Debug.Log(value);
                        return value;
                        //Read 함수 만들예정
                    }

                case GameManager.SensorType.Ult:
                    {
                        Debug.Log("ult");

                        float? value = Line.ultRead?.Invoke();

                        Debug.Log(value);
                        return value;
                        //Read 함수 만들예정
                    }
            }
        }

        return null;
    }

    public bool SocketRun(float forServo)
    {
        if (Line != null)
        {
            switch (Line.type)
            {
                case GameManager.SensorType.Led:
                    {
                        Line.run?.Invoke(); //DigitalWrite

                        break;
                    }
                case GameManager.SensorType.Bread:
                    {
                        //Bread보드에 연결된거 작동
                        if (Line.plusGroup != null) Line.plusGroup.PinGroupRun(forServo);

                        break;
                    }
                case GameManager.SensorType.DC:
                    {
                        Line.run?.Invoke();//DigitalWrite

                        break;
                    }
                case GameManager.SensorType.l298n:
                    {
                        Line.run?.Invoke();//DigitalWrite

                        break;
                    }
                case GameManager.SensorType.Servo:
                    {
                        Line.servorun?.Invoke(forServo);//ServoRun
                        break;
                    }
                case GameManager.SensorType.Sound:
                    {
                        Line.run?.Invoke();//DigitalWrite

                        break;
                    }
                case GameManager.SensorType.Lux:
                    {
                        Line.luxRead?.Invoke();

                        break;
                    }
                case GameManager.SensorType.HumiTemp:
                    {
                        Line.humitempRead?.Invoke();

                        break;
                    }
                case GameManager.SensorType.Ult:
                    {
                        Line.ultRead?.Invoke();

                        break;
                    }
            }
        }

        return false;
    }

    public bool SocketPause()
    {
        if (Line != null)
        {
            if (Line.plusGroup != null)
            { Line.plusGroup.PinGroupPause(); }

            Line.pause?.Invoke();
        }
        return false;
    }

    public void OnArround(bool b)
    {
        try
        {
            Around.SetActive(b);
        }
        catch (Exception)
        {
            Func(delegate () { return true; });
        }
    }

    private void Func(Func<bool> callback)
    {
        callback();
    }
}