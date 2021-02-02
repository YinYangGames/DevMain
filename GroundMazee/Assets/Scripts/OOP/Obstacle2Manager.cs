using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Obstacle2Manager : MonoBehaviour
{
    public int yPos;

   


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

        
    }

    
}
