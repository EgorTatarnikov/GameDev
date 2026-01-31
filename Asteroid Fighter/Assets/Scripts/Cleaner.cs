using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    float timer1 = 0f;
    float timer1Duration = 3f;

    float xPlus = 10f;
    float xMinus = -10f;
    float yPlus = 20f;
    float yMinus = -20f;

    [SerializeField]
    Spaceship spaceshipScript;

    void Update()
    {

        timer1 += Time.deltaTime;
        if (timer1 > timer1Duration)
        {
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach (GameObject asteroid in asteroids)
            {
                if (asteroid.transform.position.x > xPlus || 
                    asteroid.transform.position.x < xMinus ||
                    asteroid.transform.position.y > yPlus ||
                    asteroid.transform.position.y < yMinus)
                {
                    Destroy(asteroid);
                }
            }

            GameObject boss1 = GameObject.FindGameObjectWithTag("Boss1");
            if (boss1 != null)
            {
                if (boss1.transform.position.x > xPlus ||
                    boss1.transform.position.x < xMinus ||
                    boss1.transform.position.y > yPlus ||
                    boss1.transform.position.y < yMinus)
                {
                    Destroy(boss1);
                }
            }

            GameObject boss2 = GameObject.FindGameObjectWithTag("Boss2");
            if (boss2 != null)
            {
                if (boss2.transform.position.x > xPlus ||
                    boss2.transform.position.x < xMinus ||
                    boss2.transform.position.y > yPlus ||
                    boss2.transform.position.y < yMinus)
                {
                    Destroy(boss2);
                }
            }

            GameObject boss3 = GameObject.FindGameObjectWithTag("Boss3");
            if (boss3 != null)
            {
                if (boss3.transform.position.x > xPlus ||
                    boss3.transform.position.x < xMinus ||
                    boss3.transform.position.y > yPlus ||
                    boss3.transform.position.y < yMinus)
                {
                    Destroy(boss3);
                }
            }

            GameObject comet = GameObject.FindGameObjectWithTag("Comet");
            if (comet != null)
            {
                if (comet.transform.position.x > xPlus ||
                    comet.transform.position.x < xMinus ||
                    comet.transform.position.y > yPlus ||
                    comet.transform.position.y < yMinus)
                {
                    Destroy(comet);
                }
            }

            GameObject[] bossBullets = GameObject.FindGameObjectsWithTag("BossBullet");
            foreach (GameObject bossBullet in bossBullets)
            {
                if (bossBullet.transform.position.x > xPlus ||
                    bossBullet.transform.position.x < xMinus ||
                    bossBullet.transform.position.y > yPlus ||
                    bossBullet.transform.position.y < yMinus)
                {
                    Destroy(bossBullet);
                }
            }

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in bullets)
            {
                if (bullet.transform.position.x > xPlus ||
                    bullet.transform.position.x < xMinus ||
                    bullet.transform.position.y > yPlus ||
                    bullet.transform.position.y < yMinus)
                {
                    Destroy(bullet);
                }
            }

            GameObject[] supernovas = GameObject.FindGameObjectsWithTag("Supernova");
            foreach (GameObject supernova in supernovas)
            {
                if (supernova.transform.position.x > xPlus ||
                    supernova.transform.position.x < xMinus ||
                    supernova.transform.position.y > yPlus ||
                    supernova.transform.position.y < yMinus)
                {
                    Destroy(supernova);
                }
            }

            timer1 = 0f;
        }
    }
}
