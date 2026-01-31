using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text scoreText1;
    [SerializeField]
    private Text scoreText2;
    [SerializeField]
    private Text scoreText3;
    [SerializeField]
    private Text scoreText4;
    [SerializeField]
    private Text scoreText5;
    [SerializeField]
    private Text scoreText6;
    [SerializeField]
    private Text scoreText7;
    [SerializeField]
    private Text scoreText8;


    [SerializeField]
    private Ball ball;
    static int score;

    public static int Score { get { return score; }}
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score = ball.Score;
        scoreText.text = "Score: " + Score;
        // dubble text for black text shadow
        scoreText1.text = scoreText.text;
        scoreText2.text = scoreText.text;
        scoreText3.text = scoreText.text;
        scoreText4.text = scoreText.text;
        scoreText5.text = scoreText.text;
        scoreText6.text = scoreText.text;
        scoreText7.text = scoreText.text;
        scoreText8.text = scoreText.text;
    }
}
