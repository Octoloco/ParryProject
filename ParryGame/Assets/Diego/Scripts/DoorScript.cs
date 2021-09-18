using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform moveToPointTransform;
    [SerializeField]
    private bool open;

    private Vector3 nextPointToMoveTo;
    private Vector3 startingPos;
    

    void Start()
    {
        startingPos = transform.position;

        if (open)
        {
            nextPointToMoveTo = startingPos;
        }
        else
        {
            nextPointToMoveTo = moveToPointTransform.position;
            transform.position = moveToPointTransform.position;
        }

    }

    void Update()
    {
        if (open)
        {
            nextPointToMoveTo = startingPos;
        }
        else
        {
            nextPointToMoveTo = moveToPointTransform.position;
        }

        Vector3 distanceVector = nextPointToMoveTo - transform.position;
        if (distanceVector.magnitude > 0.05)
        {
            transform.Translate(distanceVector.normalized * Time.deltaTime * speed);
        }
    }

    public void Actuate()
    {
        if (open)
        {
            open = false;
        }
        else
        {
            open = true;
        }
    }


}
