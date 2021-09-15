using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryableScript : MonoBehaviour
{
    public bool parried = false;

    public void Redirect(Vector2 parryDirection)
    {
        parried = true;
        gameObject.layer = 6;
        float newRotation = DirToAngle(parryDirection);
        newRotation = newRotation * Mathf.Rad2Deg;
        Debug.Log("angle = " + newRotation);
        transform.rotation = Quaternion.Euler(0, 0, newRotation);
    }

    public static float DirToAngle(Vector2 dir) => Mathf.Atan2(dir.y, dir.x);
}
