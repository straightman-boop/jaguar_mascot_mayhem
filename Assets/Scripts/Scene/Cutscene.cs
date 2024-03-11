using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public float changeTime;
    public string sceneName;

    private void Start()
    {



    }

    private void Update()
    {
        changeTime -= Time.deltaTime;

        if (changeTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
