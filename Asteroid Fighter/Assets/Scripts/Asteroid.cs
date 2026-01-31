using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float force = 1f;
    [SerializeField]
    float torque = 0.1f;
    [SerializeField]
    float directionRandomRange = 1.25f;
    float directionX;
    float directionY;
    [SerializeField]
    float colliderRadius = 0.25f;

    [SerializeField]
    int healthValue = 5;
    [SerializeField]
    int points = 1;

    [SerializeField]
    bool triple = false;
    [SerializeField]
    GameObject littleAsteroid1;
    [SerializeField]
    GameObject littleAsteroid2;
    [SerializeField]
    GameObject littleAsteroid3;

    [SerializeField]
    GameObject Blow01;
    [SerializeField]
    GameObject Blow02;

    public int HealthValue
    {
        get { return healthValue; }
        set { healthValue = value; }
    }

    void Start()
    {
        directionX = Random.Range(-directionRandomRange, directionRandomRange);
        directionY = -0.8f * ScreenUtils.ScreenCoefficient;
        rb = GetComponent<Rigidbody2D>();
        force *= rb.mass;
        torque *= rb.mass;
        rb.AddForce(new Vector2 (directionX, directionY) * force, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-torque, torque), ForceMode2D.Impulse);
    }

    void Update()
    {
        if (transform.position.x < (ScreenUtils.ScreenLeft + colliderRadius) &&
            rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
        if (transform.position.x > (ScreenUtils.ScreenRight - colliderRadius) &&
            rb.velocity.x > 0)
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }

    private void OnBecameInvisible()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            healthValue--;
            Instantiate(Blow01, coll.transform.position, Quaternion.identity);
            Destroy(coll.gameObject);
            AudioManager.Play(AudioClipName.LittleBlow);
        }

        if (healthValue < 1)
        {
            Vector2 middlePos = new Vector2((coll.transform.position.x + transform.position.x) / 2, (coll.transform.position.y + transform.position.y) / 2);
            GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().AddPoints(points);

            Instantiate(Blow02, middlePos, Quaternion.identity);
            if (triple)
            {
                Object.Instantiate(littleAsteroid1, new Vector2(transform.position.x, transform.position.y - 0.1f), Quaternion.identity);
                Object.Instantiate(littleAsteroid2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Object.Instantiate(littleAsteroid3, new Vector2(transform.position.x, transform.position.y + 0.1f), Quaternion.identity);
            }
            Destroy(gameObject);
            AudioManager.PlayRandomBlow();
        }
    }
}
