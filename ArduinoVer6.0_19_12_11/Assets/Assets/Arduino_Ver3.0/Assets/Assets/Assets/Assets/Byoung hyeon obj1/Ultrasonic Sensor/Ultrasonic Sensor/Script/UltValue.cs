using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Ultrasonic
{
    HC_SR04, DYP_ME007TX_TTL232, GH_311, CustomUlt,
};
public class UltValue : MonoBehaviour
{
    public bool VccConnect;
    public bool GNDConnect;
    public bool DigitalConnect;
    public bool EchoPinConnet;

    public int VccPower = 0;

    public Transform other;
    public float closeDistance = 5.0f;
    

    private float maxDistance = 12000f;
    RaycastHit hit;
    public Vector3 ForwardDirection;
    Quaternion rotation;
    public bool RunLaser = false;
    public float sqrLen = 0;

    public Ultrasonic ultrasonic = Ultrasonic.HC_SR04;
    float distance = 10;
    public bool MouseClick = false;

    public float CustomDis = 4000;
    public float CustomWil = 30;

    //// Start is called before the first frame update
    void Start()
    {
        VccConnect = false;
        GNDConnect = false;
        DigitalConnect = false;
        EchoPinConnet = false;
        rotation = transform.rotation;
    }


    #region MouseDrag
    private void OnMouseDown()
    {
        distance = this.transform.position.z - Camera.main.transform.position.z;
    }

    private void OnMouseUp()
    {
        MouseClick = false;
    }

    void OnMouseDrag()
    {
        MouseClick = true;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            distance -= 10;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            distance += 10;
        }

        if (this.gameObject.layer == LayerMask.NameToLayer("Sensor"))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    Quaternion objRotation = Camera.main.transform.rotation;
        //    transform.rotation = objRotation;
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    Quaternion objRotation = Camera.main.transform.rotation;
        //    transform.rotation = objRotation;
        //}

    }
    #endregion


    IEnumerator Work()
    {
        ForwardDirection = transform.TransformDirection(0, 0, -1);

        if (VccConnect && GNDConnect && DigitalConnect && EchoPinConnet)
        {
            if (RunLaser)
            {
                bool isHit = false;
                switch (ultrasonic)
                {
                    case Ultrasonic.HC_SR04:
                        isHit =
                 Physics.BoxCast(transform.position,     //레이저를 발사할 위치
                 new Vector3(2.5f, 2.5f, 1),                   //사각형의 각 좌표의 절판 크기
                 ForwardDirection,                   //발사 방향
                 out hit,                                //충돌 결과
                 transform.rotation,                     //회전 각도
                 maxDistance                             //최대 거리
                 );
                        break;


                    case Ultrasonic.DYP_ME007TX_TTL232:
                        {
                            isHit =
             Physics.BoxCast(transform.position,     //레이저를 발사할 위치
           new Vector3(5, 5, 1),                   //사각형의 각 좌표의 절판 크기
           ForwardDirection,                   //발사 방향
           out hit,                                //충돌 결과
           transform.rotation,                     //회전 각도
           maxDistance                             //최대 거리
           );
                            break;
                        }


                    case Ultrasonic.GH_311:
                        isHit =
               Physics.BoxCast(transform.position,     //레이저를 발사할 위치
               new Vector3(5, 5, 1),                   //사각형의 각 좌표의 절판 크기
               ForwardDirection,                   //발사 방향
               out hit,                                //충돌 결과
               transform.rotation,                     //회전 각도
               maxDistance                             //최대 거리
               );
                        break;

                    case Ultrasonic.CustomUlt:
                        isHit =
                 Physics.BoxCast(transform.position,     //레이저를 발사할 위치
                 new Vector3(CustomWil / 6, CustomWil / 6, 1),                   //사각형의 각 좌표의 절판 크기
                 ForwardDirection,                   //발사 방향
                 out hit,                                //충돌 결과
                 transform.rotation,                     //회전 각도
                 CustomDis                             //최대 거리
                 );
                        break;
                }


                Gizmos.color = Color.red;

                if (isHit)
                {
                    other = hit.transform;
                    if (other)
                    {
                        Vector3 offset = other.position - transform.position;

                        switch (ultrasonic)
                        {
                            case Ultrasonic.HC_SR04:
                                sqrLen = offset.magnitude;
                                closeDistance = sqrLen / 3;


                                GameManager.distance = closeDistance;

                                break;
                            case Ultrasonic.DYP_ME007TX_TTL232:
                                sqrLen = offset.magnitude;
                                closeDistance = sqrLen / 3;
                                //Debug.Log(closeDistance + "cm");

                                GameManager.distance = closeDistance;

                                break;
                            case Ultrasonic.GH_311:
                                sqrLen = offset.magnitude;
                                closeDistance = sqrLen / 3;
                                //Debug.Log(closeDistance + "cm");

                                GameManager.distance = closeDistance;

                                break;
                            case Ultrasonic.CustomUlt:
                                sqrLen = offset.magnitude;
                                closeDistance = sqrLen / 3;
                                //Debug.Log(closeDistance + "cm");

                                GameManager.distance = closeDistance;

                                break;
                        }

                    }
                }
            }
        }

       

        yield return new WaitForSecondsRealtime(0.3f);

     //   if (RunLaser == true) StartCoroutine(Work());
    }


    //private void Update()
    //{

    //    ForwardDirection = transform.TransformDirection(0, 0, -1);

    //    if (VccConnect && GNDConnect && DigitalConnect)
    //    {
    //        if (RunLaser)
    //        {
    //            bool isHit =
    //           Physics.BoxCast(transform.position,     //레이저를 발사할 위치
    //           new Vector3(5, 5, 1),                   //사각형의 각 좌표의 절판 크기
    //           ForwardDirection,                   //발사 방향
    //           out hit,                                //충돌 결과
    //           transform.rotation,                     //회전 각도
    //           maxDistance                             //최대 거리
    //           );

    //            Gizmos.color = Color.red;

    //            if (isHit)
    //            {
    //                other = hit.transform;
    //                if (other)
    //                {
    //                    Vector3 offset = other.position - transform.position;
    //                    sqrLen = offset.magnitude;
    //                    closeDistance = sqrLen/3f;
    //                    Debug.Log(closeDistance + "cm");

    //                    GameManager.distance = closeDistance;
    //                }
    //                //Gizmos.DrawRay(transform.position, ForwardDirection * hit.distance);
    //               // Gizmos.DrawWireCube(transform.position + ForwardDirection * hit.distance,
    //                //                    new Vector3(11, 10, 1));
    //                //사각형의 각 좌표의 절판 크기
    //            }
    //            else
    //            {
    //              //  Gizmos.DrawRay(transform.position, ForwardDirection * maxDistance);
    //            }
    //        }
    //    }

    //}

    /*   void OnDrawGizmos()
       {
           if (VccConnect && GNDConnect && DigitalConnect)
           {
               if (RunLaser)
               {
                   bool isHit =
                  Physics.BoxCast(transform.position,     //레이저를 발사할 위치
                  new Vector3(5, 5, 1),                   //사각형의 각 좌표의 절판 크기
                  ForwardDirection,                   //발사 방향
                  out hit,                                //충돌 결과
                  transform.rotation,                     //회전 각도
                  maxDistance                             //최대 거리
                  );

                   Gizmos.color = Color.red;

                   if (isHit)
                   {
                       other = hit.transform;
                       if (other)
                       {
                           Vector3 offset = other.position - transform.position;
                           sqrLen = offset.sqrMagnitude;
                           closeDistance = sqrLen;

                           Debug.Log(sqrLen);
                           GameManager.distance = sqrLen;
                       }
                       //Gizmos.DrawRay(transform.position, ForwardDirection * hit.distance);
                       Gizmos.DrawWireCube(transform.position + ForwardDirection * hit.distance,
                                           new Vector3(11, 10, 1));
                       //사각형의 각 좌표의 절판 크기
                   }
                   else
                   {
                       Gizmos.DrawRay(transform.position, ForwardDirection * maxDistance);
                   }
               }
           }

           #region
           // Physics.BoxCast (레이저를 발사할 위치, 사각형의 각 좌표의 절판 크기, 발사 방향, 충돌 결과, 회전 각도, 최대 거리)
           //if (VccConnect == true && GNDConnect == true)
           //  {
           //      bool isHit =
           //    Physics.BoxCast(transform.position,     //레이저를 발사할 위치
           //    new Vector3(5, 5, 1),                   //사각형의 각 좌표의 절판 크기
           //    ForwardDirection,                   //발사 방향
           //    out hit,                                //충돌 결과
           //    transform.rotation,                     //회전 각도
           //    maxDistance                             //최대 거리
           //    );

           //      Gizmos.color = Color.red;

           //      if (isHit)
           //      {
           //          other = hit.transform;
           //          if (other)
           //          {
           //              Vector3 offset = other.position - transform.position;
           //              float sqrLen = offset.sqrMagnitude;
           //              closeDistance = sqrLen;

           //              Debug.Log(sqrLen);
           //          }
           //          //Gizmos.DrawRay(transform.position, ForwardDirection * hit.distance);
           //          Gizmos.DrawWireCube(transform.position + ForwardDirection * hit.distance,
           //                              new Vector3(11, 10, 1));
           //          //사각형의 각 좌표의 절판 크기
           //      }
           //      else
           //      {
           //          Gizmos.DrawRay(transform.position, ForwardDirection * maxDistance);
           //      }
           //  }
           #endregion

       }*/

    public void Run()
    {
        RunLaser = true;

    }

    public void Pause()
    {
        RunLaser = false;
    }


    public float Read()
    {
        RunLaser = true;

        StartCoroutine(Work());

        return closeDistance;
    }


}
