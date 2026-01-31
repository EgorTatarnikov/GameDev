using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Fields
    float force = 9.81f*10;
    Rigidbody2D rb;
    float colliderRadius;
    Vector2 position;
    int score;
    #endregion

    #region Properties
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        ChangePosition();
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(InputData.X * force, InputData.Y * force), ForceMode2D.Force);
    }

    void ChangePosition()
    {
        position = transform.position;
        if (position.x - colliderRadius < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + colliderRadius;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (position.x + colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - colliderRadius;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (position.y + colliderRadius > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - colliderRadius;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        if (position.y - colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenBottom + colliderRadius;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Gift gift = coll.gameObject.GetComponent<Gift>();
        if (gift != null)
        {
            score += gift.ScoreValue;
            GiftKeeper.GiftList.Remove(gift);
            Destroy(coll.gameObject);
        }

    }
    #endregion
}

