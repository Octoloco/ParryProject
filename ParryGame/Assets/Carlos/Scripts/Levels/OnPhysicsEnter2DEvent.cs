using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class OnPhysicsEnter2DEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnterEvent;
    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onTriggerEnterEvent.Invoke();
        }
    }
}
