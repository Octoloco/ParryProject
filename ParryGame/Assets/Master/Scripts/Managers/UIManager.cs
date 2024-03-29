using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public bool gamePaused = true;
    public bool canChangeSelection = true;

    [SerializeField]
    private MainMenuPanel mainMenuPanel;
    [SerializeField]
    private PausePanel pausePanel;
    [SerializeField]
    private SettingsPanel settingsPanel;
    [SerializeField]
    private SoundEvent sfxSoundEvent;
    [SerializeField]
    private SFXManager sfxManager;
    [SerializeField]
    private SFXManager musicManager;

    public string menuSelection = "none";
    public int menuIndex = 0;

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

    void Start()
    {
        gamePaused = true;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetAxis("Submit") > .3) && canChangeSelection)
            {
                canChangeSelection = false;
                if (!pausePanel.isShowing)
                {
                    gamePaused = true;
                    menuSelection = "pause";
                    pausePanel.isShowing = true;
                    pausePanel.Show();
                }
                else
                {
                    gamePaused = false;
                    menuSelection = "none";
                    pausePanel.isShowing = false;
                    pausePanel.Hide();
                }
            }
        }
    }

    public void AddMenuIndex()
    {
        PlayHoverSound();
        menuIndex++;
    }

    public void SubstractMenuIndex()
    {
        PlayHoverSound();
        menuIndex--;
    }

    public string GetMenuSelection()
    {
        return menuSelection;
    }

    public int GetMenuIndex()
    {
        return menuIndex;
    }

    public void MuteMusic()
    {
        musicManager.Mute();
    }

    public void MuteSFX()
    {
        sfxManager.Mute();
    }

    public void ShowMainMenuPanel()
    {
        menuSelection = "menu";
        menuIndex = 0;
        mainMenuPanel.Show();
    }

    public void HideMainMenuPanel()
    {
        menuSelection = "none";
        menuIndex = 0;
        mainMenuPanel.Hide();
    }

    public void StartGame()
    {
        menuSelection = "none";
        menuIndex = 0;
        LevelLoader.instance.LoadSceneByIndex(2);
    }

    public void PlayHoverSound()
    {
        sfxSoundEvent.PlayClipByIndex(6);
    }

    public void PlayStartSound()
    {
        sfxSoundEvent.PlayClipByIndex(8);
    }

    public void PlaySelectSound()
    {
        sfxSoundEvent.PlayClipByIndex(7);
    }

    public void ShowGameOverPanel()
    {
        //gameOverPanel.finished = false;
        //gameOverPanel.Show();
    }

    public void HideGameOverPanel()
    {
        //gameOverPanel.Hide();
    }

    public void SetFinalScore(int finalScore)
    {
        //gameOverPanel.SetScoreGoal(finalScore);
    }

    public void UpdateGameScore(int newScore)
    {
        //gamePanel.UpdateScore(newScore);
    }

    public void ShowSettingsPanel()
    {
        menuSelection = "settings";
        menuIndex = 0;
        settingsPanel.Show();
    }

    public void HideSettingsPanel()
    {
        menuSelection = "none";
        menuIndex = 0;
        settingsPanel.Hide();
    }

    public void DrawLevel(int level)
    {
        //gamePanel.DrawLevel(level);
    }
}
