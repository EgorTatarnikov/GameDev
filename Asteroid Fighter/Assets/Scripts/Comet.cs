using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    Rigidbody2D rbSphere;
    float force = 0.8f;
    float torque = 0.001f;

    float directionX;
    float directionY;

    int healthValue = 3;
    int points = 25;

    [SerializeField]
    GameObject Blow01;
    [SerializeField]
    GameObject Blow02;

    [SerializeField]
    SpriteRenderer cometSphere;
    [SerializeField]
    SpriteRenderer cometTail;

    Timer dyingTimer;
    float dyingTimerDuration = 1.0f;

    [SerializeField]
    bool isRightComet = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force *= rb.mass;

        directionY = -1f;
        if (isRightComet)
        {
            directionX = -1f;
            torque *= rb.mass;
        }
        else
        {
            directionX = 1f;
            torque *= -rb.mass;
        }

        rb.AddForce(new Vector2(directionX, directionY) * force, ForceMode2D.Impulse);
        rbSphere.AddForce(new Vector2(directionX, directionY) * force, ForceMode2D.Impulse);
        rbSphere.AddTorque(torque, ForceMode2D.Impulse);

        dyingTimer = gameObject.AddComponent<Timer>();
        dyingTimer.Duration = dyingTimerDuration;
    }

    void Update()
    {
       if (dyingTimer.Running)
        {
            float transparency = (dyingTimerDuration - dyingTimer.CurrentTime) / dyingTimerDuration;
            cometTail.color = new Color(1,1,1, transparency);
        }
        if (dyingTimer.Finished)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < ScreenUtils.ScreenLeft - 1.5 || transform.position.x > ScreenUtils.ScreenRight + 1.5)
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

        if (healthValue < 0)
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().AddPoints(points);
            Instantiate(Blow02, transform.position, Quaternion.identity);
            Destroy(GetComponent<Collider2D>());
            cometSphere.color = new Color(1, 1, 1, 0);
            dyingTimer.Run();
            AudioManager.PlayRandomBlow();
        }
    }
}
