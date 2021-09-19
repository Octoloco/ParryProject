using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float radius;
    [SerializeField]
    private Transform rotateAroundPoint;
    private float angle = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (!UIManager.instance.gamePaused)
        {
            angle += speed * Time.deltaTime;
            transform.position = new Vector3(rotateAroundPoint.position.x + radius * Mathf.Cos(angle), rotateAroundPoint.position.y + radius * Mathf.Sin(angle), 0);
        }
    }
}
