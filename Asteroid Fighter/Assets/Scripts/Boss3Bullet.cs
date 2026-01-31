using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Bullet : MonoBehaviour
{
    Rigidbody2D rb;

    float force = 3.25f;

    void Start()
    {
        force *= ScreenUtils.ScreenCoefficient * ScreenUtils.ScreenCoefficientSqrt;
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Mathf.Sin(transform.eulerAngles.z * Mathf.PI / 180.0f), - Mathf.Cos(transform.eulerAngles.z * Mathf.PI / 180.0f));
        direction.Normalize();
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        AudioManager.Play(AudioClipName.Shot);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
