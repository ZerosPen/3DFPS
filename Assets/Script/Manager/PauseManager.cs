using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    public bool isPaused { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;


    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}
