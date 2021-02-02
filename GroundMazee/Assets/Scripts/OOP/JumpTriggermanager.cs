using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class JumpTriggermanager : MonoBehaviour
{



    public state jump;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {


        switch (jump)
        {
            case state.singlejump:
                
                    other.GetComponentInParent<Rigidbody>().AddForce(0, 0, 300, ForceMode.Impulse);


                break;
            case state.doublejump:
                
                    other.GetComponentInParent<Rigidbody>().AddForce(0, 0, 400, ForceMode.Impulse);


                break;
            case state.triplejump:
               
                    other.GetComponentInParent<Rigidbody>().AddForce(0, 0, 500, ForceMode.Impulse);


                break;
        }

    }





}
