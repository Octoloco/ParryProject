using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] Transform[] bellPosition;
    [SerializeField] Transform[] torretPosition;
    [SerializeField] GameObject[] tutorialVisuals;
    [SerializeField] Transform bell;
    [SerializeField] Transform torret;
    [SerializeField] GameObject playerSpawn;
    [SerializeField] Transform newPosition;
    [SerializeField] UnityEvent onTutorialFinish;
  
    
    int currentState = 0;
    public void InitializeTorretTutorial()
    {
        torret.gameObject.SetActive(true);
        bell.gameObject.SetActive(true);
        tutorialVisuals[0].SetActive(true);

    }
    public void ChangeState()
    {
        currentState += 1;

        if (currentState >= bellPosition.Length)
        {
            onTutorialFinish.Invoke();
            return;
        }
        bell.transform.position = bellPosition[currentState].position;
        torret.transform.position = torretPosition[currentState].position;
        tutorialVisuals[currentState-1].SetActive(false);
        tutorialVisuals[currentState].SetActive(true);


    }

    
}
