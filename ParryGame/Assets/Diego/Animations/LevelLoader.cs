using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance = null;
    [SerializeField]
    private float transitionTime;

    [SerializeField]
    private Animator[] animatorsList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel(int time=0)
    {
        StartCoroutine(LoadScene(time));
    }

    private IEnumerator LoadLevel(int index)
    {
        foreach (Animator a in animatorsList)
        {
            a.SetTrigger("start");
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
    IEnumerator LoadScene(float time)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1 >= SceneManager.sceneCount ? 0 : currentScene + 1;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nextScene);
    }


}
