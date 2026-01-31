using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Script : MonoBehaviour
{
    #region Fields

    float force = 5f;
    Rigidbody2D rb;
    float shiftFromBorder;
    float maxVelocity = 1.5f;
    Vector2 position;
    bool accelerationLeft = false;
    bool accelerationRight = false;

    Timer gunTimer;

    Timer changeDirectionTimer;
    float changeDirectionTimerDurationMin = 0.5f;
    float changeDirectionTimerDurationMax = 3f;

    Timer asteroidTimer;
    float asteroidTimerDuration = 1.2f;

    [SerializeField]
    GameObject gunLeftRotation;
    [SerializeField]
    GameObject gunLeftSpawnPosition;
    [SerializeField]
    GameObject gunRightRotation;
    [SerializeField]
    GameObject gunRightSpawnPosition;

    bool isLeftGun = true;

    int healthValue = 72;
    int points = 350;

    [SerializeField]
    GameObject Blow01;
    [SerializeField]
    GameObject Blow02;

    [SerializeField]
    SpriteRenderer damage1;
    [SerializeField]
    SpriteRenderer damage2;

    GameObject spaceship;
    GameObject gameManager;
    GameManagerScript GMScript;

    #endregion

    #region UnityMethods
    void Start()
    {
        gunTimer = gameObject.AddComponent<Timer>();
        gunTimer.Duration = 1.1f;
        gunTimer.Run();

        changeDirectionTimer = gameObject.AddComponent<Timer>();
        changeDirectionTimer.Duration = 1.0f;
        changeDirectionTimer.Run();

        asteroidTimer = gameObject.AddComponent<Timer>();
        asteroidTimer.Duration = asteroidTimerDuration;
        asteroidTimer.Run();


        rb = GetComponent<Rigidbody2D>();
        force *= rb.mass;
        shiftFromBorder = (32 / 216.0f) * 4.5f;

        transform.position = new Vector2(Random.Range(ScreenUtils.ScreenLeft + 1, ScreenUtils.ScreenRight - 1), ScreenUtils.ScreenTop + 0.7f);
        rb.velocity = new Vector2(0, -2.5f);

        damage1.enabled = false;
        damage2.enabled = false;

        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        gameManager = GameObject.FindWithTag("GameManager");
        GMScript = gameManager.GetComponent<GameManagerScript>();

    }

    void Update()
    {
        if (transform.position.y < ScreenUtils.ScreenTop - 1.25f)
        {
            transform.position = new Vector2(transform.position.x, ScreenUtils.ScreenTop - 1.25f);
        }
        ChangePositionBorder();
        ChangeDirectionRandom();
        Fire();
        AsteroidFire();

        if (transform.position.y > ScreenUtils.ScreenTop + 5.0f)
        {
            Destroy(gameObject);
        }

        float deltaX = spaceship.transform.position.x - transform.position.x;
        float deltaY = transform.position.y - spaceship.transform.position.y;
        float angleZ = Mathf.Atan2(deltaX, deltaY) * 180f / Mathf.PI;
        gunLeftRotation.transform.eulerAngles = new Vector3(0, 0, (angleZ + 3));
        gunRightRotation.transform.eulerAngles = new Vector3(0, 0, (angleZ - 3));
    }

    private void FixedUpdate()
    {
        if (accelerationLeft)
        {
            if (rb.velocity.x > -maxVelocity)
            {
                rb.AddForce(Vector2.left * force, ForceMode2D.Force);
            }
        }

        if (accelerationRight)
        {
            if (rb.velocity.x < maxVelocity)
            {
                rb.AddForce(Vector2.right * force, ForceMode2D.Force);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            healthValue--;
            Instantiate(Blow01, new Vector2(coll.transform.position.x, coll.transform.position.y + 0.05f), Quaternion.identity);
            Destroy(coll.gameObject);
            AudioManager.Play(AudioClipName.LittleBlow);
        }

        if (healthValue <= 48 && damage1.enabled == false)
        {
            damage1.enabled = true;
        }

        if (healthValue <= 24 && damage2.enabled == false)
        {
            damage2.enabled = true;
        }

        if (healthValue < 1)
        {
            Vector2 Pos = new Vector2(transform.position.x, transform.position.y + 0.05f);
            GMScript.AddPoints(points);
            GMScript.Boss3Killed = true;
            Instantiate(Blow02, Pos, Quaternion.identity);
            Destroy(gameObject);
            AudioManager.Play(AudioClipName.Boss3Blow);
        }
    }
    #endregion

    #region MyMethods
    void ChangePositionBorder()
    {
        if (transform.position.x - shiftFromBorder < ScreenUtils.ScreenLeft)
        {
            position = transform.position;
            position.x = ScreenUtils.ScreenLeft + shiftFromBorder;
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            accelerationLeft = false;
            accelerationRight = true;
            transform.position = position;
        }
        if (transform.position.x + shiftFromBorder > ScreenUtils.ScreenRight)
        {
            position = transform.position;
            position.x = ScreenUtils.ScreenRight - shiftFromBorder;
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            accelerationLeft = true;
            accelerationRight = false;
            transform.position = position;
        }
    }

    void ChangeDirectionRandom()
    {
        if (changeDirectionTimer.Finished)
        {
            int left = Random.Range(0, 2);
            if (left == 1)
            {
                accelerationLeft = true;
                accelerationRight = false;
            }
            else
            {
                accelerationLeft = false;
                accelerationRight = true;
            }
            changeDirectionTimer.Duration = Random.Range(changeDirectionTimerDurationMin, changeDirectionTimerDurationMax);
            changeDirectionTimer.Run();
        }
    }

    void Fire()
    {
        if (gunTimer.Finished)
        {
            if (isLeftGun)
            {
                Object.Instantiate(Resources.Load("Boss3Bullet"), gunLeftSpawnPosition.transform.position, gunLeftSpawnPosition.transform.rotation);
                gunTimer.Duration = 0.6f;
            }
            else
            {
                Object.Instantiate(Resources.Load("Boss3Bullet"), gunRightSpawnPosition.transform.position, gunRightSpawnPosition.transform.rotation);
                gunTimer.Duration = 1.9f;
            }
            gunTimer.Run();
            isLeftGun = !isLeftGun;
        }
    }

    void AsteroidFire()
    {
        if (asteroidTimer.Finished)
        {
            Vector2 location = new Vector2(transform.position.x, transform.position.y - 0.75f);
            if (gameManager.GetComponent<AsteroidSpawner>() != null)
            {
                gameManager.GetComponent<AsteroidSpawner>().SpawnLittleAsteroid(location);
                AudioManager.Play(AudioClipName.Puff);
            }
            asteroidTimer.Run();
        }
    }

    #endregion
}
