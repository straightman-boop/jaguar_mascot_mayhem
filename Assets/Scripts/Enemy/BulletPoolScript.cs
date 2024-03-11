using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolScript : MonoBehaviour
{
    public static BulletPoolScript instance;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBullets = true;

    private List<GameObject> bullets;

    private void Awake()
    {

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }

        }

        if (notEnoughBullets)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
