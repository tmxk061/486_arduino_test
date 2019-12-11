using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class End : MonoBehaviour
{
    //마우스가 클릭되었을 경우 true
    public bool Firstmake;//생성되자마자 확인
                          //


    public float Electro;

    public LineManager Manager;
    public Mousepoint mousepoint;
    public GameObject socket;
    public L298NOUT4 l298n;
    public L298N_GND l298n_gnd;
    public L298N_VCC12v l298n_vcc12;
    public L298N_VCC5v l298n_vcc5;
    public PlusMinus pm;
    public bool first = true;
    public Resist resi;
    public DIGITAL_PARENT l298ndigi;

    public bool LoadLine = false;
    public float[] savepos = new float[6];

    bool ConnectCheck = false;

    //public List<float
    private void Start()
    {
        mousepoint = Camera.main.GetComponent<Mousepoint>();
        Firstmake = false;
        Manager = gameObject.GetComponentInParent<LineManager>();


    }

    private void Update()
    {
        if (LoadLine == true)
        {
            this.gameObject.transform.position = new Vector3(savepos[0], savepos[1], savepos[2]);
            this.gameObject.transform.rotation = new Quaternion(savepos[3], savepos[4], savepos[5], 0);
        }


        if (Firstmake == false && LoadLine == false)
        {
            if (mousepoint.MouseChecking == false)
            {
                savepos[0] = mousepoint.pointting.x;
                savepos[1] = mousepoint.pointting.y;
                savepos[2] = mousepoint.pointting.z;


                savepos[3] = mousepoint.hit.transform.rotation.x;
                savepos[4] = mousepoint.hit.transform.rotation.y;
                savepos[5] = mousepoint.hit.transform.rotation.z;

                this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                this.gameObject.transform.position = new Vector3(savepos[0], savepos[1], savepos[2]);
                this.gameObject.transform.rotation = mousepoint.hit.transform.rotation;

                /*asdf[0] = this.gameObject.transform.position.x;
                asdf[1] = this.gameObject.transform.position.y;
                asdf[2] = this.gameObject.transform.position.z;*/


                Firstmake = true;
            }
            else if (mousepoint.MouseChecking == true)
            {
                this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }

        }

        Electro = Manager.Electro;


    }


    private void OnTriggerStay(Collider other)
    {
       

            switch (other.tag)
            {

                case "DIGITAL":
                    Manager.Connect2 = 1;
                    Manager.DigitalConnect = true;
                    socket = other.gameObject;
                    Manager.parent = other.gameObject;
                    Manager.Power = 1;
                    break;

                case "GND":
                    Manager.Connect2 = 1;
                    Manager.GNDConnect = true;
                    socket = other.gameObject;
                    Manager.parent = other.gameObject;
                    break;

                case "VCC":
                    Manager.Connect2 = 1;
                    Manager.VccConnect = true;
                    socket = other.gameObject;
                    Manager.parent = other.gameObject;
                    if (other.name == "5V")
                    {
                        Manager.Power = 5;
                    }
                    else if (other.name == "3V")
                    {
                        Manager.Power = 3;
                    }
                    break;

                case "ANALOG":
                    Manager.Connect2 = 1;
                    socket = other.gameObject;
                    Manager.parent = other.gameObject;
                    break;

                case "INPUT":
                    Manager.Connect2 = 1;
                    if (other.name == "EPPlus")
                    {
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<LEDManager>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<LEDManager>().Pause);
                        pm = other.GetComponent<EPPlus>();


                        Manager.type = GameManager.SensorType.Led;

                    }
                    else if (other.name == "EPMinus")
                    {
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<LEDManager>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<LEDManager>().Pause);
                        pm = other.GetComponent<EPMinus>();
                    }
                    else if (other.name == "LegMin")
                    {
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<SoundParent>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<SoundParent>().Pause);
                        pm = other.GetComponent<SoundGND>();
                    }
                    else if (other.name == "LegIO")
                    {
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<SoundParent>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<SoundParent>().Pause);
                        pm = other.GetComponent<SoundDigital>();

                        Manager.type = GameManager.SensorType.Sound;
                    }
                    else if (other.name == "LegPlus")
                    {
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<SoundParent>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<SoundParent>().Pause);
                        pm = other.GetComponent<SoundVCC>();
                    }
                    else if (other.name == "UltPinVCC")
                    {
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<UltValue>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<UltValue>().Pause);
                        pm = other.GetComponent<UltVCC>();

                    }
                    else if (other.name == "UltPinSig")
                    {
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<UltValue>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<UltValue>().Pause);
                        pm = other.GetComponent<UltSig>();

                        Manager.ultRead = other.gameObject.GetComponentInParent<UltValue>().Read;
                        Manager.type = GameManager.SensorType.Ult;

                    }
                    else if (other.name == "UltPinEcho")
                    {
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<UltValue>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<UltValue>().Pause);
                        pm = other.GetComponent<UltEcho>();
                        Manager.ultRead = other.gameObject.GetComponentInParent<UltValue>().Read;

                        Manager.type = GameManager.SensorType.Ult;

                    }
                    else if (other.name == "UltPinGND")
                    {
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<UltValue>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<UltValue>().Pause);
                        pm = other.GetComponent<UltGND>();

                    }
                    else if (other.name == "DCPinPlus")
                    {
                        Manager.parent = other.gameObject;
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<DCPlus>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<DCPlus>().Pause);
                        l298ndigi = other.GetComponent<DCPlus>();
                    }
                    else if (other.name == "DCPinMin")
                    {
                        Manager.parent = other.gameObject;
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<DCMin>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<DCMin>().Pause);
                        l298ndigi = other.GetComponent<DCMin>();
                    }
                    else if (other.name == "TempMin")
                    {
                        pm = other.GetComponent<TempHumiGND>();
                    }
                    else if (other.name == "TempDig")
                    {
                        pm = other.GetComponent<TempHumiDigital>();
                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<TempHumiParent>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<TempHumiParent>().Pause);


                        // ==========새로 만든 코드 ===============//
                        Manager.type = GameManager.SensorType.HumiTemp;

                        Manager.humitempRead = other.gameObject.GetComponentInParent<TempHumiParent>().Read;
                    }
                    else if (other.name == "TempPlus")
                    {
                        pm = other.GetComponent<TempHumiVCC>();
                    }
                    else if (other.name == "IllPinOUT")
                    {
                        pm = other.GetComponent<IllOUT>();

                        Manager.run = new LineManager.RunDelegate(other.gameObject.GetComponentInParent<lightSensor>().Run);
                        Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<lightSensor>().Pause);



                        //// ==== 새로 만든 코드 ======//
                        Manager.type = GameManager.SensorType.Lux;
                        Manager.luxRead = other.gameObject.GetComponentInParent<lightSensor>().Read;
                    }
                    else if (other.name == "IllPinVCC")
                    {
                        pm = other.GetComponent<IllVCC>();
                    }
                    else if (other.name == "IllPinGND")
                    {
                        pm = other.GetComponent<IllGND>();
                    }
                    break;

                case "OUTPUT":
                    Manager.Connect2 = 1;
                    if (other.name == "SubPinSig")
                    {
                        Manager.servorun = new LineManager.RunServo(other.gameObject.GetComponentInParent<ServoManager>().Run);
                        //  Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<SpinSub>().Pause);
                        pm = other.GetComponent<SubSig>();

                        Manager.type = GameManager.SensorType.Servo;
                    }
                    else if (other.name == "SubPinPlus")
                    {
                        Manager.servorun = new LineManager.RunServo(other.gameObject.GetComponentInParent<ServoManager>().Run);
                        // Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<SpinSub>().Pause);
                        pm = other.GetComponent<SubPlus>();
                    }
                    else if (other.name == "SubPinMin")
                    {
                        Manager.servorun = new LineManager.RunServo(other.gameObject.GetComponentInParent<ServoManager>().Run);
                        // Manager.pause = new LineManager.PauseDelegate(other.gameObject.GetComponentInParent<SpinSub>().Pause);
                        pm = other.GetComponent<SubMin>();
                    }
                    break;

                case "L298N_OUT":
                    // socket = other.gameObject;
                    Manager.Connect2 = 1;
                    l298n = other.GetComponent<L298NOUT4>();
                    Manager.L298N_OUTCONNECT = true;

                    break;
                case "L298N_GND":
                    Manager.Connect2 = 1;
                    //socket = other.gameObject;
                    l298n_gnd = other.GetComponent<L298N_GND>();
                    //Manager.parent = other.gameObject;
                    break;
                case "L298N_VCC":
                    Manager.Connect2 = 1;
                    if (other.name == "12V")
                    {
                        l298n_vcc12 = other.GetComponent<L298N_VCC12v>();
                    }
                    else if (other.name == "5V")
                    {
                        l298n_vcc5 = other.GetComponent<L298N_VCC5v>();
                    }
                    break;
                case "L298N_DIGITAL":
                    if (other.name == "OUT1PIN")
                    {
                        l298ndigi = other.GetComponent<L298N_DIGITAL>();
                        Manager.run = new LineManager.RunDelegate(l298ndigi.Run);
                        Manager.pause = new LineManager.PauseDelegate(l298ndigi.Pause);

                        Manager.type = GameManager.SensorType.l298n;

                    }
                    else if (other.name == "OUT2PIN")
                    {
                        l298ndigi = other.GetComponent<L298N_DIGITAL2>();
                        Manager.run = new LineManager.RunDelegate(l298ndigi.Run);
                        Manager.pause = new LineManager.PauseDelegate(l298ndigi.Pause);

                        Manager.type = GameManager.SensorType.l298n;
                    }
                    else if (other.name == "OUT3PIN")
                    {
                        l298ndigi = other.GetComponent<L298N_DIGITAL3>();
                        Manager.run = new LineManager.RunDelegate(l298ndigi.Run);
                        Manager.pause = new LineManager.PauseDelegate(l298ndigi.Pause);

                        Manager.type = GameManager.SensorType.l298n;
                    }
                    else if (other.name == "OUT4PIN")
                    {
                        l298ndigi = other.GetComponent<L298N_DIGITAL4>();
                        Manager.run = new LineManager.RunDelegate(l298ndigi.Run);
                        Manager.pause = new LineManager.PauseDelegate(l298ndigi.Pause);

                        Manager.type = GameManager.SensorType.l298n;
                    }
                    break;
                case "BreadPin":
                    Manager.Connect2 = 1;
                    // Manager.parent = other.gameObject;
                    Manager.plusGroup = other.gameObject.GetComponentInParent<PlusGroup>();
                    pm = other.GetComponent<BreadBoardPin>();
                    Manager.type = GameManager.SensorType.Bread;
                    break;
                case "BreadDIGITAL":
                    Manager.Connect2 = 1;
                    Manager.parent = other.gameObject;
                    Manager.plusGroup = other.gameObject.GetComponentInParent<PlusGroup>();
                    pm = other.GetComponent<BreadBoardPin>();
                    Manager.type = GameManager.SensorType.Bread;
                    break;
                case "BreadGND":
                    Manager.Connect2 = 1;
                    Manager.parent = other.gameObject;
                    Manager.plusGroup = other.gameObject.GetComponentInParent<PlusGroup>();
                    pm = other.GetComponent<BreadBoardPin>();
                    Manager.type = GameManager.SensorType.Bread;
                    break;
                case "BreadPlus":
                    Manager.Connect2 = 1;
                    Manager.parent = other.gameObject;
                    Manager.plusGroup = other.gameObject.GetComponentInParent<PlusGroup>();
                    pm = other.GetComponent<BreadBoardPin>();
                    Manager.type = GameManager.SensorType.Bread;
                    break;
                case "resister":
                    Manager.Connect2 = 1;
                    resi = other.GetComponentInParent<Resist>();
                    if (Manager.parent == null)
                    {

                        //저항이랑 모터  빵판 등등 연결되었을때
                        Manager.parent = other.gameObject;

                    }
                    else if (Manager.parent.tag == "DIGITAL")
                    {
                        if (resi != null)

                        { //저항이랑 DIGITAL이 연결되었을떄
                            if (resi.run != null)
                            {
                                Manager.run = new LineManager.RunDelegate(resi.run);
                            }


                            if (resi.servorun != null)
                            {
                                Manager.servorun = new LineManager.RunServo(resi.servorun);
                            }


                            if (resi.plusgroup != null)
                            {
                                Manager.plusGroup = resi.plusgroup;
                            }
                        }
                    }
                    break;


            
        }





    }





    /*private void OnTriggerExit(Collider other)
    {
        /*  if (other.tag == "Plus" || other.tag == "Minus")
          {
              Manager.plusElectric = 0;
              Manager.minusElectric = 0;
              Manager.ConnectBattery = false;
          }
          Manager.Electro = 0;
          Manager.Connect2 = 0;
    }*/


    private void OnMouseDown()
    {

        if (Mousepoint.MouseInstance().MouseChecking == false)
        {

            Manager.DigitalConnect = false;
            Manager.GNDConnect = false;
            Manager.VccConnect = false;
            Manager.Connect2 = 0;
            Manager.DestroyObject();

        }
    }

    private void OnDisable()
    {
        try
        {
            if (socket != null)
            {
                if (socket == true)
                {

                    Manager.DigitalConnect = false;
                    Manager.GNDConnect = false;
                    Manager.VccConnect = false;
                    Manager.Connect2 = 0;

                    socket.GetComponent<Socket>().OnArround(true);
                }
            }
            else if (l298n_gnd != null)
            {
                if (l298n_gnd == true)
                {
                    Manager.DigitalConnect = false;
                    Manager.GNDConnect = false;
                    Manager.VccConnect = false;
                    Manager.Connect2 = 0;

                    l298n_gnd.OnArround(true);
                }
            }
            else if (l298n_vcc5 != null)
            {
                if (l298n_vcc5 == true)
                {
                    Manager.DigitalConnect = false;
                    Manager.GNDConnect = false;
                    Manager.VccConnect = false;
                    Manager.Connect2 = 0;

                    l298n_vcc5.OnArround(true);
                }
            }
            else if (l298n_vcc12 != null)
            {
                if (l298n_vcc12 == true)
                {
                    Manager.DigitalConnect = false;
                    Manager.GNDConnect = false;
                    Manager.VccConnect = false;
                    Manager.Connect2 = 0;

                    l298n_vcc12.OnArround(true);
                }
            }
            else if (l298n != null)
            {
                if (l298n == true)
                {
                    Manager.DigitalConnect = false;
                    Manager.GNDConnect = false;
                    Manager.VccConnect = false;
                    Manager.Connect2 = 0;

                    l298n.OnArround(true);
                }
            }
            else if (pm != null)
            {
                Manager.DigitalConnect = false;
                Manager.GNDConnect = false;
                Manager.VccConnect = false;
                Manager.Connect2 = 0;

                pm.OnArround(true);
            }
            else if (l298ndigi != null)
            {

                Manager.DigitalConnect = false;
                Manager.GNDConnect = false;
                Manager.VccConnect = false;
                Manager.Connect1 = 0;

                l298ndigi.OnArround(true);
            }
        }
        catch
        {
            Func(delegate () { return true; });
        }
    }

    void Func(Func<bool> callback)
    {
        callback();
    }


}
