using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
<<<<<<< HEAD:ParryGame/Assets/Carlos/Scripts/Parallax.cs
    [SerializeField] GameObject character;
=======
    [SerializeField] Transform character;
>>>>>>> NewMain:ParryGame/Assets/Master/Scripts/Envirorment/Parallax.cs
    [SerializeField] float parallaxEffect;

    float m_startPoint;
    float m_lenght;
   [SerializeField] bool followCamera;
    void Start()
    {
<<<<<<< HEAD:ParryGame/Assets/Carlos/Scripts/Parallax.cs
        character = followCamera?FindObjectOfType<Camera>().gameObject: Player_Controller.instance.gameObject;
=======
        character = Camera.main.transform;
>>>>>>> NewMain:ParryGame/Assets/Master/Scripts/Envirorment/Parallax.cs
        m_startPoint = transform.position.x;
        m_lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void FixedUpdate()
    {
        float dist = character.position.x * parallaxEffect;
        transform.position = new Vector3(m_startPoint + dist, transform.position.y, transform.position.z);
    }
}
