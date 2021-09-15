using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float spawnTime;
    public GameObject bullet;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(.8f, 1.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else
        {
            spawnTime = Random.Range(.8f, 1.8f);
            Instantiate(bullet, spawner.transform.position, transform.rotation);
        }
    }
}
