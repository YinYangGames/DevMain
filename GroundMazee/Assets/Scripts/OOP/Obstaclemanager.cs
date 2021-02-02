using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclemanager : MonoBehaviour
{
    public GameObject cubeContainer;
    

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            cubeContainer.SetActive(true);
           
            
           

        }
    }
}
