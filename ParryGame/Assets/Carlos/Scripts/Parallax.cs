using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] float parallaxEffect;

    float m_startPoint;
    float m_lenght;
   [SerializeField] bool followCamera;
    void Start()
    {
        character = followCamera?FindObjectOfType<Camera>().gameObject: Player_Controller.instance.gameObject;
        m_startPoint = transform.position.x;
        m_lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        float dist = character.transform.position.x * parallaxEffect;
        transform.position = new Vector3(m_startPoint + dist, transform.position.y, transform.position.z);
    }
}
