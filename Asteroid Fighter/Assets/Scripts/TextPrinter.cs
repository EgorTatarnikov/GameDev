using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrinter : MonoBehaviour
{
    int[] digits = new int[6];

    [SerializeField]
    GameObject scorePlank;
    [SerializeField]
    Image[] digitImages = new Image[6];
    [SerializeField]
    Sprite[] digitSprites = new Sprite[10];

    void Transmit(int score)
    {
        digits[0] = score % 10;
        score /= 10;
        digits[1] = score % 10;
        score /= 10;
        digits[2] = score % 10;
        score /= 10;
        digits[3] = score % 10;
        score /= 10;
        digits[4] = score % 10;
        score /= 10;
        digits[5] = score % 10;
        score /= 10;
        
        if (score !=0)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = 9;
            }
        }
    }

    public void PrintDigit(int i)
    {
        if (i>=0 && i<6)
        {
            print(digits[i]);
        }
    }

    public void PrintScore(int score)
    { 
        Transmit(score);
        scorePlank.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        digitImages[0].color = new Color(1, 1, 1, 1);
        digitImages[0].sprite = digitSprites[digits[0]];
        digitImages[1].color = new Color(1, 1, 1, 0);
        digitImages[2].color = new Color(1, 1, 1, 0);
        digitImages[3].color = new Color(1, 1, 1, 0);
        digitImages[4].color = new Color(1, 1, 1, 0);
        digitImages[5].color = new Color(1, 1, 1, 0);
        if (score >= 10)
        {
            scorePlank.GetComponent<RectTransform>().localPosition = new Vector3(30, 0, 0);
            digitImages[1].color = new Color(1, 1, 1, 1);
            digitImages[1].sprite = digitSprites[digits[1]];
        }
        if (score >= 100)
        {
            scorePlank.GetComponent<RectTransform>().localPosition = new Vector3(60, 0, 0);
            digitImages[2].color = new Color(1, 1, 1, 1);
            digitImages[2].sprite = digitSprites[digits[2]];
        }
        if (score >= 1000)
        {
            scorePlank.GetComponent<RectTransform>().localPosition = new Vector3(90, 0, 0);
            digitImages[3].color = new Color(1, 1, 1, 1);
            digitImages[3].sprite = digitSprites[digits[3]];
        }
        if (score >= 10000)
        {
            scorePlank.GetComponent<RectTransform>().localPosition = new Vector3(120, 0, 0);
            digitImages[4].color = new Color(1, 1, 1, 1);
            digitImages[4].sprite = digitSprites[digits[4]];
        }
        if (score >= 100000)
        {
            scorePlank.GetComponent<RectTransform>().localPosition = new Vector3(150, 0, 0);
            digitImages[5].color = new Color(1, 1, 1, 1);
            digitImages[5].sprite = digitSprites[digits[5]];
        }
    }

    public void MakeTransparent()
    {
        foreach (var digit in digitImages)
        {
            digit.color = new Color(1, 1, 1, 0);
        }
    }
}
