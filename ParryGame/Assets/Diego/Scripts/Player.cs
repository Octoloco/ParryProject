using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float deactivateParryZoneSuccessTimer;
    float deactivateParryZoneTimer;

    public CircleCollider2D parryZone;
    public Parry parryScript;
    // Start is called before the first frame update
    void Start()
    {
        parryScript = GameObject.Find("ParryZone").GetComponent<Parry>();
        parryZone = GameObject.Find("ParryZone").GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        deactivateParryZoneTimer += Time.deltaTime;

        if (deactivateParryZoneTimer > deactivateParryZoneSuccessTimer)
        {
            parryZone.enabled = false;
            deactivateParryZoneTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !parryZone.enabled)
        {
            parryScript.upDir = true;
            parryZone.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !parryZone.enabled)
        {
            parryScript.downDir = true;
            parryZone.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !parryZone.enabled)
        {
            parryScript.rightDir = true;
            parryZone.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !parryZone.enabled)
        {
            parryScript.leftDir = true;
            parryZone.enabled = true;
        }

        
    }
}
