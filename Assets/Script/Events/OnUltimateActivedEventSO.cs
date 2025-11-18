using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Ultimate Actived Event"))]
public class OnUltimateActivedEventSO : ScriptableObject
{
    public UnityAction OnUltimateActivedEvent;

    public void OnRaiseUltimate() => OnUltimateActivedEvent?.Invoke();
}
