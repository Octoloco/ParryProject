using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalMenu : UIPanel
{
    private bool canChangeSelection = true;

    [SerializeField]
    private Sprite selectedButton;
    [SerializeField]
    private Sprite unselectedButton;

    private void Start()
    {
        Destroy(GameObject.Find("Music"));
    }

    new private void Update()
    {
        base.Update();
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
            LevelLoader.instance.LoadSceneByIndex(0);
        }

        if ((Input.GetButtonDown("accept") || Input.GetKeyDown(KeyCode.Space)) && UIManager.instance.GetMenuIndex() == 1)
        {
            Application.Quit();
        }

    }
}
