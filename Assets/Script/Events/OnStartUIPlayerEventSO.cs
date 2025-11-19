using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Start UI Player Event"))]
public class OnStartUIPlayerEventSO : ScriptableObject
{
    public UnityAction<int> OnStartUIPlayerEvent;

    public void OnStartUIPlayer(int scoreAmount) => OnStartUIPlayerEvent?.Invoke(scoreAmount);
}
