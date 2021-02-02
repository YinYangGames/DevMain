using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ElephantSDK;
using GameAnalyticsSDK;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalCoin;
    public int level;
    public bool follow = true;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        PlatformManager.instance.SetPlatform();

        level = PlayerPrefs.GetInt("Level", level);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Start The Game");
        Elephant.LevelStarted(level);


        level = PlayerPrefs.GetInt("Level", level);
        totalCoin = PlayerPrefs.GetInt("Coin", totalCoin);
        GameSceneManager.instance.GoldText.text = totalCoin.ToString();
        GameSceneManager.instance.levelText.text = "Level " + level.ToString();
        if (level > 10)
            PlatformManager.instance.maxDistance = 500;
        if (!PlatformManager.instance.isPlatformSet)
            PlatformManager.instance.SetPlatform();
        //GameSceneManager.instance.isGameRunning = true;
        GameSceneManager.instance.player.transform.position = GameSceneManager.instance.startPos.transform.position;
    }
    public void FinishGame()
    {
        GameSceneManager.instance.isGameRunning = false;
        
    }

    public void FailGame()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Fail The Game");
        Elephant.LevelFailed(level);
    }

    public void ComplateLevel()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Complate The Game");
        Elephant.LevelCompleted(level);
    }
}
