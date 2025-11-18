using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [Header("Settings Animation")]
    [SerializeField] private float lerpTimer;
    [SerializeField] private float chipSpeed;

    [Header("Refence")]
    public Image frontHealthBar;
    public Image backHealthBar;

    public void UpdateHealthUI(float healthPoint, float maxHealthPoint)
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = healthPoint / maxHealthPoint;

        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        else
        {
            lerpTimer = 0;
        }
    }

    public void ResetLerpTime()
    {
        lerpTimer = 0; 
    }
}
