using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{
    #region Fields

    Timer spawnTimer;
    float spawnDelaySeconds = 1.5f;
    float cometSpawnTime = 0;
    int counter = 0;

    AsteroidSpawner asteroidSpawner;

    #endregion

    #region Methods
    void Start()
    {
        spawnTimer = gameObject.GetComponent<Timer>();
        spawnTimer.Duration = spawnDelaySeconds;
        spawnTimer.Run();

        asteroidSpawner = gameObject.GetComponent<AsteroidSpawner>();
    }

    void Update()
    {
        if (spawnTimer.Finished)
        {
            counter++;
            if (counter == 37)
            {
                float x = Random.Range(-1.0f, 1.0f);
                //float x = 0f;
                float y = ScreenUtils.ScreenTop + 0.65f;
                Object.Instantiate(Resources.Load("Supernova"), new Vector2(x, y), Quaternion.identity);
                counter = 0;
            }

            else
            {
                asteroidSpawner.SpawnRandomAsteroid();
            }
            spawnTimer.Run();
        }

        cometSpawnTime += Time.deltaTime;
        if (cometSpawnTime >= 45f)
        {
            asteroidSpawner.SpawnComet();
            cometSpawnTime = 0;
        }
    }


    #endregion
}
