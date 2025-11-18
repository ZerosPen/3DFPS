using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateManager : MonoBehaviour
{
    public static UltimateManager instance;

    [Header("Events")]
    public OnUltimateActivedEventSO onUltimateActivedEvent;
    public OnUltimateDeactiveEventSO onUltimateDeactiveEvent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivateUltimate(float cooldown, float duration)
    {
        onUltimateActivedEvent.OnRaiseUltimate();
        StartCoroutine(DurationUltimate(cooldown, duration));
    }


    IEnumerator DurationUltimate(float cooldown, float duration)
    {
        yield return new WaitForSeconds(duration);
        onUltimateDeactiveEvent.OnRaiseUltimate();
        CoolDownManager.instance.StarCooldownUltimate(cooldown);
    }
}
