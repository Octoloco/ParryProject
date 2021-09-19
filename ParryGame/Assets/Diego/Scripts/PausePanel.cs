using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : UIPanel
{
    private bool canChangeSelection = true;
    public bool isShowing;

    [SerializeField]
    private Sprite selectedButton;
    [SerializeField]
    private Sprite unselectedButton;

    new private void Update()
    {
        base.Update();

        if (UIManager.instance.GetMenuSelection() == "pause")
        {
            if (UIManager.instance.GetMenuIndex() == 0)
            {
                transform.GetChild(0).GetComponent<Image>().sprite = selectedButton;
                transform.GetChild(1).GetComponent<Image>().sprite = unselectedButton;
            }
            else if (UIManager.instance.GetMenuIndex() == 1)
            {
                transform.GetChild(0).GetComponent<Image>().sprite = unselectedButton;
                transform.GetChild(1).GetComponent<Image>().sprite = selectedButton;
            }

            if ((Input.GetAxis("Vertical") < -.3 || Input.GetKeyDown(KeyCode.S)) && canChangeSelection && UIManager.instance.GetMenuIndex() < 1)
            {
                canChangeSelection = false;
                UIManager.instance.AddMenuIndex();
            }
            else if ((Input.GetAxis("Vertical") > .3 || Input.GetKeyDown(KeyCode.W)) && canChangeSelection && UIManager.instance.GetMenuIndex() > 0)
            {
                canChangeSelection = false;
                UIManager.instance.SubstractMenuIndex();
            }
            else if (Input.GetAxis("Vertical") > -.3 && Input.GetAxis("Vertical") < .3)
            {
                canChangeSelection = true;
            }

            if ((Input.GetButtonDown("accept") || Input.GetKeyDown(KeyCode.Space)) && UIManager.instance.GetMenuIndex() == 0)
            {
                UIManager.instance.PlaySelectSound();
                LevelLoader.instance.LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
            }

            if ((Input.GetButtonDown("accept") || Input.GetKeyDown(KeyCode.Space)) && UIManager.instance.GetMenuIndex() == 1)
            {
                UIManager.instance.PlaySelectSound();
                LevelLoader.instance.LoadSceneByIndex(1);
            }
        }
    }
}
