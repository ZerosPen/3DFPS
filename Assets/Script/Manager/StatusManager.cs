using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager instance;

    [Header("Status game")]
    [SerializeField] private int _score;
    [SerializeField] private int _killedEnemy;
    [SerializeField] private int _action;

    public LosePanelUI losePanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScoreStatus(int value)
    {
        _score = value;
    }

    public void UpdatekilledEnemyStatus()
    {
        _killedEnemy++;  
    }

    public void UpdateActionStatus(int value)
    {
        _action++;
    }

    public void StatusAllPlayer()
    {
        losePanel.UpdateLosePanel(_killedEnemy, _score, _action);
    }
}
