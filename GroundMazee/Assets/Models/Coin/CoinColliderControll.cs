using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CoinColliderControll : MonoBehaviour
{
    public GameObject collectParticle;

    GameObject text;
    public int gain;


    bool isPicked;
    public string otherTriggerTag;

    private void OnEnable()
    {
        StartCoroutine(CoinPickUpAnim());
    }
    public IEnumerator CoinPickUpAnim()
    {
        float delta = 0.0005f;
        Vector3 scoreWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(GameSceneManager.instance.cashPos.transform.position.x, GameSceneManager.instance.cashPos.transform.position.y, 10));
        while ((transform.position - scoreWorldPos).magnitude > 0.1f && transform.localScale != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, scoreWorldPos, 2f);
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, 0.05f);
            yield return new WaitForFixedUpdate();
            scoreWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(GameSceneManager.instance.cashPos.transform.position.x, GameSceneManager.instance.cashPos.transform.position.y, 10));
        }
        GameManager.instance.totalCoin += gain;
        PlayerPrefs.SetInt("Coin", GameManager.instance.totalCoin);
        GameSceneManager.instance.GoldText.text = GameManager.instance.totalCoin.ToString();

        SetActiveFalse();
    }
    void Start()
    {

        text = GameObject.FindGameObjectWithTag("CoinText");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}

