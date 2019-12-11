using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllValueStatic : MonoBehaviour
{
    [SerializeField] private float viewAngle; //시야각 120도
    [SerializeField] private float viewDistance; //시야거리 (10미터)
    [SerializeField] private LayerMask targetMask; //타겟 마스크(플레이어)
    [SerializeField] private float Value;
    public Light light;

    // Update is called once per frame
    void Update()
    {
        View();
    }

    //함수를 통해 시야각을 60도씩 꺾는다
    private Vector3 BoundaryAngle(float _angle)
    {
        //x가 꺾이면 z도 꺾이기 때문에 angle로 같이 꺾어주어야한다
        //z축 기준으로 이동한다.
        _angle += transform.eulerAngles.y;
        //삼각함수를 이용해 새로운 각도를 만들어 각도를 리턴시킨다.
        //cos(x)와 sin(z)를 이용해 p정점을 구한다
        //deg2rad를 이용하여 라디안값을 디그리로 바꾸어준다
        //원의 지름을 반지름값으로 바꾼다
        return new Vector3(Mathf.Sin(_angle * Mathf.Deg2Rad), 0f, Mathf.Cos(_angle * Mathf.Deg2Rad));
    }

    private void View()
    {
        Vector3 leftBoundary = BoundaryAngle(-viewAngle * 0.5f);
        Vector3 rightBoundary = BoundaryAngle(viewAngle * 0.5f);
        //시야각 설정 디버그
        Debug.DrawRay(transform.position, leftBoundary, Color.red);
        Debug.DrawRay(transform.position, rightBoundary, Color.red);

        //OverlapSphere 반경안에 있는 모든 콜라이더를 집어넣는 함수
        Collider[] _target = Physics.OverlapSphere(transform.position, viewDistance, targetMask);

        for (int i = 0; i < _target.Length; i++)
        {
            Transform _targetTf = _target[i].transform;
            //이름을 찾는 부분
            //레이어로 바꿀 수 있다
            if (_targetTf.name == "Light")
            {
                //normalized = 정규화
                Vector3 _direction = (_targetTf.position - transform.position).normalized;
                float _angle = Vector3.Angle(_direction, transform.up);
                float direct = (_targetTf.position - transform.position).magnitude;

                if (_angle < viewAngle * 0.5f)
                {
                    //닿아서 찾았을 때
                    RaycastHit _hit;
                    if (Physics.Raycast(transform.position, _direction, out _hit, viewDistance))
                    {
                        if (_hit.transform.name == "Light")
                        {
                            light = _hit.transform.GetComponent<Light>();
                            Value = (((light.intensity * direct) / light.range) / light.spotAngle) * 100f;
                            Debug.Log(Value);
                            Debug.DrawRay(transform.position, _direction, Color.green);
                        }
                    }
                }
            }
        }
    }
}
