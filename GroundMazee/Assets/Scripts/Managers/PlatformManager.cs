using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance;
    public List<GameObject> obstacleList;
    public List<GameObject> obstacles;
    public List<GameObject> platform;
    public List<GameObject> backGroundList;
    public List<GameObject> background;
    public bool isPlatformSet;
    public GameObject obstacle;
    public GameObject player;
    public GameObject finalPrefab;
    public GameObject finalPlatform;
    public GameObject[] backPref;
    public GameObject backObject;
    public bool final;
    public float maxDistance;


    [Header("Platform")]
    public GameObject groundPrefab;
    public int size;
    public int groundCount;
    public GameObject mainPlatform;

    [Header("Obstacles")]

    public int zScalePos;
    public int totalObstacle;
    public float obstacleObjectzPos = 0.5f;


    [Header("BackgroundObjects")]

    public float backZPos;
    public int backZScalePos;
    public int backTotal;
    public float backObjectZPos;


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



    public void SetPlatform()
    {
        foreach (GameObject item in obstacles)
        {
            Destroy(item);
        }
        obstacles.Clear();
        foreach (GameObject item in platform)
        {
            Destroy(item);
        }
        platform.Clear();

        foreach (GameObject item in backGroundList)
        {
            Destroy(item);
        }
        backGroundList.Clear();


        //if (GameManager.instance.level <= 10)
        //{
        //    maxDistance = 250;
        //}
        //else
        //    maxDistance = 500;
        Destroy(finalPlatform);

        float yPos;
        float zPos;

        //foreach (GameObject item in platform)
        //{
        //    Destroy(item);
        //}
        //foreach (GameObject item in backGroundList)
        //{
        //    Destroy(item);
        //}

        print("size = " + size);
        for (int i = 0; i < size; i++)
        {
            mainPlatform = Instantiate(groundPrefab);

            yPos = 1.2f;
            zPos = (i * 0.5f);
            mainPlatform.transform.position = new Vector3(0, yPos, zPos);
            platform.Add(mainPlatform);

        }

        //for (int i = 0; i < size; i++)
        //{
        //    mainPlatform = Instantiate(groundPrefab);

        //    yPos = 1.2f;
        //    zPos = (i * 0.5f);
        //    mainPlatform.transform.position = new Vector3(5, yPos, zPos);
        //    platform.Add(groundPrefab);

        //}

        //for (int i = 0; i < size; i++)
        //{
        //    mainPlatform = Instantiate(groundPrefab);

        //    yPos = 1.2f;
        //    zPos = (i * 0.5f);
        //    mainPlatform.transform.position = new Vector3(-5, yPos, zPos);
        //    platform.Add(groundPrefab);

        //}

        float randomObstacleY = Random.Range(10, 20);
        if (GameManager.instance.level <= 2)
        {

            for (int i = 0; i < totalObstacle; i++)
            {

                obstacle = Instantiate(obstacleList[Random.Range(0, 4)]);



                obstacles.Add(obstacle);

            }
        }
        else if (GameManager.instance.level > 2 && GameManager.instance.level <= 4)
        {
            for (int i = 0; i < totalObstacle; i++)
            {

                obstacle = Instantiate(obstacleList[Random.Range(0, 6)]);



                obstacles.Add(obstacle);

            }
        }

        else if (GameManager.instance.level > 4 && GameManager.instance.level <= 6)
        {
            for (int i = 0; i < totalObstacle; i++)
            {

                obstacle = Instantiate(obstacleList[Random.Range(0, 8)]);



                obstacles.Add(obstacle);

            }
        }

        else if (GameManager.instance.level > 6)
        {
            for (int i = 0; i < totalObstacle; i++)
            {

                obstacle = Instantiate(obstacleList[Random.Range(0, 12)]);



                obstacles.Add(obstacle);

            }
        }

        float tempObstaclePos = obstacleObjectzPos;
        foreach (GameObject item in obstacles)
        {
            zPos = zScalePos * tempObstaclePos;
            tempObstaclePos += Random.Range(2, 4);
            item.transform.position = new Vector3(player.transform.position.x, (Random.Range(15, 20)), zPos + 100);
        }




        for (int i = 0; i < backTotal; i++)
        {
            backObject = Instantiate(backPref[Random.Range(0, 13)]);
            backGroundList.Add(backObject);
        }



        float tempbackObjectZPos = backObjectZPos;
        foreach (GameObject item in backGroundList)
        {
            backZPos = backZScalePos * tempbackObjectZPos;
            tempbackObjectZPos += Random.Range(10, 20);

            item.transform.position = new Vector3(0, 0, backZPos);
        }

        finalPlatform = Instantiate(finalPrefab);
        finalPlatform.transform.position = new Vector3(0, 0, player.transform.position.z + maxDistance * 2);
        isPlatformSet = true;
    }
}
