using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameAnalyticsSDK;
using ElephantSDK;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    public bool isGameRunning;
    public bool crash;

    public Transform cashPos;
    public Text GoldText;
    public GameObject startPos;
    public GameObject failPanel;
    public GameObject finishPanel;
    public GameObject player;
    public GameObject tapToPlay;
    public GameObject Fracture;
    public GameObject carBody;
    public Text levelText;

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


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        int random = Random.Range(0, 2);
        if (random == 1)
        {
            UnityAdsManager unityAdsManager = FindObjectOfType<UnityAdsManager>();
            unityAdsManager.ShowInterstitialAd();
        }
        PlatformManager.instance.isPlatformSet = false;
        isGameRunning = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.position = startPos.transform.position;
        GameManager.instance.StartGame();
        carBody.SetActive(true);
        crash = false;
    }





    public void NextLevel()
    {

        PlatformManager.instance.isPlatformSet = false;
        isGameRunning = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameManager.instance.level++;
        PlayerPrefs.SetInt("Level", GameManager.instance.level);
        GameManager.instance.follow = true;
        carBody.SetActive(true);
        crash = false;

        player.transform.position = startPos.transform.position;
        GameManager.instance.StartGame();
    }

    public void TaptoPlay()
    {
        isGameRunning = true;
        GameManager.instance.totalCoin = PlayerPrefs.GetInt("Coin", GameManager.instance.totalCoin);
        GoldText.text = GameManager.instance.totalCoin.ToString();
        levelText.text = "Level " + GameManager.instance.level.ToString();

    }
}
