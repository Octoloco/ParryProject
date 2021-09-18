using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    [SerializeField] float m_speed;
    [SerializeField] GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.up = (target.transform.position - transform.position);
        Vector3 movement = (target.transform.position - transform.position).normalized * Time.deltaTime * m_speed;
        transform.position += movement;
    }
}
