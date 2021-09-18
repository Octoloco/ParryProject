using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform moveToPointTransform;

    private Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        Vector3 distanceVector = moveToPointTransform.position - transform.position;
        if (distanceVector.magnitude > 0.05)
        {
            transform.Translate(distanceVector.normalized * Time.deltaTime * speed);
        }
        else
        {
            Vector3 tempPos = moveToPointTransform.position;
            moveToPointTransform.position = startingPos;
            startingPos = tempPos;
        }
    }
}
