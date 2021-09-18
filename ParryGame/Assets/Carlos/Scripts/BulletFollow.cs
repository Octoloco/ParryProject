using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
        float newRotation = DirToAngle(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, newRotation * Mathf.Rad2Deg), rotateSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //transform.up = (target.transform.position - transform.position);
        //Vector3 movement = (target.transform.position - transform.position).normalized * Time.deltaTime * m_speed;
        //transform.position += movement;
    }

    public static float DirToAngle(Vector2 dir) => Mathf.Atan2(dir.y, dir.x);
}
