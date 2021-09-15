using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float successTimer = 1f;
    float actualTime = 0f;
    public GameObject bullet;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;
        if (actualTime >= successTimer)
        {
            actualTime = 0;
            Instantiate(bullet, spawner.transform.position, Quaternion.identity);
        }
    }
}
