using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public Vector3 force;



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Jump1X"))
        {
            gameObject.GetComponentInParent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            Debug.Log("sa");
        }
        if (collider.CompareTag("Jump2X"))
        {
            gameObject.GetComponentInParent<Rigidbody>().AddForce(force * 2, ForceMode.Impulse);
        }
        if (collider.CompareTag("Jump3X"))
        {
            gameObject.GetComponentInParent<Rigidbody>().AddForce(force * 3, ForceMode.Impulse);
        }
    }
}
