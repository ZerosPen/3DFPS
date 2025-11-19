using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponSO))]
public class WeaponSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        WeaponSO weapon = (WeaponSO)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponType"));

        EditorGUILayout.Space();

        if (weapon.weaponType == WeaponType.Range)
        {
            EditorGUILayout.LabelField("Range Weapon Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ammoCapacity"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("reloadTime"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("fireRate"));
        }
        else if (weapon.weaponType == WeaponType.Melee)
        {
            EditorGUILayout.LabelField("Melee Weapon Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("meleeDamage"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("swingTime"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rangeMelee"));

        }

        serializedObject.ApplyModifiedProperties();
    }
}
