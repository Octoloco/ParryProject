using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePlatform : MonoBehaviour
{
    [SerializeField] float timeToDestroy;

    IEnumerator Shake()
    {
        Vector3 initialPosition= transform.localPosition;
        while(true)
        {
            transform.localPosition = new Vector3(initialPosition.x+Random.Range(-0.05f, 0.05f), initialPosition.y+Random.Range(-0.05f, 0.05f), initialPosition.z);
            yield return new WaitForSeconds(0.1f);
            transform.localPosition = initialPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(Shake());
            Destroy(gameObject, timeToDestroy);
        }
    }
}
