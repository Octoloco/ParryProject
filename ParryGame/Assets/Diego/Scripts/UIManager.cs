using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private MainMenuPanel mainMenuPanel;
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
        
    }

    void Update()
    {
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
        LevelLoader.instance.LoadNextLevel(1);
    }

    public void PlayHoverSound()
    {
        sfxSoundEvent.PlayClipByIndex(6);
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
