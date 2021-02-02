using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle3Manager : MonoBehaviour
{
    public GameObject cubeContainer;

    void Update()
    {
        cubeContainer.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            cubeContainer.SetActive(true);

      
        }
    }
}
