using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
//using static UnityEditorInternal.ReorderableList;

public class EnemyScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    GameTimeScript gameTime;

    public Sprite spriteSmug;
    public Sprite spriteAttack;
    public Sprite spriteDefault;

    public float moveSpeed;
    public bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = GameObject.FindGameObjectWithTag("GameTime").GetComponent<GameTimeScript>();
        moveSpeed = 6f;
        moveRight = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 9f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -9f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            changeSpritetoSmug();
        }

        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            changeSpritetoDefault();
        }

    }



    public void changeSpritetoDefault()
    {
        spriteRenderer.sprite = spriteDefault;
    }

    IEnumerator changeSpritetoAttack()
    {
        spriteRenderer.sprite = spriteAttack;
        yield return new WaitForSeconds(2);
    }

    public void changeSpritetoSmug()
    {
        spriteRenderer.sprite = spriteSmug;
    }

}
