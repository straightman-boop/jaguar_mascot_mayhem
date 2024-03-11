using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameTimeScript gameTime;

    Collider2D playerCollider;
    FireBulletScript firing;

    SpriteRenderer spriteC;
    public Sprite ez;
    public Sprite defalt;
    public Sprite mid;
    public Sprite hot;
    public Sprite ashura;

    private Shake shake;

    public Vector2 moveDirection;
    public float moveSpeed;

    private void OnEnable()
    {
        gameTime = GameObject.FindGameObjectWithTag("GameTime").GetComponent<GameTimeScript>();
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        Invoke("Destroy", 5f);
    }

    private void Awake()
    {
        firing = GameObject.FindGameObjectWithTag("Enemy").GetComponent<FireBulletScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteC = GetComponent<SpriteRenderer>();

        spriteC.sprite = ez;

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        bulletChanges();
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shake.camShake();
        //Debug.Log(playerCollider.gameObject.name + " has been hit by " + collision.gameObject.name);
    }

    void bulletChanges()
    {
        //FIRST PHASE

        if (gameTime.time >= 12 && gameTime.time < 22)
        {


        }

        else if (gameTime.time >= 22 && gameTime.time < 30)
        {

            spriteC.sprite = ez;
        }

        else if (gameTime.time >= 30 && gameTime.time < 40)
        {

            spriteC.sprite = defalt;
        }

        //INTERMISSION PHASE 

        else if (gameTime.time >= 40 && gameTime.time < 50)
        {
            spriteC.sprite = mid;
        }

        else if (gameTime.time >= 50 && gameTime.time < 57)
        {
            spriteC.sprite = mid;
        }

        //SECOND PHASE

        else if (gameTime.time >= 57 && gameTime.time < 70)
        {
            spriteC.sprite = hot;
        }

        //THIRD PHASE

        else if (gameTime.time >= 70 && gameTime.time < 80)
        {
            spriteC.sprite = hot;
        }

        else if (gameTime.time >= 80 && gameTime.time < 90)
        {
            spriteC.sprite = hot;
            moveSpeed = 0.5f;
        }
        
        else if (gameTime.time >= 90 && gameTime.time < 95)
        {
            spriteC.sprite = ashura;
            moveSpeed = 3;
        }
        
        else if (gameTime.time >= 97 && gameTime.time < 150)
        {
            spriteC.sprite = ashura;
            moveSpeed = 10;
        }

    }

}
