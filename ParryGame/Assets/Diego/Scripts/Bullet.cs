using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public ParticleSystem trail;
    public ParticleSystem explotion;
    private bool dead;

    void Start()
    {
        
    }

    void Update()
    {
        if (!dead)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinata"))
        {
            collision.gameObject.GetComponent<PiñataScript>().Grow();
        }

        trail.Stop();
        dead = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(GetComponent<Rigidbody2D>());
        explotion.Play();
        GetComponent<SoundEvent>().PlayClip();
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(explotion.startLifetime);
        Destroy(gameObject);
    }
}
