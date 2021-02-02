        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       
    }

    private void Update()
    {
        transform.Rotate(0f,0f,2f);
    }
}
