using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColliderScript : MonoBehaviour
{
    public LogicScript logicScript;
    public SecondaryMoveScript secondPlatform;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        secondPlatform = GetComponent<SecondaryMoveScript>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            logicScript.addScore(1);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(transparent());

    }

    IEnumerator transparent()
    {
        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        yield return new WaitForSeconds(1.3f);

        secondPlatform.destroyGameObject();
    }
}
