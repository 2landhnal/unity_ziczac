using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public Vector3 lastPos, newPos;
    public GameObject platform;
    public Transform lastPlatform;
    public bool stop, firstLoad;
    public float maxDis, platformDis;
    public int firstPlatformNums;
    public float spawnTime, timeCount;

    public static PlatformSpawner instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lastPos = lastPlatform.position;
        timeCount = spawnTime;
        firstLoad = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstLoad)
        {
            GenerateFirstPlatforms();
            firstLoad = false;
        }
        if (GameManager.instance.gameStarted == false)
        {
            stop = true;
        }
        else
        {
            stop = false;
            timeCount -= Time.deltaTime;
            if (timeCount <= 0)
            {
                GeneratePlatform();
                timeCount = spawnTime;
            }
        }
    }

    void GeneratePlatform()
    { 
        if (!stop)
        {
            newPos = lastPos;
            GenerateNewPos();
            Instantiate(platform, newPos, Quaternion.identity);
            lastPos = newPos;
        }
    }

    void GenerateFirstPlatforms()
    {
        for (int i = 0; i < firstPlatformNums; i++)
        {
            newPos = lastPos;
            GenerateNewPos();
            Instantiate(platform, newPos, Quaternion.identity);
            lastPos = newPos;
        }
    }

    void GenerateNewPos()
    {
        float rate = Random.Range(0, 2);
        if(rate < 1)
        {
            newPos.x -= platformDis;
            if (Mathf.Abs(newPos.x - newPos.z) > maxDis)
            {
                newPos.x += platformDis;
            }
        }
        else
        {
            newPos.z -= platformDis;
            if (Mathf.Abs(newPos.x - newPos.z) > maxDis)
            {
                newPos.z += platformDis;
            }
        }
        while(newPos.x == lastPos.x && newPos.z == lastPos.z)
        {
            GenerateNewPos();
        }
    }
}
