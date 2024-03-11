using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingScript : MonoBehaviour
{
    private float lastPressedTimeR;
    private float lastPressedTimeL;
    private const float DOUBLE_PRESS_TIME = 0.2f;

    private PlayerScript playerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<PlayerScript>();
    }

    public bool Dash()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            float timeSinceLastPress = Time.time - lastPressedTimeL;

            if (timeSinceLastPress <= DOUBLE_PRESS_TIME)
            {
                //Debug.Log("DASHED!");
                return true;
            }
            else
            {
                //Debug.Log("LEFT!");
            }

            lastPressedTimeL = Time.time;
            return false;

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            float timeSinceLastPress = Time.time - lastPressedTimeR;

            if (timeSinceLastPress <= DOUBLE_PRESS_TIME)
            {
                //Debug.Log("DASHED!");
                return true;
            }
            else
            {
                //Debug.Log("RIGHT!");
            }

            lastPressedTimeR = Time.time;
            return false;
        }

        else
            return false;

    }
}
