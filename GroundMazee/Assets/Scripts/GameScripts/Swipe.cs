using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeDown, swipeUp, swipeRight, swipeLeft;
    private bool surukle = false;
    private Vector2 startTouch, swipeStart;

    public float deadZone;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    tap = true;
                    surukle = true;
                    startTouch = Input.touches[0].position;
                    break;

                case TouchPhase.Ended:
                    surukle = false;
                    Reset();
                    break;
            }
        }

        //Mesafe Hesabı
        swipeStart = Vector2.zero;
        if (surukle)
        {
            if (Input.touches.Length > 0) swipeStart = Input.touches[0].position - startTouch;
        }
        else
        {
            swipeUp = false;
            swipeDown = false;
            swipeLeft = false;
            swipeRight = false;
        }

        // Threshold
        if (swipeStart.magnitude > deadZone) //değeri sen belirle   , fazlalık
        {
            float x = swipeStart.x;
            float y = swipeStart.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0) swipeLeft = true;
                else swipeRight = true;
            }
            else
            {
                if (y < 0) swipeDown = true;
                else swipeUp = true;
            }

            Reset();
        }
    }

    void Reset()
    {
        surukle = false;
        swipeStart = swipeStart = Vector2.zero; //Sıfırla
    }

    public bool SwipeDown{ get { return swipeDown; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeLeft{ get { return swipeLeft; } }
    public Vector2 SwipeStart { get { return swipeStart; } }


}
