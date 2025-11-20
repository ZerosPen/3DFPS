using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager instance;

    [Header("Panels")]
    public GameObject PausePanel;
    public GameObject LosePanel;

    [Header("Status Panel")]
    [SerializeField] private bool isPanelOpen;

    [Header("Events")]
    public OnPlayerDeathEventSO onPlayerDeathEvent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void OpenPausePanel()
    {
        PausePanel.SetActive(true);
        isPanelOpen = true;
        PauseManager.instance.PauseGame();
    }

    public void ClosePausePanel()
    {
        PausePanel.SetActive(false);
        isPanelOpen = false;
        PauseManager.instance.UnpauseGame();
        InputManager.Instance.EnableGameplayInputs();
    }

    public void ShowLosePanel()
    {
        LosePanel.SetActive(true);
        isPanelOpen = true;
        PauseManager.instance.PauseGame();
        InputManager.Instance.EnableUIInputs();
        StatusManager.instance.StatusAllPlayer();
    }

    public void CloseAllPanel()
    {
        PausePanel.SetActive(false);
        LosePanel.SetActive(false);
        isPanelOpen = false;
        PauseManager.instance.UnpauseGame();
        InputManager.Instance.EnableGameplayInputs();
    }

    public bool GetIsPanelOpen()
    {
        return isPanelOpen;
    }

    private void OnEnable()
    {
        onPlayerDeathEvent.OnPlayerDeathEvent += ShowLosePanel;
    }

    private void OnDisable()
    {
        onPlayerDeathEvent.OnPlayerDeathEvent -= ShowLosePanel;
    }
}
