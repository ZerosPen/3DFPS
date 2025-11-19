using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Update Score Event"))]
public class OnUpdateScoreEventSO : ScriptableObject
{
    public UnityAction<int> OnUpdateScoreEvent;

    public void OnUpdateScore(int scoreAmount) => OnUpdateScoreEvent?.Invoke(scoreAmount);
}
