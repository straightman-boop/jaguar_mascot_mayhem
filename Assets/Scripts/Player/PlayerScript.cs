using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float dash;
    [SerializeField] private float hori;

    private DashingScript dashingScript;

    public Rigidbody2D playerRigidBody;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public AudioSource lose;

    public GameTimeScript gameTime;

    public LogicScript logic;

    float forceStrength = 10;
    //float jumpHeight = 2f;

    public float deadZoneX = 14f;
    public float deadZoneY = 14f; //change back to 8

    //float gravityScale = 20;
    //float fallGravityScale = 2;

    float dashStrength = 25;

    bool stop; int tries;


    private void Awake()
    {
        gameTime = GameObject.FindGameObjectWithTag("GameTime").GetComponent<GameTimeScript>();

        dashingScript = GetComponent<DashingScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody.gravityScale = 5;

        tries = 0;

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        playerRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidBody.position.x > deadZoneX || playerRigidBody.position.x < -deadZoneX || playerRigidBody.position.y > deadZoneY || playerRigidBody.position.y < -deadZoneY)
        {
            //Debug.Log(playerRigidBody.position.x + " " + playerRigidBody.position.y);    

            if(tries == 0)
            {
                StartCoroutine(playFoghorn());
                tries = 1;
            }

            logic.gameOverScreen();
            logic.bgmusic.Stop();
            Time.timeScale = 0;

        }

        else if (gameTime.time == 155 && logic.gameOver == false)
        {
            logic.victoryScreen();
            Time.timeScale = 0;
        }

        else
        {

            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) && IsGrounded() == true)
            {
                //playerRigidBody.gravityScale = gravityScale;
                //float jumpStrength = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * playerRigidBody.gravityScale) * -2) * playerRigidBody.mass;
                playerRigidBody.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.S) && IsGrounded() == false)
            {
                playerRigidBody.AddForce(Vector2.down * 20, ForceMode2D.Impulse);
            }

            //if (Input.GetKeyUp(KeyCode.W) && playerRigidBody.velocity.y > 0f)
            //{
            //    playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.y * 0.5f);
            //}

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                if (Input.GetKeyDown(KeyCode.A) && dashingScript.Dash())
                {
                    dash = Input.GetAxisRaw("Horizontal");
                    playerRigidBody.AddForce(Vector2.left * dashStrength, ForceMode2D.Impulse);
                    //Debug.Log("A DASHED!");

                }

                else if (Input.GetKeyDown(KeyCode.D) && dashingScript.Dash())
                {
                    dash = Input.GetAxisRaw("Horizontal");
                    playerRigidBody.AddForce(Vector2.right * dashStrength, ForceMode2D.Impulse);
                    //Debug.Log("D DASHED!");

                }

                else
                {
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                    {
                        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
                        {
                            //Debug.Log("Entered Move");
                            hori = Input.GetAxisRaw("Horizontal");
                            playerRigidBody.velocity = new Vector2(hori * forceStrength, playerRigidBody.velocity.y);

                        }

                    }
                }

            }
        }





    }

    void FixedUpdate()
    {

        /*if (playerRigidBody.velocity.y > 0)
        {
            playerRigidBody.gravityScale = gravityScale;
        }
        else
        {
            playerRigidBody.gravityScale = fallGravityScale;
        }*/


        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
        }

    }

    public bool IsGrounded()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    IEnumerator playFoghorn()
    {
        //Debug.Log("Entered foghorn");
        lose.Play();
        yield return new WaitForSecondsRealtime(1);
        //Debug.Log("Done foghorn");
    }


}
