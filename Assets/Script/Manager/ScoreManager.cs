using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Score Config")]
    [SerializeField] private int _score;

    [Header("Events")]
    public OnUpdateScoreEventSO OnUpdateScoreEvent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void AddScore(int amountScore)
    {
        _score += amountScore;
        OnUpdateScoreEvent.OnUpdateScore(_score);
    }
}
