using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = ("Events/On Player Death Event"))]
public class OnPlayerDeathEventSO : ScriptableObject
{
    public UnityAction OnPlayerDeathEvent;

    public void OnPlayerDeath() => OnPlayerDeathEvent?.Invoke();
}
