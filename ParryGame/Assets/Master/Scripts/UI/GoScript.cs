using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoScript : MonoBehaviour
{
    public void Go()
    {
        UIManager.instance.gamePaused = false;
    }
}
