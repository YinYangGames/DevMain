using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Animator doorAnimator;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "button")
        {
            doorAnimator.SetTrigger("PushButton");
            Debug.Log("hit");
        }
        if (collision.gameObject.tag == "Bounds")
        {   
            Debug.Log("hit");
        }
        if (collision.gameObject.tag == "FinishDoor")
        {
            UI.instance.levelCompletedPanel.SetActive(true);
            Debug.Log("finished");
        }
    }
}
