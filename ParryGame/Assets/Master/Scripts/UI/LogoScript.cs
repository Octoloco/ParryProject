using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitForRead());   
    }

    IEnumerator WaitForRead()
    {
        yield return new WaitForSeconds(6);
        LevelLoader.instance.LoadSceneByIndex(1);
    }
}
