using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondarySpawnScript : MonoBehaviour
{
    public GameObject platformSecondary;
    GameTimeScript gameTime;

    float spawnRate = 0.7f;
    private float timer = 0;
    float heightOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = GameObject.FindGameObjectWithTag("GameTime").GetComponent<GameTimeScript>();
        spawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }

        else
        {
            spawnPlatform();
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        increaseSpawn();
    }

    void spawnPlatform()
    {
        float highestPoint = transform.position.y + heightOffset;
        float lowestPoint = transform.position.y;

        Instantiate(platformSecondary, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    void increaseSpawn()
    {
        //FIRST PHASE
        if (gameTime.time >= 12 && gameTime.time < 22)
        {
            heightOffset = 3;
            spawnRate = 2f;
        }

        else if (gameTime.time >= 22 && gameTime.time < 30)
        {
            heightOffset = 3f;
            spawnRate = 2f;
        }

        else if (gameTime.time >= 30 && gameTime.time < 40)
        {
            heightOffset = 3f;
            spawnRate = 2f;
        }

        else if (gameTime.time >= 40 && gameTime.time < 58)
        {
            heightOffset = 3f;
            spawnRate = 1.5f;
        }

        //SECOND PHASE

        else if (gameTime.time >= 58 && gameTime.time < 70)
        {
            heightOffset = 3.5f;
            spawnRate = 1f;
        }

        else if (gameTime.time >= 70 && gameTime.time < 80)
        {
            heightOffset = 3.5f;
            spawnRate = 1f;
        }
        
        else if (gameTime.time >= 80 && gameTime.time < 90)
        {
            heightOffset = 3.5f;
            spawnRate = 0.7f;
        }
        
        else if (gameTime.time >= 90 && gameTime.time < 150)
        {
            heightOffset = 3.5f;
            spawnRate = 0.7f;
        }



        //THIRD PHASE


    }


}
