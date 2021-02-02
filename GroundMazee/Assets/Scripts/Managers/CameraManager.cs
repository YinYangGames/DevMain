using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public Vector3 offset;
    public GameObject player;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(GameManager.instance.follow==true)
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 1f);
    }
}
