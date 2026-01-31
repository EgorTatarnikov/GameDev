using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject spaceship;
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject guiUp;
    [SerializeField]
    GameObject guiDown;

    float slideSpeed = 9000.0f;
    bool slideUpInitator = false;
    bool slideDownInitator = false;

    Vector2 spaceshipPosition = new Vector2( 0, -17);
    Vector2 mainMenuPosition = new Vector2( 0, 0);
    Vector2 guiUpPosition = new Vector2( 0, -3000);
    Vector2 guiDownPosition = new Vector2(0, -3000);

    Rigidbody2D spaceshipRB2D;

    //AsteroidSpawner asteroidSpawner;

    PrintInfiniteEvent printInfiniteEvent = new PrintInfiniteEvent();               //////////// Declaring event

    bool isInfiniteLevel = false;

    [SerializeField]
    GameManagerScript GMScript;

    #endregion

    #region Properties
    public bool SlideDownInitator
    {
        get { return slideDownInitator; }
        set { slideDownInitator = value; }
    }

    public bool IsInfiniteLevel
    {
        get { return isInfiniteLevel; }
        set { isInfiniteLevel = value; }
    }
    #endregion

    #region Methods
    void Start()
    {
        spaceshipRB2D = spaceship.GetComponent<Rigidbody2D>();
        EventManager.AddInvokerPrintInfiniteEvent(this);                            //////////// Adding itself as event invoker
    }
    private void FixedUpdate()
    {
        if (slideUpInitator)
        {
            SlideUp();

        }

        if (slideDownInitator)
        {
            SlideDown();
        }
    }

    public void AddPrintInfiniteEvent(UnityAction listener)                         //////////// For Adding event listeners and invokers
    {
        printInfiniteEvent.AddListener(listener);
    }


    public void HandlePlayButtonOnClickEvent()
    {
        //gameObject.AddComponent<AsteroidSpawner>();
        spaceship.GetComponent<Spaceship>().Lifes = 3;
        GameObject.FindWithTag("LifesIndicator").GetComponent<LifeIndicator>().Change(spaceship.GetComponent<Spaceship>().Lifes);
        GMScript.CurrentScore = 0;
        slideUpInitator = true;
        gameObject.GetComponent<AsteroidSpawner>().FirstLevel();
        isInfiniteLevel = false;
    }

    public void HandleInfiniteGameButtonOnClickEvent()
    {
        //gameObject.AddComponent<AsteroidSpawner>();
        spaceship.GetComponent<Spaceship>().Lifes = 3;
        GameObject.FindWithTag("LifesIndicator").GetComponent<LifeIndicator>().Change(spaceship.GetComponent<Spaceship>().Lifes);
        GMScript.CurrentScore = 0;
        slideUpInitator = true;
        gameObject.GetComponent<AsteroidSpawner>().InfiniteLevel();
        isInfiniteLevel = true;
        printInfiniteEvent.Invoke();                                                //////////// Invoking event
    }

    public void HandleOptionButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Option);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }

    public void HandleOptionGameplayButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Pause);
    }

    public void SlideUp()
    {
        spaceshipRB2D.velocity = new Vector2(0, 0);
        spaceshipPosition.y += slideSpeed / 200 * Time.deltaTime;
        mainMenuPosition.y += slideSpeed * Time.deltaTime;
        guiUpPosition.y += slideSpeed * Time.deltaTime;
        guiDownPosition.y += slideSpeed * Time.deltaTime;

        spaceship.transform.position = spaceshipPosition;
        mainMenu.GetComponent<RectTransform>().anchoredPosition = mainMenuPosition;
        guiUp.GetComponent<RectTransform>().anchoredPosition = guiUpPosition;
        guiDown.GetComponent<RectTransform>().anchoredPosition = guiDownPosition;

        if (spaceshipPosition.y > (-2.2f * ScreenUtils.ScreenCoefficient))
        {
            slideUpInitator = false;
            spaceship.transform.position = new Vector2(0, -2.2f * ScreenUtils.ScreenCoefficient);
            mainMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 3000);
            guiUp.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            guiDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }

        GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().LastRecord = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>().RecordScore;
    }

    public void SlideDown()
    {
        Destroy(gameObject.GetComponent<Level1>());
        Destroy(gameObject.GetComponent<Level2>());
        Destroy(gameObject.GetComponent<Level3>());
        Destroy(gameObject.GetComponent<Level4>());
        isInfiniteLevel = false;
        GMScript.Boss1Killed = false;
        GMScript.Boss2Killed = false;
        GMScript.Boss3Killed = false;

        gameObject.GetComponent<Timer>().Stop();
       

        CleanScreenFromObjects();

        spaceshipRB2D.velocity = new Vector2(0, 0);
        spaceshipPosition.y = -17;
        mainMenuPosition.y -= slideSpeed * Time.deltaTime;
        guiUpPosition.y -= slideSpeed * Time.deltaTime;
        guiDownPosition.y -= slideSpeed * Time.deltaTime;

        spaceship.transform.position = spaceshipPosition;
        mainMenu.GetComponent<RectTransform>().anchoredPosition = mainMenuPosition;
        guiUp.GetComponent<RectTransform>().anchoredPosition = guiUpPosition;
        guiDown.GetComponent<RectTransform>().anchoredPosition = guiDownPosition;

        if (mainMenuPosition.y < 0) 
        {
            slideDownInitator = false;
            spaceship.transform.position = new Vector2(0, -17);
            mainMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            guiUp.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -3000);
            guiDown.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -3000);
        }
    }

    public void CleanScreenFromObjects()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
        {
            Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, -20);
        }

        GameObject boss1 = GameObject.FindGameObjectWithTag("Boss1");
        if (boss1 != null)
        {
            boss1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
        }

        GameObject boss2 = GameObject.FindGameObjectWithTag("Boss2");
        if (boss2 != null)
        {
            boss2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
        }

        GameObject boss3 = GameObject.FindGameObjectWithTag("Boss3");
        if (boss3 != null)
        {
            boss3.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20);
        }

        GameObject comet = GameObject.FindGameObjectWithTag("Comet");
        if (comet != null)
        {
            Rigidbody2D rb = comet.GetComponent<Rigidbody2D>();
            if (rb.velocity.magnitude < 4)
            {
                rb.velocity *= 10;
            }
        }

        GameObject[] bossBullets = GameObject.FindGameObjectsWithTag("BossBullet");
        foreach (GameObject bossBullet in bossBullets)
        {
            Rigidbody2D rb = bossBullet.GetComponent<Rigidbody2D>();
            rb.velocity *= 10;
        }

        GameObject[] supernovas = GameObject.FindGameObjectsWithTag("Supernova");
        foreach (GameObject supernova in supernovas)
        {
            Rigidbody2D rb = supernova.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, -20);
        }
    }
    #endregion
}
