using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Character Data SO"))]
public class CharacterDataSO : ScriptableObject
{
    [Header("Desc Character")]
    public string nameCharacter;

    [Header("Desc Character")]
    public float healthCharacter;

    [Header("Movement Character")]
    public float walkSpeedCharacter;
    public float runSpeedCharacter;

    [Header("Range")]
    public float interactRangeCharacter;
    public float meleeRangerCharacter;

    [Header("Jump Character")]
    public float jumpHeightCharacter;
    public float gravityCharacter;
}
