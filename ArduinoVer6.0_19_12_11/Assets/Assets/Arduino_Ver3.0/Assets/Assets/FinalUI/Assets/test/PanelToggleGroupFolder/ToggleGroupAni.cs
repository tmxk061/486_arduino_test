using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroupAni : MonoBehaviour
{
    //애니메이션 호출
    public Animator anime;
    
    void Start()
    {
        //애니메이터 객체 얻기
        anime = GetComponent<Animator>();
    }
    
    void Update()
    {
        AnimetionActive();
    }

    //애니메이션 활성화 이벤트
    public void AnimetionActive()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            anime.SetBool("Start", true);
            anime.SetBool("End", false);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            anime.SetBool("End", true);
            anime.SetBool("Start", false);
        }
    }
}
