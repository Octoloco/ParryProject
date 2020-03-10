using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    public bool upDir;
    public bool downDir;
    public bool leftDir;
    public bool rightDir;

    public List<GameObject> bulletsEnetered;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        bulletsEnetered = new List<GameObject>();

        bulletsEnetered.Add(other.gameObject);

        foreach (GameObject b in bulletsEnetered) {

            if (other.tag == "Bullet")
            {
                if (upDir)
                {
                    other.transform.rotation = Quaternion.Euler(0, 0, -90);
                    upDir = false;
                    other.tag = "ParriedBullet";
                    GetComponent<CircleCollider2D>().enabled = false;
                }
                else if (downDir)
                {
                    
                    other.transform.rotation = Quaternion.Euler(0, 0, 90);
                    downDir = false;
                    other.tag = "ParriedBullet";
                    GetComponent<CircleCollider2D>().enabled = false;
                }
                else if (leftDir)
                {
                    other.transform.rotation = Quaternion.Euler(0, 0, 0);
                    leftDir = false;
                    other.tag = "ParriedBullet";
                    GetComponent<CircleCollider2D>().enabled = false;
                }
                else if (rightDir)
                {
                    other.transform.rotation = Quaternion.Euler(0, 0, 180);
                    rightDir = false;
                    other.tag = "ParriedBullet";
                    GetComponent<CircleCollider2D>().enabled = false;
                }
            }

            
        }
    }

}
