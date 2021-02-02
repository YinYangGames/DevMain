using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailObstacle : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameSceneManager.instance.crash)
        {
            GameManager.instance.FailGame();
            //other.transform.GetChild(0).gameObject.SetActive(false);
            GameSceneManager.instance.crash = true;
            GameSceneManager.instance.failPanel.SetActive(true);
            GameSceneManager.instance.carBody.SetActive(false);
            if (GameSceneManager.instance.crash == true)
            {

            GameObject fracture = Instantiate(GameSceneManager.instance.Fracture);
            fracture.transform.position = other.transform.position;
            fracture.transform.rotation = other.transform.rotation;
            
            foreach(var item in fracture.GetComponentsInChildren<Rigidbody>())
            {
                item.AddExplosionForce(1000, GameSceneManager.instance.Fracture.transform.position, 100);
            }
            }

            GameManager.instance.FinishGame();

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FinalTrigger"))
        {
            gameObject.SetActive(false);
            

            GameSceneManager.instance.isGameRunning = false;
        }

    }
}
