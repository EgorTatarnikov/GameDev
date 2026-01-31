using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmassEggScript : MonoBehaviour
{
    Animator anim;
    int i = 0;

    Timer timer;
    float duration = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;

        timer = GetComponent<Timer>();
        timer.Duration = duration;
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= i)
        {
            anim.speed = 0;
        }
    }

    public void HandleChistmassEggButton()
    {
        if (!timer.Running)
        {
            anim.speed = 1;
            i++;
        }
        timer.Run();
    }
}
