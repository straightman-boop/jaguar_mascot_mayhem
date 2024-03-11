using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FireBulletScript : MonoBehaviour
{
    EnemyScript enemyScript;

    BulletScript bullet;

    LogicScript player;

    float _t; float _interval; 

    private int bulletsAmount = 0;

    private float startAngle = 90f, endAngle = 270f;

    private float fireRate = 2f;

    public float time = 0;

    private Vector2 bulletMoveDirection;

    bool exec; int life = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        enemyScript = GetComponent<EnemyScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        exec = true;

    }

    private void Update()
    {



    }

    private void FixedUpdate()
    {
        //Debug.Log(exec + " = exec");

        if (exec == true)
        {
            //Debug.Log(fireRate + " = fire rate");
            InvokeRepeating("Fire", 0f, fireRate);
            exec = false;
        }

        difficultyIncrement();

    }

    private void Fire()
    {
        float timeT = 50 * Time.deltaTime;


        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {

            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPoolScript.instance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BulletScript>().SetMoveDirection(bulDir);

            angle += angleStep;

        }


    }
    void difficultyIncrement()
    {
        //Debug.Log(time + "= difficulty Increment");
        time = time + Time.deltaTime;
        time = Mathf.Round(time * 100f) / 100f;


        //FIRST PHASE

        if (time == 0 || time < 12)
        {
            fireRate = 2f;
            startAngle = 180;
            endAngle = 180;
            bulletsAmount = 0;
        }

        else if (time >= 12 && time < 22)
        {
            //Debug.Log("Life = " + life);
            if (life == 0)
            {
                //Debug.Log("Accessed");
                CancelInvoke("Fire");
                exec = true;
                fireRate = 2f;
            }

            startAngle = 185;
            endAngle = 175;
            bulletsAmount = 5;

            life++;

            if (time >= 21 && time <= 22)
            {
                life = 0;
            }

        }

        else if (time >= 22 && time < 30)
        {
            //Debug.Log("Life = " + life);
            if (life == 0)
            {
                //Debug.Log("Accessed");
                CancelInvoke("Fire");
                exec = true;
                fireRate = 2f;
            }

            startAngle = 150;
            endAngle = 210;
            bulletsAmount = 3;

            life++;

            if (time >= 29 && time <= 30)
            {
                life = 0;
            }

        }

        else if (time >= 30 && time < 40)
        {
            //Debug.Log("Life = " + life);
            if (life == 0)
            {
                //Debug.Log("Accessed");
                CancelInvoke("Fire");
                exec = true;
                fireRate = 2f;
            }

            startAngle = 135;
            endAngle = 225;
            bulletsAmount = 5;

            life++;

            if (time >= 39 && time <= 40)
            {
                life = 0;
            }
        }

        //INTERMISSION PHASE 

        else if (time >= 40 && time < 50)
        {
            //Debug.Log("Life = " + life);
            if (life == 0)
            {
                //Debug.Log("Accessed");
                CancelInvoke("Fire");
                exec = true;
                fireRate = 1.7f;
            }

            startAngle = 120;
            endAngle = 240;
            bulletsAmount = 7;

            life++;

            if (time >= 50)
            {
                life = 0;
            }
        }

        else if (time >= 50 && time < 57)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 1.5f;
            }

            startAngle = 135;
            endAngle = 225;
            bulletsAmount = 9;

            life++;

            if (time >= 56 && time <= 57)
            {
                life = 0;
            }
        }

        //SECOND PHASE
        else if (time >= 57 && time < 73)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.5f;
            }

            startAngle = 190;
            endAngle = 170;
            bulletsAmount = 5;

            life++;

            if (time >= 72 && time <= 73)
            {
                life = 0;
            }
        }

        //THIRD PHASE

        else if (time >= 73 && time < 80)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.5f;
            }

            startAngle = 150;
            endAngle = 210;
            bulletsAmount = 2;

            life++;

            if (time >= 79 && time <= 80)
            {
                life = 0;
            }
        }

        else if (time >= 80 && time < 90)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 1f;
            }

            startAngle = 0;
            endAngle = 360;
            bulletsAmount = 25;

            life++;

            if (time >= 89 && time <= 90)
            {
                life = 0;
            }
        }

        else if (time >= 90 && time < 100)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.5f;
            }

            startAngle = 0;
            endAngle = 360;
            bulletsAmount = 25;

            life++;

            if (time >= 99 && time <= 100)
            {
                life = 0;
            }
        }

        else if (time >= 100 && time < 110)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.1f;
            }

            startAngle = 0;
            endAngle = 360;
            bulletsAmount = 25;

            life++;

            if (time >= 109 && time <= 110)
            {
                life = 0;
            }
        }

        else if (time >= 100 && time < 115)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.1f;
            }

            startAngle = 150;
            endAngle = 210;
            bulletsAmount = 25;

            life++;

            if (time >= 114 && time <= 115)
            {
                life = 0;
            }
        }

        else if (time >= 115 && time < 120)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.1f;
            }

            startAngle = 120;
            endAngle = 150;
            bulletsAmount = 25;

            life++;

            if (time >= 119 && time <= 120)
            {
                life = 0;
            }
        }

        else if (time >= 120 && time < 125)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.1f;
            }

            startAngle = 210;
            endAngle = 240;
            bulletsAmount = 25;

            life++;

            if (time >= 124 && time <= 125)
            {
                life = 0;
            }
        }

        else if (time >= 125 && time < 130)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.1f;
            }

            startAngle = 135;
            endAngle = 225;
            bulletsAmount = 2;

            life++;

            if (time >= 129 && time <= 130)
            {
                life = 0;
            }
        }

        else if (time >= 130 && time < 135)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.1f;
            }

            startAngle = 90;
            endAngle = 270;
            bulletsAmount = 30;

            life++;

            if (time >= 134 && time <= 135)
            {
                life = 0;
            }
        }

        else if (time >= 135 && time < 140) //END
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.1f;
            }

            startAngle = 0;
            endAngle = 360;
            bulletsAmount = 10;

            life++;

            if (time >= 139 && time <= 140)
            {
                life = 0;
            }
        }

        else if (time >= 140 && time < 145)
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.5f;
            }

            startAngle = 0;
            endAngle = 360;
            bulletsAmount = 25;

            life++;

            if (time >= 144 && time <= 145)
            {
                life = 0;
            }
        }

        else if (time >= 145 && time < 147) //END
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 1.5f;
            }

            startAngle = 0;
            endAngle = 360;
            bulletsAmount = 25;

            life++;

            if (time >= 146 && time <= 147)
            {
                life = 0;
            }
        }

        else if (time >= 147 && time <= 151) //END
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0.1f;
            }

            startAngle = 0;
            endAngle = 360;
            bulletsAmount = 50;

            life++;

            if (time >= 151 && time <= 151.9)
            {
                life = 0;
            }
        }

        else if (time >= 152 && time <= 155) //END
        {
            if (life == 0)
            {
                CancelInvoke("Fire");
                exec = true;
                fireRate = 0f;
            }

            startAngle = 0;
            endAngle = 0;
            bulletsAmount = 0;

            life++;

            if (time >= 151 && time <= 151.9)
            {
                life = 0;
            }
        }

    }



}
