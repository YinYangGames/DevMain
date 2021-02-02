using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public Rigidbody cubeRigidbody;
    public GameObject player;
    public bool final;

    void Start()
    {
        cubeRigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerCollider");
    }

    void Update()
    {

        if (transform.position.y < 1f)
        {
            cubeRigidbody.velocity = Vector3.zero;
            transform.Translate(Vector3.up * 1.5f * Time.deltaTime, Space.World);
        }

        if (transform.position.y >= 1)
        {
            cubeRigidbody.velocity = Vector3.zero;
            transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }

        //if (final)
        //{
        //    if (transform.position.z + 30 < player.transform.position.z)
        //    {

        //        transform.position = new Vector3(transform.position.x, 0, transform.position.z + 125);
        //        gameObject.GetComponent<MeshRenderer>().enabled = true;
        //        gameObject.GetComponent<BoxCollider>().enabled = true;
        //    }

        //}





        //if (player.transform.position.z < PlatformManager.instance.maxDistance - 78.5)
        //{
        //    final = true;
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ObstacleTrigger"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.CompareTag("FinalTrigger"))
        {
            GetComponent<MeshRenderer>().material.SetColor("_TopColor",Color.green);
            GetComponent<MeshRenderer>().material.SetColor("_FrontTopColor", Color.green);
            GetComponent<MeshRenderer>().material.SetColor("_LeftTopColor", Color.green);
        }
    }
    private void OnDisable()
    {

    }
   
}



