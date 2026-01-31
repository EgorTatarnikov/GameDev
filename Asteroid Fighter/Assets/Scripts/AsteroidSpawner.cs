using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    int level = 1;
    float spawnY;
    float minSpawnX;
    float maxSpawnX;
    float spawnShiftY = 0.5f;
    float spawnShiftX = 1f;

    void Start()
    {
        spawnY = ScreenUtils.ScreenTop + spawnShiftY;
        minSpawnX = ScreenUtils.ScreenLeft + spawnShiftX;
        maxSpawnX = ScreenUtils.ScreenRight - spawnShiftX;
    }

    public void FirstLevel()
    {
        level = 1;
        SwitchLevel();
    }

    public void NextLevel()
    { 
        if (level < 4)
        {
            level++;
        }
        SwitchLevel();
    }
    public void InfiniteLevel()
    {
        level=4;
        SwitchLevel();
    }

    void SwitchLevel()
    {
        switch (level)
        {
            case 1:
                if (gameObject.GetComponent<Level1>() == null)
                {
                    gameObject.AddComponent<Level1>();
                }
                Destroy(gameObject.GetComponent<Level2>());
                Destroy(gameObject.GetComponent<Level3>());
                Destroy(gameObject.GetComponent<Level4>());
                break;

            case 2:
                Destroy(gameObject.GetComponent<Level1>());
                if (gameObject.GetComponent<Level2>() == null)
                {
                    gameObject.AddComponent<Level2>();
                }
                Destroy(gameObject.GetComponent<Level3>());
                Destroy(gameObject.GetComponent<Level4>());
                break;

            case 3:
                Destroy(gameObject.GetComponent<Level1>());
                Destroy(gameObject.GetComponent<Level2>());
                if (gameObject.GetComponent<Level3>() == null)
                {
                    gameObject.AddComponent<Level3>();
                }
                Destroy(gameObject.GetComponent<Level4>());
                break;

            case 4:
                Destroy(gameObject.GetComponent<Level1>());
                Destroy(gameObject.GetComponent<Level2>());
                Destroy(gameObject.GetComponent<Level3>());
                if (gameObject.GetComponent<Level4>() == null)
                {
                    gameObject.AddComponent<Level4>();
                }
                break;
        }
    }

    public void SpawnMiddleAsteroid()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), spawnY, 0);
        int whatSpawn = Random.Range(1, 11);
        switch (whatSpawn)
        {
            case 1:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid1"), location, Quaternion.identity);
                break;
            case 2:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid3"), location, Quaternion.identity);
                break;
            case 3:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid4"), location, Quaternion.identity);
                break;
            case 4:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid5"), location, Quaternion.identity);
                break;
            case 5:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid6"), location, Quaternion.identity);
                break;
            case 6:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid7"), location, Quaternion.identity);
                break;
            case 7:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid8"), location, Quaternion.identity);
                break;
            case 8:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid9"), location, Quaternion.identity);
                break;
            case 9:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid10"), location, Quaternion.identity);
                break;
            case 10:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid12"), location, Quaternion.identity);
                break;
            default:
                Object.Instantiate(Resources.Load("Asteroids/Asteroid1"), location, Quaternion.identity);
                break;

        }
    }

    public void SpawnLittleAsteroid()
    {
        SpawnLittleAsteroid(new Vector3(Random.Range(minSpawnX, maxSpawnX), spawnY, 0));
    }

    public void SpawnLittleAsteroid(Vector2 location)
    {
        int whatSpawn = Random.Range(1, 8);
        switch (whatSpawn)
        {
            case 1:
                Object.Instantiate(Resources.Load("Asteroids/LittleAsteroid1"), location, Quaternion.identity);
                break;
            case 2:
                Object.Instantiate(Resources.Load("Asteroids/LittleAsteroid2"), location, Quaternion.identity);
                break;
            case 3:
                Object.Instantiate(Resources.Load("Asteroids/LittleAsteroid3"), location, Quaternion.identity);
                break;
            case 4:
                Object.Instantiate(Resources.Load("Asteroids/LittleAsteroid4"), location, Quaternion.identity);
                break;
            case 5:
                Object.Instantiate(Resources.Load("Asteroids/LittleAsteroid5"), location, Quaternion.identity);
                break;
            case 6:
                Object.Instantiate(Resources.Load("Asteroids/LittleAsteroid6"), location, Quaternion.identity);
                break;
            case 7:
                Object.Instantiate(Resources.Load("Asteroids/LittleAsteroid7"), location, Quaternion.identity);
                break;
            default:
                Object.Instantiate(Resources.Load("Asteroids/LittleAsteroid1"), location, Quaternion.identity);
                break;
        }
    }

    public void SpawnBigAsteroid()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), spawnY, 0);
        int whatSpawn = Random.Range(1, 6);
        switch (whatSpawn)
        {
            case 1:
                Object.Instantiate(Resources.Load("Asteroids/BigAsteroid1"), location, Quaternion.identity);
                break;
            case 2:
                Object.Instantiate(Resources.Load("Asteroids/BigAsteroid2"), location, Quaternion.identity);
                break;
            case 3:
                Object.Instantiate(Resources.Load("Asteroids/BigAsteroid3"), location, Quaternion.identity);
                break;
            case 4:
                Object.Instantiate(Resources.Load("Asteroids/BigAsteroid4"), location, Quaternion.identity);
                break;
            case 5:
                Object.Instantiate(Resources.Load("Asteroids/BigAsteroid5"), location, Quaternion.identity);
                break;
            default:
                Object.Instantiate(Resources.Load("Asteroids/BigAsteroid1"), location, Quaternion.identity);
                break;
        }
    }

    public void SpawnTripleAsteroid()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), spawnY, 0);
        int whatSpawn = Random.Range(1, 8);
        switch (whatSpawn)
        {
            case 1:
                Object.Instantiate(Resources.Load("Asteroids/TripleAsteroid1"), location, Quaternion.identity);
                break;
            case 2:
                Object.Instantiate(Resources.Load("Asteroids/TripleAsteroid2"), location, Quaternion.identity);
                break;
            case 3:
                Object.Instantiate(Resources.Load("Asteroids/TripleAsteroid3"), location, Quaternion.identity);
                break;
            case 4:
                Object.Instantiate(Resources.Load("Asteroids/TripleAsteroid4"), location, Quaternion.identity);
                break;
            case 5:
                Object.Instantiate(Resources.Load("Asteroids/TripleAsteroid5"), location, Quaternion.identity);
                break;
            case 6:
                Object.Instantiate(Resources.Load("Asteroids/TripleAsteroid1"), location, Quaternion.identity);
                break;
            case 7:
                Object.Instantiate(Resources.Load("Asteroids/TripleAsteroid5"), location, Quaternion.identity);
                break;
            default:
                Object.Instantiate(Resources.Load("Asteroids/TripleAsteroid1"), location, Quaternion.identity);
                break;
        }
    }

    public void SpawnRandomAsteroid()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), spawnY, 0);
        int whatAsteroid = Random.Range(1, 7);
        switch (whatAsteroid)
        {
            case 1:
                SpawnMiddleAsteroid();
                break;
            case 2:
                SpawnMiddleAsteroid();
                break;
            case 3:
                SpawnMiddleAsteroid();
                break;
            case 4:
                SpawnLittleAsteroid();
                break;
            case 5:
                SpawnBigAsteroid();
                break;
            case 6:
                SpawnTripleAsteroid();
                break;
        }
    }

    public void SpawnComet()
    {
        int whatSpawn = Random.Range(1, 7);
        float x = 3f;
        float y = ScreenUtils.ScreenTop + 0.65f;
        switch (whatSpawn)
        {
            case 1:
                Object.Instantiate(Resources.Load("Comets/Comet1"), new Vector2(x, y), Quaternion.identity);
                break;
            case 2:
                Object.Instantiate(Resources.Load("Comets/Comet2"), new Vector2(x, y), Quaternion.identity);
                break;
            case 3:
                Object.Instantiate(Resources.Load("Comets/Comet3"), new Vector2(x, y), Quaternion.identity);
                break;
            case 4:
                Object.Instantiate(Resources.Load("Comets/Comet4"), new Vector2(-x, y), Quaternion.identity);
                break;
            case 5:
                Object.Instantiate(Resources.Load("Comets/Comet5"), new Vector2(-x, y), Quaternion.identity);
                break;
            case 6:
                Object.Instantiate(Resources.Load("Comets/Comet6"), new Vector2(-x, y), Quaternion.identity);
                break;
            default:
                Object.Instantiate(Resources.Load("Comets/Comet1"), new Vector2(x, y), Quaternion.identity);
                break;
        }
    }
}

