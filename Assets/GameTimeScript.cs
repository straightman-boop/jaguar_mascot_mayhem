using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeScript : MonoBehaviour
{
    public float time = 0;

    public PlayerScript playerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeProgression();

        //if (playerScript.playerRigidBody.position.x > playerScript.deadZoneX || playerScript.playerRigidBody.position.x < -playerScript.deadZoneX || playerScript.playerRigidBody.position.y > playerScript.deadZoneY || playerScript.playerRigidBody.position.y < -playerScript.deadZoneY)
        //{
        //    //Debug.Log("Not cool");
        //}

        //else
        //{
        //    timeProgression();

        //}
    }

    public void timeProgression()
    {
        Debug.Log(time + " = gameTime");
        time = time + Time.deltaTime;
        time = Mathf.Round(time * 100f) / 100f;

    }
}
