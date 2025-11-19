using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [Header("Canvas")]
    public GameObject canvasPause;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        canvasPause.SetActive(false);
    }

    public void OpenPause()
    {
        canvasPause.SetActive(true);
        PauseManager.instance.PauseGame();
    }
}
