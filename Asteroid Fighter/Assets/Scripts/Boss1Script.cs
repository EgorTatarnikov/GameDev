using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Script : MonoBehaviour
{
    #region Fields

    float force = 5f;
    Rigidbody2D rb;
    float shiftFromBorder;
    float maxVelocity = 2f;
    Vector2 position;
    bool accelerationLeft = false;
    bool accelerationRight = false;

    Timer gunTimer;
    float gunTimerDurationMin = 0.8f;
    float gunTimerDurationMax = 1.4f;

    Timer spriteChangeTimer;
    float spriteChangeTimerDuration = 0.25f;

    Timer changeDirectionTimer;
    float changeDirectionTimerDurationMin = 0.5f;
    float changeDirectionTimerDurationMax = 3f;

    [SerializeField] 
    GameObject gun;
    [SerializeField]
    Sprite gun1;
    [SerializeField]
    Sprite gun2;

    int healthValue = 48;
    int points = 100;

    [SerializeField]
    GameObject Blow01;
    [SerializeField]
    GameObject Blow02;

    [SerializeField]
    SpriteRenderer damage1;
    [SerializeField]
    SpriteRenderer damage2;

    GameObject gameManager;
    GameManagerScript GMScript;

    #endregion

    #region UnityMethods
    void Start()
    {
        gunTimer = gameObject.AddComponent<Timer>();
        gunTimer.Duration = 2.0f;
        gunTimer.Run();

        spriteChangeTimer = gameObject.AddComponent<Timer>();
        spriteChangeTimer.Duration = spriteChangeTimerDuration;

        changeDirectionTimer = gameObject.AddComponent<Timer>();
        changeDirectionTimer.Duration = 1.0f;
        changeDirectionTimer.Run();


        rb = GetComponent<Rigidbody2D>();
        force *= rb.mass;
        shiftFromBorder = (18 / 216.0f) * 4.5f;

        transform.position = new Vector2(Random.Range(ScreenUtils.ScreenLeft + 1, ScreenUtils.ScreenRight - 1), ScreenUtils.ScreenTop + 0.5f);
        rb.velocity = new Vector2(0, -2.5f);

        damage1.enabled = false;
        damage2.enabled = false;

        gameManager = GameObject.FindWithTag("GameManager");
        GMScript = gameManager.GetComponent<GameManagerScript>();
    }

    void Update()
    {
        if (transform.position.y<ScreenUtils.ScreenTop - 1.2f)
        {
            transform.position = new Vector2(transform.position.x, ScreenUtils.ScreenTop - 1.2f);
        }
        ChangePositionBorder();
        ChangeDirectionRandom();
        Fire();

        if (transform.position.y > ScreenUtils.ScreenTop + 5.0f)
        {
            Destroy(gameObject);
        }
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
            Instantiate(Blow01, new Vector2(coll.transform.position.x, coll.transform.position.y + 0.1f), Quaternion.identity);
            Destroy(coll.gameObject);
            AudioManager.Play(AudioClipName.LittleBlow);
        }

        if (healthValue <= 32 && damage1.enabled == false)
        {
            damage1.enabled = true;
        }

        if (healthValue <= 16 && damage2.enabled == false)
        {
            damage2.enabled = true;
        }

        if (healthValue < 1)
        {
            Vector2 middlePos = new Vector2((coll.transform.position.x + transform.position.x) / 2, (coll.transform.position.y + transform.position.y) / 2);
            GMScript.AddPoints(points);
            GMScript.Boss1Killed = true;
            Instantiate(Blow02, middlePos, Quaternion.identity);
            Destroy(gameObject);
            AudioManager.PlayRandomBlow();
        }
    }
    #endregion

    #region MyMethods
    void ChangePositionBorder()
    {
        position = transform.position;
        if (position.x - shiftFromBorder < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + shiftFromBorder;
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            accelerationLeft = false;
            accelerationRight = true;
        }
        if (position.x + shiftFromBorder > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - shiftFromBorder;
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            accelerationLeft = true;
            accelerationRight = false;
        }
        transform.position = position;
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
            spriteChangeTimer.Run();
            gun.GetComponent<SpriteRenderer>().sprite = gun2;
            Vector2 location = new Vector2(transform.position.x, transform.position.y-0.5f);
            if (gameManager.GetComponent<AsteroidSpawner>() != null)
            {
                gameManager.GetComponent<AsteroidSpawner>().SpawnLittleAsteroid(location);
                AudioManager.Play(AudioClipName.Puff);
            }
            gunTimer.Duration = Random.Range(gunTimerDurationMin, gunTimerDurationMax);
            gunTimer.Run();
        }
        if (spriteChangeTimer.Finished)
        {
            gun.GetComponent<SpriteRenderer>().sprite = gun1;
        }
    }
    #endregion
}
