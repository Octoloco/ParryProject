using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : UIPanel
{
    private bool canChangeSelection = true;

    new private void Update()
    {
        base.Update();

        if (UIManager.instance.GetMenuSelection() == "menu")
        {
            if ((Input.GetAxis("Vertical") < -.3 || Input.GetKeyDown(KeyCode.S)) && canChangeSelection && UIManager.instance.GetMenuIndex() < 2)
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
                UIManager.instance.StartGame();
            }

            if ((Input.GetButtonDown("accept") || Input.GetKeyDown(KeyCode.Space)) && UIManager.instance.GetMenuIndex() == 1)
            {
                UIManager.instance.PlaySelectSound();
                UIManager.instance.HideMainMenuPanel();
                UIManager.instance.ShowSettingsPanel();
            }

            if (((Input.GetButtonDown("accept") || Input.GetKeyDown(KeyCode.Space)) && UIManager.instance.GetMenuIndex() == 2) || Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

}
