using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    float force = 75f;
    Rigidbody2D rb;
    Vector2 position;
    float SpaseshipShiftFromBorder;
    bool accelerationLeft = false;
    bool accelerationRight = false;
    float velocityLastFrame;
    float MaxSpaceshipVelocity = 3f;

    public int lifes = 3;
    [SerializeField]
    GameObject Blow02;
    [SerializeField]
    GameObject Blow03;

    Timer transparentTimer;
    const float delayTransparentTimer = 0.1f;

    Timer destroyTimer;
    const float delayDestroy = 0.3f;

    Timer scoreMenuTimer;
    const float scoreMenuDelay = 0.5f;

    public Sprite empty;

    [SerializeField]
    GameObject lifeIndicator;

    [SerializeField]
    GameObject gameManager;

    GameManagerScript GMScript;

    public int Lifes
    {
        get { return lifes; }
        set { lifes = value; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force *= rb.mass;                              
        SpaseshipShiftFromBorder = (18 / 216.0f) * 4.5f;
        GMScript = gameManager.GetComponent<GameManagerScript>();
    }

    void Update()
    {
        ChangePosition();

        if (transparentTimer != null)
        {
            if (transparentTimer.Finished)
            {
                Object.Instantiate(Resources.Load("TransparentScoreMenu"));
                Destroy(transparentTimer);
            }
        }

        if (destroyTimer != null)
        {
            if (destroyTimer.Finished)
            {
                Destroy(destroyTimer);
                Instantiate(Blow03, transform.position, Quaternion.identity);
                AudioManager.Play(AudioClipName.SpaceshipBlow);
                transform.position = new Vector2(0, -17);

                if (PlayerPrefs.GetInt("vibrationIsOn") == 0)
                {
                    Handheld.Vibrate();
                }
            }
        }

        if (scoreMenuTimer != null)
        {
            if (scoreMenuTimer.Finished)
            {
                MenuManager.GoToMenu(MenuName.Score);
                SlDown();
                Destroy(scoreMenuTimer);
            }
        }
    }

    private void FixedUpdate()
    {
        if (accelerationLeft)
        {
            if (rb.velocity.x > -MaxSpaceshipVelocity) 
            {
                rb.AddForce(Vector2.left * force, ForceMode2D.Force);
            }
        }

        if (accelerationRight)
        {
            if (rb.velocity.x < MaxSpaceshipVelocity)
            {
                rb.AddForce(Vector2.right * force, ForceMode2D.Force);
            }
        }

        if(!accelerationLeft && !accelerationRight)
        {
            if (rb.velocity.x > 0 && velocityLastFrame > 0)
            {
                rb.AddForce(Vector2.left * force, ForceMode2D.Force);
            }
            else if (rb.velocity.x < 0 && velocityLastFrame < 0)
            {
                rb.AddForce(Vector2.right * force, ForceMode2D.Force);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }

        velocityLastFrame = rb.velocity.x;
    }

    public void MoveLeftButtonOnClickEvent()
    {
        rb.AddForce(Vector2.left * force, ForceMode2D.Force);
    }

    public void MoveLeftButtonOnEnterEvent(bool isEntered)
    {
        accelerationLeft = isEntered;        
    }

    public void MoveRightButtonOnClickEvent()
    {
        rb.AddForce(Vector2.right * force, ForceMode2D.Force);
    }

    public void MoveRightButtonOnEnterEvent(bool isEntered)
    {
        accelerationRight = isEntered;
    }

    void ChangePosition()
    {
        if (transform.position.x - SpaseshipShiftFromBorder < ScreenUtils.ScreenLeft)
        {
            position = transform.position;
            position.x = ScreenUtils.ScreenLeft + SpaseshipShiftFromBorder;
            rb.velocity = new Vector2(0, rb.velocity.y);
            transform.position = position;
        }
        if (transform.position.x + SpaseshipShiftFromBorder > ScreenUtils.ScreenRight)
        {
            position = transform.position;
            position.x = ScreenUtils.ScreenRight - SpaseshipShiftFromBorder;
            rb.velocity = new Vector2(0, rb.velocity.y);
            transform.position = position;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!GameObject.FindWithTag("ScoreMenu"))
        {
            if (coll.gameObject.CompareTag("Asteroid") || coll.gameObject.CompareTag("BossBullet"))
            {
                lifes--;
                Instantiate(Blow02, coll.transform.position, Quaternion.identity);
                AudioManager.PlayRandomBlow();
                Destroy(coll.gameObject);
                lifeIndicator.GetComponent<LifeIndicator>().Change(lifes);
                if (PlayerPrefs.GetInt("vibrationIsOn") == 0)
                {
                    Handheld.Vibrate();
                }
                if (lifes == 0)
                {
                    Object.Instantiate(Resources.Load("Transparent"));      // new

                    transparentTimer = gameObject.AddComponent<Timer>();
                    transparentTimer.Duration = delayTransparentTimer;
                    transparentTimer.Run();
                    destroyTimer = gameObject.AddComponent<Timer>();
                    destroyTimer.Duration = delayDestroy;
                    destroyTimer.Run();
                    scoreMenuTimer = gameObject.AddComponent<Timer>();
                    scoreMenuTimer.Duration = scoreMenuDelay;
                    scoreMenuTimer.Run();
                }
            }

            if (coll.gameObject.CompareTag("Supernova"))
            {
                lifes=0;
                lifeIndicator.GetComponent<LifeIndicator>().Change(lifes);
                if (PlayerPrefs.GetInt("vibrationIsOn") == 0)
                {
                    Handheld.Vibrate();
                }
                if (lifes == 0)
                {
                    Object.Instantiate(Resources.Load("Transparent"));      // new

                    transparentTimer = gameObject.AddComponent<Timer>();
                    transparentTimer.Duration = 0.01f;
                    transparentTimer.Run();
                    destroyTimer = gameObject.AddComponent<Timer>();
                    destroyTimer.Duration = 0.02f;
                    destroyTimer.Run();
                    scoreMenuTimer = gameObject.AddComponent<Timer>();
                    scoreMenuTimer.Duration = scoreMenuDelay;
                    scoreMenuTimer.Run();
                }
            }
        }
        else
        {
            Destroy(coll.gameObject);
        }
    }

    private void SlDown()
    {
        Destroy(gameManager.GetComponent<Level1>());
        Destroy(gameManager.GetComponent<Level2>());
        Destroy(gameManager.GetComponent<Level3>());
        Destroy(gameManager.GetComponent<Level4>());

        GMScript.Boss1Killed = false;
        GMScript.Boss2Killed = false;
        GMScript.Boss3Killed = false;

        gameManager.GetComponent<MainMenu>().CleanScreenFromObjects();
    }
}
