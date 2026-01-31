using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeIndicator : MonoBehaviour
{

    [SerializeField] 
    Image image;
    [SerializeField]
    Sprite lifes3;
    [SerializeField]
    Sprite lifes2;
    [SerializeField]
    Sprite lifes1;
    [SerializeField]
    Sprite lifes0;

    [SerializeField]
    Animator anim;
    int i = 0;

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= i)
        {
            anim.speed = 0;
        }
    }
    public void Change(int lifes)
    {
        if (lifes >= 3)
        {
            anim.speed = 1;
            i++;
            image.sprite = lifes3;
        }
        if (lifes == 2)
        {
            anim.speed = 1;
            i++;
            image.sprite = lifes2;
        }
        if (lifes == 1)
        {
            anim.speed = 1;
            i++;
            image.sprite = lifes1;
        }
        if (lifes <= 0)
        {
            anim.speed = 1;
            i++;
            image.sprite = lifes0;
        }
    } 
}
