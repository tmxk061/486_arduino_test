using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogWog : MonoBehaviour
{
    AudioSource audiosource;
    Animator animator;
    float count = 0;
    float timer = 0;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Random.Range(1.0f, 3.0f))
        {
            count = Random.Range(0, 10.0f);

            if (count > 5.0f)
            {
                animator.SetBool("WoW", true);
                audiosource.Play();
                Debug.Log(this.gameObject.name);

            }
            else
            {
                animator.SetBool("WoW", false);
            }
            timer = 0;

        }
    }


}
