using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class GiftKeeper : MonoBehaviour
{
    public static List<Gift> GiftList = new List<Gift>();
    public static List<string> inputData = new List<string>();
    public static int score;
    public static int spawnCount;
    public static float ballX;
    public static float ballY;
    public static List<float> savedX = new List<float>();
    public static List<float> savedY = new List<float>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SafeGiftListAndScore()
    {
        PlayerPrefs.DeleteAll();
        Mute.SetMutePrefs();
        PlayerPrefs.SetInt("Score", UIController.Score);
        PlayerPrefs.SetInt("SpawnCount", GiftSpawner.SpawnCount);
        Ball ball = (Ball)FindObjectOfType(typeof(Ball));
        PlayerPrefs.SetFloat("BallPositionX", ball.transform.position.x);
        PlayerPrefs.SetFloat("BallPositionY", ball.transform.position.y);

        if (GiftKeeper.GiftList != null)
        {
            int i = 0;
            foreach (Gift Gift in GiftKeeper.GiftList)
            {
                i++;

                string outputData = Gift.ToString();
                outputData.Replace(',', '.');

                float x = float.Parse(outputData.Substring(0, outputData.IndexOf('_')));

                string temp1 = outputData.Remove(0, outputData.IndexOf('_') + 1);
                float y = float.Parse(temp1.Substring(0, temp1.IndexOf('_')));

                PlayerPrefs.SetFloat("x" + i, x);
                PlayerPrefs.SetFloat("y" + i, y);

            }
        }
    }

    public static void LoadData()
    {
        GiftList.Clear();
        ballX = PlayerPrefs.GetFloat("BallPositionX");
        ballY = PlayerPrefs.GetFloat("BallPositionY");
        score = PlayerPrefs.GetInt("Score");
        spawnCount = PlayerPrefs.GetInt("SpawnCount");
        int j = 0;
        for (int i = 1; i < 100; i++)
        {
            if (PlayerPrefs.HasKey("x" + i))
            {
                j++;                            // count gifts saved in prefs
            }
        }
        for (int i = 1; i<= j; i++)
        {
            savedX.Add(PlayerPrefs.GetFloat("x" + i));
            savedY.Add(PlayerPrefs.GetFloat("y" + i));
        }
    }


    void OnApplicationPause(bool pauseStatus)
    {
        SafeGiftListAndScore();
    }
}
