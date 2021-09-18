using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotatingPlatform : MonoBehaviour
{
    [SerializeField]
    private bool rotateRight;
    [SerializeField]
    private float speed;
    private float mod = 1;

    void Update()
    {
        if (!rotateRight)
        {
            mod = -1;
        }
        else
        {
            mod = 1;
        }

        transform.Rotate(Vector3.forward * speed * Time.deltaTime * mod);
    }
}
