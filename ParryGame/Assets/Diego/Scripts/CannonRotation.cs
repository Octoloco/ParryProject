using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    private GameObject target;
    private enum TorretTargetType { PLAYER, BELL, CUSTOM, NULL }
   
    [SerializeField] TorretTargetType targetType;

    [SerializeField] GameObject referenceTarget;


    void Start()
    {
        switch (targetType)
        {
            case TorretTargetType.PLAYER:
                target = Player_Controller.instance.gameObject;
                break;
            case TorretTargetType.BELL:
                target = PiñataScript.instance.gameObject;
                break;
            case TorretTargetType.CUSTOM:
                target = referenceTarget;
                break;
            case TorretTargetType.NULL:
                target = null;
                break;
            default:
                break;
        }

    }

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.transform.position - (Vector2)transform.position;
            float newRotation = DirToAngle(direction);
            newRotation = newRotation * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, newRotation);
        }
    }

    public static float DirToAngle(Vector2 dir) => Mathf.Atan2(dir.y, dir.x);
}

