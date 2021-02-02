using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalJump1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.GetComponentInParent<Rigidbody>().AddForce(0, 0, 100, ForceMode.Impulse);
     }
}
