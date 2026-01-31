using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityDrawer : MonoBehaviour
{
    #region Properties

    float x0 = 0;
    float y0 = 0;
    public float radius = 2.5f;
    float x = 1f;
    float y = 1f;
    static float divider = 2f;
    float t;
   
    Rigidbody2D rb;

    // spawn support
    Timer timer;
    float secondsForRound = 13.4f / divider;

    #endregion

    #region Fields


    #endregion

    #region Properties

    // Start is called before the first frame update
    void Start()
    {
        x = -radius / Mathf.Sqrt(2) + x0;
        y = radius / Mathf.Sqrt(2) + y0;

        rb = GetComponent<Rigidbody2D>();
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = secondsForRound;
        timer.Run();
        x0 = rb.transform.position.x;
        y0 = rb.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    private void FixedUpdate()
    {

    }

    public void Mover()
    {
        t = timer.CurrentTime * divider;
        if (t >= 0 && t < 1)
        {
            x = radius / Mathf.Sqrt(2) * (t);
            y = radius / Mathf.Sqrt(2) * (- t);
        }
        if (t >= 1 && t < 5.7)
        {
            x = radius * (Mathf.Cos((t - 1 - 2.35f) / 2.35f * (135f / 180f * Mathf.PI))) + Mathf.Sqrt(2) * radius;
            y = radius * (Mathf.Sin((t - 1 - 2.35f) / 2.35f * (135f / 180f * Mathf.PI)));
        }
        if (t >= 5.7 && t < 7.7)
        {
            x = (radius / Mathf.Sqrt(2)) * (1 - t + 5.7f);
            y = (radius / Mathf.Sqrt(2)) * (1 - t + 5.7f);
        }
        if (t >= 7.7 && t < 12.4)
        {
            x = -(radius * (Mathf.Cos((t - 7.7f - 2.35f) / 2.35f * (135f / 180f * Mathf.PI))) + Mathf.Sqrt(2) * radius);
            y = radius * (Mathf.Sin((t - 7.7f - 2.35f) / 2.35f * (135f / 180f * Mathf.PI)));
        }
        if (t >= 12.4)
        {
            x = radius / Mathf.Sqrt(2) * (t - 13.4f);
            y = radius / Mathf.Sqrt(2) * (13.4f - t);
        }

        if (timer.Finished)
        {
            timer.Run();
        }
        
        x += x0;
        y += y0;
        rb.transform.position = new Vector3(x, y, 0);
    }

    #endregion
}
