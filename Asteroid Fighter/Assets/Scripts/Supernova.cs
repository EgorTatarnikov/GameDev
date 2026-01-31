using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supernova : MonoBehaviour
{
    Rigidbody2D rb;
    float force = 1f;
    float torque = 0.2f;
    float directionX;
    float directionY;

    int healthValue = 5;
    int points = 35;

    [SerializeField]
    GameObject Blow01;
    [SerializeField]
    GameObject Blow02;

    float distance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force *= rb.mass;
        torque *= -rb.mass;

        directionX = 0f;
        directionY = -0.8f * ScreenUtils.ScreenCoefficient;

        rb.AddForce(new Vector2(directionX, directionY) * force, ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Impulse);

        rb.transform.eulerAngles = new Vector3(0, 0, Random.Range(-180, 180));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            AudioManager.Play(AudioClipName.Wooow);  //new
            healthValue--;
            if (healthValue >= 0)
            {
                Instantiate(Blow01, transform.position, Quaternion.identity);
                GameObject.FindWithTag("SupernovasBlow").GetComponent<Rigidbody2D>().AddForce(new Vector2(directionX, directionY) * force, ForceMode2D.Impulse);
                Destroy(coll.gameObject);
            }
        }

        if (coll.gameObject.CompareTag("Spaceship"))
        {
            Destroy(gameObject.GetComponent<CircleCollider2D>());
            healthValue = 0;
            if (healthValue >= 0)
            {
                Instantiate(Blow01, transform.position, Quaternion.identity);
                GameObject.FindWithTag("SupernovasBlow").GetComponent<Rigidbody2D>().AddForce(new Vector2(directionX, directionY) * force, ForceMode2D.Impulse);
            }
        }

        if (healthValue == 0)
        {
            if (coll.gameObject.CompareTag("Bullet"))
            {
                GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().AddPoints(points);
                Destroy(coll.gameObject);
            }

            Instantiate(Blow02, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);

            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach (GameObject asteroid in asteroids)
            {
                distance = Vector3.Distance(transform.position, asteroid.transform.position);
                if (distance < 4.0f)
                {
                    Instantiate(Resources.Load("Blow05"), asteroid.transform.position, Quaternion.identity);
                    Destroy(asteroid);
                    AudioManager.PlayRandomBlow();
                }
            }
            AudioManager.PlayRandomBlow();
        }
    }

    private void OnBecameInvisible()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
