using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LogicScript : MonoBehaviour
{
    public int pointScore = 0;
    public float timeScore = 0;
    public float timeTest = 0;

    public Text scoreText;
    public Text timeText;
    public Text scoreWin;
    public Text timeWin;

    public Text timeTester;

    public AudioSource bgmusic;
    public GameObject gameOver;
    public GameObject gameWin;
    public GameObject bg;

    PlayerScript playerScript;

    float moveSpeed;


    public void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        moveSpeed = 0.5f;

        bgmusic.Play();
    }

    public void Update()
    {
        bg.transform.position = bg.transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }

    public void FixedUpdate()
    {
        increaseSped();

        if (playerScript.playerRigidBody.position.x > playerScript.deadZoneX || playerScript.playerRigidBody.position.x < -playerScript.deadZoneX || playerScript.playerRigidBody.position.y > playerScript.deadZoneY || playerScript.playerRigidBody.position.y < -playerScript.deadZoneY)
        {
            //Debug.Log("Not cool");
        }

        else
        {
            incrementTime();
            incrementTimeTester();

        }

    }

    public void incrementTime()
    {
        //Debug.Log(timeScore);
        timeScore = timeScore + Time.deltaTime;
        timeScore = Mathf.Round(timeScore * 100f) / 100f;
        timeText.text = timeScore.ToString();
        timeWin.text = timeScore.ToString();
    }
    public void incrementTimeTester()
    {
        Debug.Log(timeTest + " = timeTest");
        timeTest = timeTest + Time.deltaTime;
        timeTest = Mathf.Round(timeTest * 100f) / 100f;
        timeTester.text = timeTest.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreAdded)
    {
        pointScore += scoreAdded;
        scoreText.text = pointScore.ToString();
        scoreWin.text = pointScore.ToString();

    }

    public void quitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOverScreen()
    {
        gameOver.SetActive(true);

    }

    public void victoryScreen()
    {
        gameWin.SetActive(true);

    }

    void increaseSped()
    {
        //FIRST PHASE
        if (timeTest >= 12 && timeTest < 22)
        {
            moveSpeed = 0.7f;
        }

        else if (timeTest >= 22 && timeTest < 30)
        {
            moveSpeed = 1f;
        }

        else if (timeTest >= 30 && timeTest < 40)
        {
            moveSpeed = 1.2f;
        }

        else if (timeTest >= 40 && timeTest < 58)
        {
            moveSpeed = 1.5f;
        }

        //SECOND PHASE
        else if (timeTest >= 58 && timeTest < 60)
        {
            moveSpeed = 1.7f;
        }

        else if (timeTest >= 60 && timeTest < 70)
        {
            moveSpeed = 2f;
        }

        else if (timeTest >= 70 && timeTest < 80)
        {
            moveSpeed = 2.2f;
        }

        //THIRD PHASE

        else if (timeTest >= 70 && timeTest < 80)
        {
            moveSpeed = 2.5f;
        }

        else if (timeTest >= 80 && timeTest < 90)
        {
            moveSpeed = 2.7f;
        }

        else if (timeTest >= 90 && timeTest < 150)
        {
            moveSpeed = 3f;
        }
    }
}
