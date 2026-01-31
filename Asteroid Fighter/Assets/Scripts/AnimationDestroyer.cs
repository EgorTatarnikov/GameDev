using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroyer : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    float animDuration = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= animDuration)
        {
            Destroy(gameObject);
        }
    }
}
