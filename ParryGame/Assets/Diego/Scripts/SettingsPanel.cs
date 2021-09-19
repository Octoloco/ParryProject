using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : UIPanel
{
    private bool canChangeSelection = false;
    [SerializeField]
    private Slider SFXSlider;
    [SerializeField]
    private Slider MusicSlider;
    [SerializeField]
    private float sliderSpeed;

    new private void Update()
    {
        base.Update();

        if (UIManager.instance.GetMenuSelection() == "settings")
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
            else if(Input.GetAxis("Vertical") > -.3 && Input.GetAxis("Vertical") < .3)
            {
                canChangeSelection = true;
            }

            if ((Input.GetAxis("Horizontal") > .3 || Input.GetKey(KeyCode.D)) && UIManager.instance.GetMenuIndex() == 0)
            {
                MusicSlider.value += sliderSpeed * Time.deltaTime;
            }
            else if ((Input.GetAxis("Horizontal") < -.3 || Input.GetKey(KeyCode.A)) && UIManager.instance.GetMenuIndex() == 0)
            {
                MusicSlider.value -= sliderSpeed * Time.deltaTime;
            }

            if ((Input.GetAxis("Horizontal") > .3 || Input.GetKey(KeyCode.D)) && UIManager.instance.GetMenuIndex() == 1)
            {
                SFXSlider.value += sliderSpeed * Time.deltaTime;
            }
            else if ((Input.GetAxis("Horizontal") < -.3 || Input.GetKey(KeyCode.A)) && UIManager.instance.GetMenuIndex() == 1)
            {
                SFXSlider.value -= sliderSpeed * Time.deltaTime;
            }

            if ((Input.GetButtonDown("accept") || Input.GetKeyDown(KeyCode.Space)) && UIManager.instance.GetMenuIndex() == 0)
            {
                UIManager.instance.PlaySelectSound();
                UIManager.instance.MuteMusic();
            }

            if ((Input.GetButtonDown("accept") || Input.GetKeyDown(KeyCode.Space)) && UIManager.instance.GetMenuIndex() == 1)
            {
                UIManager.instance.PlaySelectSound();
                UIManager.instance.MuteSFX();
            }

            if ((Input.GetButtonDown("accept") || Input.GetKeyDown(KeyCode.Space)) && UIManager.instance.GetMenuIndex() == 2)
            {
                UIManager.instance.PlaySelectSound();
                UIManager.instance.HideSettingsPanel();
                UIManager.instance.ShowMainMenuPanel();
            }
        }
    }
}
