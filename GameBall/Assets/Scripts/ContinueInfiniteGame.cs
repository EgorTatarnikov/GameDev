using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class ContinueInfiniteGame : MonoBehaviour
{
    [SerializeField]
    GameObject prefabGift;

    private void Awake()
    {
        GiftKeeper.LoadData();
        Ball ball = (Ball)FindObjectOfType(typeof(Ball));

        ball.Score = GiftKeeper.score;
        ball.transform.position = new Vector3 (GiftKeeper.ballX, GiftKeeper.ballY, 0);
        GiftSpawner.SpawnCount = GiftKeeper.spawnCount;
        
        for (int i = 1; i<= GiftKeeper.savedX.Count; i++)
        {
            Vector3 location = new Vector3(GiftKeeper.savedX[i - 1], GiftKeeper.savedY[i - 1], 0);
            Instantiate(prefabGift, location, Quaternion.identity);
        }

        GiftKeeper.savedX.Clear();
        GiftKeeper.savedY.Clear();
        GiftKeeper.inputData.Clear();
    }
}
