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

    public void ShowMainMenuPanel()
    {
        mainMenuPanel.Show();
    }

    public void HideMainMenuPanel()
    {
        mainMenuPanel.Hide();
    }

    public void StartGame()
    {
        LevelLoader.instance.LoadNextLevel(1);
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
        settingsPanel.Show();
    }

    public void HideSettingsPanel()
    {
        settingsPanel.Hide();
    }

    public void DrawLevel(int level)
    {
        //gamePanel.DrawLevel(level);
    }
}
