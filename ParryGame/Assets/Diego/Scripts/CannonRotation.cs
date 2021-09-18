using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    private Pi�ataScript pi�ata;

    void Start()
    {
        pi�ata = Pi�ataScript.instance;
    }

    void Update()
    {
        if (pi�ata != null)
        {
            Vector2 direction = (Vector2)pi�ata.transform.position - (Vector2)transform.position;
            float newRotation = DirToAngle(direction);
            newRotation = newRotation * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, newRotation);
        }
    }

    public static float DirToAngle(Vector2 dir) => Mathf.Atan2(dir.y, dir.x);
}
