using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Ultimate Deactive Event"))]
public class OnUltimateDeactiveEventSO : ScriptableObject
{
    public UnityAction OnUltimateDeactiveEvent;

    public void OnRaiseUltimate() => OnUltimateDeactiveEvent?.Invoke();
}
