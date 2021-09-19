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
            GetComponentInParent<SoundEvent>().PlayClip();
            spawnTime = Random.Range(.8f, 1.8f);
            GetComponent<Animator>().SetTrigger("shoot");
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, spawner.transform.position, transform.parent.transform.rotation);
    }
}
