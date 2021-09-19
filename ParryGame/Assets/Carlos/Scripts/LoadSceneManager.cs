using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneManager : MonoBehaviour
{
    public void MoveToNextSceneDelay(float delay)
    {

        StartCoroutine(LoadScene(delay));
    }

    IEnumerator LoadScene(float time)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1 >= SceneManager.sceneCount ? 0 : currentScene + 1;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nextScene);
    }
}
