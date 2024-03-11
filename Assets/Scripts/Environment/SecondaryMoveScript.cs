using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryMoveScript : MonoBehaviour
{
    float moveSpeed = 2;
    float deadZone = -17f;

    GameTimeScript gameTime;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = GameObject.FindGameObjectWithTag("GameTime").GetComponent<GameTimeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x <= deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        increaseSped(); 
    }

    public void destroyGameObject()
    {
        Destroy(gameObject);
    }

    void increaseSped()
    {
        //FIRST PHASE
        if (gameTime.time >= 12 && gameTime.time < 22)
        {
            moveSpeed = 2.3f;
        }

        else if (gameTime.time >= 22 && gameTime.time < 30)
        {
            moveSpeed = 2.6f;
        }

        else if (gameTime.time >= 30 && gameTime.time < 40)
        {
            moveSpeed = 3f;
        }

        else if (gameTime.time >= 40 && gameTime.time < 58)
        {
            moveSpeed = 3.5f;
        }

        //SECOND PHASE
        else if (gameTime.time >= 58 && gameTime.time < 60)
        {
            moveSpeed = 5.5f;
        }

        else if (gameTime.time >= 60 && gameTime.time < 70)
        {
            moveSpeed = 5.7f;
        }

        else if (gameTime.time >= 70 && gameTime.time < 80)
        {
            moveSpeed = 6f;
        }

        //THIRD PHASE

        else if (gameTime.time >= 70 && gameTime.time < 80)
        {
            moveSpeed = 6f;
        }
        
        else if (gameTime.time >= 80 && gameTime.time < 90)
        {
            moveSpeed = 8f;
        }
        
        else if (gameTime.time >= 90 && gameTime.time < 150)
        {
            moveSpeed = 1f;
        }
    }
}
