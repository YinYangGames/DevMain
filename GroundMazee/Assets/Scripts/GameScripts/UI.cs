using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    
    private float secondsCount;
    private int minuteCount;
    public TextMeshProUGUI timerText;
    public GameObject levelCompletedPanel;
    public static UI instance;
    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        secondsCount += Time.deltaTime;
        timerText.text =  minuteCount + ":" + (int)secondsCount + "";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
       
    }
}
