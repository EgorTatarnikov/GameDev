using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject prefabGift;

    // spawn support
    Timer spawnTimer;
    const float SpawnDelaySeconds = 1;
    static int spawnCount = 0;

    #endregion

    #region Properties
    static public int SpawnCount { get { return spawnCount; } set { spawnCount = value; } }
    #endregion

    #region UnityMethods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // get gift collider radius
        GameObject tempGift = Instantiate<GameObject>(prefabGift);
        CircleCollider2D giftCollider = tempGift.GetComponent<CircleCollider2D>();
        float giftRadius = giftCollider.radius;
        Destroy(tempGift);

        // start spawn timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = SpawnDelaySeconds;
        spawnTimer.Run();


}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // spawn apple as appropriate
        if (spawnTimer.Finished)
        {
            if (GiftKeeper.GiftList.Count<60)
            {
                int whileCounter = 0;
                Vector2 location = new Vector2(Random.Range(ScreenUtils.ScreenLeft + 1, ScreenUtils.ScreenRight - 1), Random.Range(ScreenUtils.ScreenBottom + 1, ScreenUtils.ScreenTop - 1));
                while( Physics2D.OverlapCircle(location, 0.25f) != null && whileCounter < 20)
                {
                    location = new Vector2(Random.Range(ScreenUtils.ScreenLeft + 1, ScreenUtils.ScreenRight - 1), Random.Range(ScreenUtils.ScreenBottom + 1, ScreenUtils.ScreenTop - 1));
                    whileCounter++;
                }

                Instantiate(prefabGift, location, Quaternion.identity);
                whileCounter = 0;

                spawnCount++;
            }
            spawnTimer.Run();
        }
    }
    #endregion

    #region MyMethods

    #endregion
}
