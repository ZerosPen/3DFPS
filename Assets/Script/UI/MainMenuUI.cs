using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [Header("Main Menus Panel")]
    public GameObject MainMenuPanel;
    public GameObject SettingsPanel;
    public GameObject BestScorePanel;

    private void Start()
    {
        MusicManager.instance.PlayMusic("BGM1");
    }

    public void PlayGame()
    {
        LevelManager.instance.LoadScene("MainGame", "CrossFade");
    }

    public void OpenSettings()
    {
        MainMenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void OpenBestScore()
    {
        MainMenuPanel.SetActive(false);
        BestScorePanel.SetActive(true);
    }

    public void CloseBestScore()
    {
        BestScorePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
