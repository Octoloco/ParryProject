using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] float parallaxEffect;

    float m_startPoint;
    float m_lenght;
    void Start()
    {
        m_startPoint = character.transform.position.x;
        m_lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        float dist = character.transform.position.x * parallaxEffect;
        transform.position = new Vector3(m_startPoint + dist, transform.position.y, transform.position.z);
    }
}
