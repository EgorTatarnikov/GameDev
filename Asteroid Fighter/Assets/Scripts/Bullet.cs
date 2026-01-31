using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] 
    float force = 5.2f;

    void Start()
    {
        force *= ScreenUtils.ScreenCoefficient * ScreenUtils.ScreenCoefficientSqrt;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        AudioManager.Play(AudioClipName.Shot);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
