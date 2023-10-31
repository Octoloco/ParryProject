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

    [SerializeField]
    private Sprite selectedButton;
    [SerializeField]
    private Sprite unselectedButton;

    [SerializeField]
    private Sprite selectedBar;
    [SerializeField]
    private Sprite unselectedBar;

    [SerializeField]
    private Sprite mutedSound;
    [SerializeField]
    private Sprite unmutedSound;

    [SerializeField]
    private Image musicBar;
    [SerializeField]
    private Image sfxBar;

    [SerializeField]
    private Image mutedMusicButton;
    [SerializeField]
    private Image mutedSFXButton;

    [SerializeField]
    private Image backButton;

    new private void Update()
    {
        base.Update();

        if (UIManager.instance.GetMenuSelection() == "settings")
        {
            if (UIManager.instance.GetMenuIndex() == 0)
            {
                musicBar.GetComponent<Image>().sprite = selectedBar;
                sfxBar.GetComponent<Image>().sprite = unselectedBar;
                backButton.GetComponent<Image>().sprite = unselectedButton;
            }
            else if (UIManager.instance.GetMenuIndex() == 1)
            {
                musicBar.GetComponent<Image>().sprite = unselectedBar;
                sfxBar.GetComponent<Image>().sprite = selectedBar;
                backButton.GetComponent<Image>().sprite = unselectedButton;
            }
            else if (UIManager.instance.GetMenuIndex() == 2)
            {
                musicBar.GetComponent<Image>().sprite = unselectedBar;
                sfxBar.GetComponent<Image>().sprite = unselectedBar;
                backButton.GetComponent<Image>().sprite = selectedButton;
            }

            if (SFXSlider.value <= 0)
            {
                mutedSFXButton.sprite = mutedSound;
            }
            else
            {
                mutedSFXButton.sprite = unmutedSound;
            }

            if (MusicSlider.value <= 0)
            {
                mutedMusicButton.sprite = mutedSound;
            }
            else
            {
                mutedMusicButton.sprite = unmutedSound;
            }

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
