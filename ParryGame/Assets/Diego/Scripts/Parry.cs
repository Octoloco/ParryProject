using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public Player_Controller playerScript;
    private List<Collider2D> collisionList = new List<Collider2D>();

    private void OnEnable()
    {
        StartCoroutine(DeactivateParryArea());

        Collider2D[] collisionsArray = Physics2D.OverlapCircleAll(gameObject.transform.position, 2.1f);
        foreach (Collider2D c in collisionsArray)
        {
            if (c.gameObject.CompareTag("Parryable"))
            {
                collisionList.Add(c);
            }
        }

        if (collisionList.Count > 0)
        {
            ParryObject(playerScript.GetParryDirection());
        }
    }

    private void OnDisable()
    {
        collisionList.Clear();
    }

    private void ParryObject(Vector2 parryDirection)
    {
        foreach (Collider2D c in collisionList)
        {
            if (!c.GetComponent<ParryableScript>().parried)
            {
                c.GetComponent<ParryableScript>().Redirect(parryDirection);
            }
        }
    }

    IEnumerator DeactivateParryArea()
    {
        yield return new WaitForSeconds(.05f);
        gameObject.SetActive(false);
    }
}
