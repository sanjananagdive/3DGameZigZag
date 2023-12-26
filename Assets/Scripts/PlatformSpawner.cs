using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    float size;

    Vector3 lastPos;

    public GameObject platform;

    public bool gameOver;

    public GameObject diamond;

    public static PlatformSpawner instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        //InvokeRepeating("SpawnPlatformsRandomnly", 0.5f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke("SpawnPlatformsRandomnly");
        }
    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatformsRandomnly", 0.2f, 0.1f);
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform,pos,Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y +1, pos.z), diamond.transform.rotation);
        }
        
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }

    void SpawnPlatformsRandomnly()
    {
        int rand = Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }

        
    }
}
