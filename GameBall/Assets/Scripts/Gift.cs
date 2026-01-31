using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Gift : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private int scoreValue = 1;

    [SerializeField]
    int giftId;

    #endregion

    #region Properties
    public int GiftId { get { return giftId; } set { giftId = value; } }
    #endregion

    #region UnityMethods
    /// <summary>
    /// Gets the health value for the apple
    /// </summary>
    /// <value>health value</value>
    public int ScoreValue
    {
        get { return scoreValue; }
    }

    private void Start()
    {
        //Starter();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = RandColor();
        giftId = GiftSpawner.SpawnCount;

        GiftKeeper.GiftList.Add(this);
    }

    void Update()
    {

        if (gameObject.transform.position.x < ScreenUtils.ScreenLeft ||
            gameObject.transform.position.x > ScreenUtils.ScreenRight ||
            gameObject.transform.position.y < ScreenUtils.ScreenBottom ||
            gameObject.transform.position.y > ScreenUtils.ScreenTop)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region MyMethods

    /// <summary>
    /// Creates random pastel color (R, G, and B in range 63 - 191) 
    /// </summary>
    /// <returns></returns>
    Color RandColor()
    {
        Color color = new Color(1f, 1f, 1f);
        float delta = 0f;
        color.r = Random.Range(63f, 191f) / 255f;
        color.g = Random.Range(63f, 191f) / 255f;
        color.b = Random.Range(63f, 191f) / 255f;
        delta = Mathf.Abs(color.r - color.g) + Mathf.Abs(color.g - color.b) + Mathf.Abs(color.b - color.r);
        if (delta < 0.4)
        {
            color = ShiftColor(color);
        }
        return color;
    }

    /// <summary>
    /// Shifts color if it is close to gray
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    Color ShiftColor(Color color)
    {
        float deltaShift = 0.1f;
        if (color.r > color.g && color.r > color.b)
        {
            if (color.g > color.b)
            {
                color.r += deltaShift;
                color.b -= deltaShift;
            }
            else
            {
                color.r += deltaShift;
                color.g -= deltaShift;
            }
        }
        else if (color.r <= color.g && color.r <= color.b)
        {
            if (color.g > color.b)
            {
                color.r -= deltaShift;
                color.g += deltaShift;
            }
            else
            {
                color.r -= deltaShift;
                color.b += deltaShift;
            }
        }
        else
        {
            if (color.g > color.b)
            {
                color.g += deltaShift;
                color.b -= deltaShift;
            }
            else
            {
                color.g -= deltaShift;
                color.b += deltaShift;
            }
        }
            return color;
    }

    public override string ToString()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        string data =   transform.position.x + "_" + 
                        transform.position.y + "_" + 
                        spriteRenderer.color.r + "_" + 
                        spriteRenderer.color.g + "_" + 
                        spriteRenderer.color.b;
        data.Replace(',', '.');
        return data;
    }

    #endregion
}
