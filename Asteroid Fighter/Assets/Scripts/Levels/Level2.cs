using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    #region Fields

    Timer spawnTimer;
    float spawnDelaySeconds = 1.6f;
    int spawnCount = 0;
    float cometSpawnTime = 0;
    int cometSpawned = 0;
    bool[] isPartStarted = new bool[10];
    bool[] isPartFinished = new bool[10];

    GameManagerScript GMScript;
    AsteroidSpawner asteroidSpawner;

    #endregion

    #region Methods
    void Start()
    {
        spawnTimer = gameObject.GetComponent<Timer>();
        spawnTimer.Duration = spawnDelaySeconds;
        spawnTimer.Run();

        GMScript = GameObject.FindWithTag("GameManager").GetComponent<GameManagerScript>();
        asteroidSpawner = gameObject.GetComponent<AsteroidSpawner>();
    }

    void Update()
    {
        if (!isPartFinished[1])
        {
            Part1();
            if (spawnCount >= 10)
            {
                StopPart1();
            }
        }

        if (isPartFinished[1] && !isPartFinished[2])
        {
            Part2();
            if (spawnCount >= 32)
            {
                StopPart2();
            }
        }

        if (isPartFinished[2] && !isPartFinished[3])
        {
            Part3();
            if (spawnCount >= 32)
            {
                StopPart3();
            }
        }

        if (isPartFinished[3] && !isPartFinished[4])
        {
            Part4();
            if (spawnCount >= 12)
            {
                StopPart4();
            }
        }

        if (isPartFinished[4] && !isPartFinished[5])
        {
            Part5();
            if (spawnCount >= 1)
            {
                StopPart5();
            }
        }

        if (isPartFinished[5] && !isPartFinished[6])
        {
            if (!isPartStarted[6])
            {
                spawnTimer.Stop();
                spawnTimer.Duration = 5;
                isPartStarted[6] = true;
                spawnTimer.Run();
            }

            if (GMScript.Boss2Killed == true)
            {
                GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

                foreach (GameObject asteroid in asteroids)
                {
                    Instantiate(Resources.Load("Blow04"), asteroid.transform.position, Quaternion.identity);
                    Destroy(asteroid);
                    AudioManager.PlayRandomBlow();
                }

                GameObject[] bossBullets = GameObject.FindGameObjectsWithTag("BossBullet");

                foreach (GameObject bossBullet in bossBullets)
                {
                    Instantiate(Resources.Load("Blow01"), bossBullet.transform.position, Quaternion.identity);
                    Destroy(bossBullet);
                    AudioManager.PlayRandomBlow();
                }

                isPartFinished[6] = true;
                spawnTimer.Stop();
                spawnTimer.Duration = 5;
                spawnTimer.Run();
            }
        }

        if (isPartFinished[6])
        {
            if (spawnTimer.Finished)
            {
                GameObject.FindWithTag("Spaceship").GetComponent<Spaceship>().Lifes = 3;
                GameObject.FindWithTag("LifesIndicator").GetComponent<LifeIndicator>().Change(3);
                Destroy(gameObject.GetComponent<Level2>());
                asteroidSpawner.NextLevel();
            }
        }

        cometSpawnTime += Time.deltaTime;
        if (cometSpawnTime>=29f && cometSpawned < 4)
        {
            asteroidSpawner.SpawnComet();
            cometSpawnTime = 0;
            cometSpawned++;
        }
    }

    void Part1()
    {
        if (!isPartStarted[1])
        {
            spawnTimer.Stop();
            spawnTimer.Duration = spawnDelaySeconds;
            isPartStarted[1] = true;
            spawnTimer.Run();
        }

        if (spawnTimer.Finished)
        {
            spawnCount++;
            asteroidSpawner.SpawnMiddleAsteroid();
            spawnTimer.Run();
        }
    }

    void Part2()
    {
        if (!isPartStarted[2])
        {
            spawnTimer.Stop();
            spawnTimer.Duration = spawnDelaySeconds;
            isPartStarted[2] = true;
            spawnTimer.Run();
        }

        if (spawnTimer.Finished)
        {
            spawnCount++;
            if (spawnCount % 4 == 1)
            {
                asteroidSpawner.SpawnTripleAsteroid();
            }
            if (spawnCount % 4 == 2)
            {
                asteroidSpawner.SpawnBigAsteroid();
            }
            if (spawnCount % 4 == 3)
            {
                asteroidSpawner.SpawnMiddleAsteroid();
            }
            if (spawnCount % 4 == 0)
            {
                asteroidSpawner.SpawnLittleAsteroid();
            }
            spawnTimer.Run();
        }
    }

    void Part3()
    {
        if (!isPartStarted[3])
        {
            spawnTimer.Stop();
            spawnTimer.Duration = spawnDelaySeconds;
            isPartStarted[3] = true;
            spawnTimer.Run();
        }

        if (spawnTimer.Finished)
        {
            spawnCount++;
            if (spawnCount % 4 == 1)
            {
                asteroidSpawner.SpawnTripleAsteroid();
            }
            if (spawnCount % 4 == 2)
            {
                asteroidSpawner.SpawnBigAsteroid();
            }
            if (spawnCount % 4 == 3)
            {
                asteroidSpawner.SpawnMiddleAsteroid();
            }
            if (spawnCount % 4 == 0)
            {
                asteroidSpawner.SpawnLittleAsteroid();
            }
            spawnTimer.Run();
        }
    }

    void Part4()
    {
        if (!isPartStarted[4])
        {
            spawnTimer.Stop();
            spawnTimer.Duration = 1.4f;
            isPartStarted[4] = true;
            spawnTimer.Run();
        }

        if (spawnTimer.Finished)
        {
            spawnCount++;
            asteroidSpawner.SpawnBigAsteroid();
            spawnTimer.Run();
        }
    }

    void Part5()
    {
        if (!isPartStarted[5])
        {
            spawnTimer.Stop();
            spawnTimer.Duration = 10;
            isPartStarted[5] = true;
            spawnTimer.Run();
        }

        if (spawnTimer.Finished)
        {
            spawnCount++;
            Object.Instantiate(Resources.Load("Boss2"), transform.position, Quaternion.identity);
        }
    }

    void StopPart1()
    {
        isPartFinished[1] = true;
        spawnCount = 0;
    }

    void StopPart2()
    {
        isPartFinished[2] = true;
        spawnCount = 0;
    }

    void StopPart3()
    {
        isPartFinished[3] = true;
        spawnCount = 0;
    }

    void StopPart4()
    {
        isPartFinished[4] = true;
        spawnCount = 0;
    }

    void StopPart5()
    {
        isPartFinished[5] = true;
        spawnCount = 0;
    }
    #endregion
}
