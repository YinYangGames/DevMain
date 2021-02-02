using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManeger : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI TimerTMP;


    float second = 0;
    int minute=0;




    void Start()
    {
        timerIsStart = true;
    }

    // Update is called once per frame



    bool timerIsStart;
    void Update()
    {
        if (timerIsStart)
        {
            if (second < 60)
            {
                second += Time.deltaTime;
            }
            else if (second >= 60)
            {
                second = 0;
                minute++;
            }

            TimerTMP.GetComponent<TextMeshProUGUI>().text = string.Format("{0} : {1}", minute,Convert.ToInt32(second));


        }

    }





}
