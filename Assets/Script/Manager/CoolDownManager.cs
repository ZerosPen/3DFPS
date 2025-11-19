using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownManager : MonoBehaviour
{
    public static CoolDownManager instance;

    [Header("Status Cooldown")]
    [SerializeField] private float _coolDownSkill;
    [SerializeField] private float _coolDownUltimate;

    [Header("Events")]
    public OnUltimateActivedEventSO onUltimateActivedEvent;
    public OnUltimateDeactiveEventSO onUltimateDeactiveEvent;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (_coolDownSkill > 0)
        {
            _coolDownSkill -= Time.deltaTime;
        }
            

        if (_coolDownUltimate > 0)
        {
            _coolDownUltimate -= Time.deltaTime;
        }
    }

    public void StarCooldownSkill(float durationCoolDown)
    {
        _coolDownSkill = durationCoolDown;
    }

    public void StarCooldownUltimate(float durationCoolDown)
    {
        _coolDownUltimate = durationCoolDown;
        Debug.Log("Using Ulti");
    }

    public float GetCoolDownSkill()
    {
        return _coolDownSkill;
    }

    public float GetCoolDownUltimate()
    {
        return _coolDownUltimate;
    }

}
