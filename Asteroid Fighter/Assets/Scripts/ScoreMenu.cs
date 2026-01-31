using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour
{
    GameObject spaceship;
    float slideSpeed = 9000.0f;
    GameObject lifesIndicator;
    bool buttonClicked = false;

    [SerializeField]
    Text ScoreText;
    [SerializeField]
    Image NewRecordImageText;

    GameObject gameManager;
    GameManagerScript GMScript;

    CurrentScoreText currentScoreText;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        GMScript = gameManager.GetComponent<GameManagerScript>();

        int currentScore = GMScript.CurrentScore;
        int lastRecord = GMScript.LastRecord;
        NewRecordImageText.color = new Color(1, 1, 1, 0);
        spaceship = GameObject.FindWithTag("Spaceship");
        lifesIndicator = GameObject.FindWithTag("LifesIndicator");
        ScoreText.text = currentScore.ToString();
        GameObject.FindWithTag("ScoreZone").GetComponent<TextPrinter>().PrintScore(currentScore);
        if (currentScore > lastRecord)
        {
            NewRecordImageText.color = new Color(1, 1, 1, 1);
        }

        currentScoreText = GameObject.FindWithTag("GuiUpZone").GetComponent<CurrentScoreText>();
        currentScoreText.GameOverOn();

        //////////
        GameObject[] transparents = GameObject.FindGameObjectsWithTag("Transparent");
        foreach (GameObject transparent in transparents)
        {
            Destroy(transparent);
        }
        //////////
    }

    void Update()
    {
        if (buttonClicked)
        {
            ButtonClicked();
        }
    }

    public void HandlRestartButtonOnClickEvent()
    {
        buttonClicked = true;
    }

    private void SlUp()
    {
        spaceship.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        spaceship.transform.position = new Vector2 ( 0, spaceship.transform.position.y + slideSpeed / 200 * Time.deltaTime);
        GMScript.LastRecord = GMScript.RecordScore;
    }

    void ButtonClicked()
    {
        if (spaceship.transform.position.y < (-2.2f * ScreenUtils.ScreenCoefficient))
        {
            SlUp();
        }
        else
        {
            spaceship.transform.position = new Vector2(0, -2.2f * ScreenUtils.ScreenCoefficient);
            spaceship.GetComponent<Spaceship>().lifes = 3;
            lifesIndicator.GetComponent<LifeIndicator>().Change(3);

            GMScript.CurrentScore = 0;

            if (gameManager.GetComponent<MainMenu>() != null)
            {
                if (gameManager.GetComponent<MainMenu>().IsInfiniteLevel)
                {
                    gameManager.GetComponent<AsteroidSpawner>().InfiniteLevel();
                }
                else
                {
                    gameManager.GetComponent<AsteroidSpawner>().FirstLevel();
                }
            }


            GameObject[] transparentScoreMenus = GameObject.FindGameObjectsWithTag("TransparentScoreMenu");
            foreach (GameObject transparentScoreMenu in transparentScoreMenus)
            {
                Destroy(transparentScoreMenu);
            }
            currentScoreText.GameOverOff();
            Destroy(gameObject);
        }
    }
}
