﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public Player_Controller playerScript;
    private List<Collider2D> collisionList = new List<Collider2D>();

    private void OnEnable()
    {
        //StartCoroutine(DeactivateParryArea());
        float angle = DirToAngle(playerScript.GetParryDirection()) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        Collider2D[] collisionsArray = Physics2D.OverlapCircleAll(playerScript.transform.position, 2f);
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

    private void Update()
    {
        Collider2D[] collisionsArray = Physics2D.OverlapCircleAll(playerScript.transform.position, 2f);
        foreach (Collider2D c in collisionsArray)
        {
            if (c.gameObject.CompareTag("Parryable"))
            {
                collisionList.Add(c);
            }
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
            if (c != null)
            {
                if (c.GetComponent<ParryableScript>().parryable)
                {
                    c.GetComponent<ParryableScript>().Redirect(parryDirection);
                }
            }
        }
    }

    public static float DirToAngle(Vector2 dir) => Mathf.Atan2(dir.y, dir.x);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 2);
    }

    public void DeactivateParryArea()
    {
        gameObject.SetActive(false);
    }

    
}
