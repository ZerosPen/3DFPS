using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    [Header("Settings Animation")]
    [SerializeField] private float lerpTimer;
    [SerializeField] private float chipSpeed;

    [Header("Refence")]
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI valueHealthBar;
    public TextMeshProUGUI ammo;

    [Header("Events")]
    public OnUltimateActivedEventSO onUltimateActivedEvent;
    public OnUltimateDeactiveEventSO onUltimateDeactiveEvent;

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    public void UpdateAmmoUI(int currentAmmo, int maxAmmo)
    {
        if (currentAmmo == 0 && maxAmmo == 0)
        {
            ammo.text = string.Empty;
        }
        else
        {
            ammo.text = $"{currentAmmo} / {maxAmmo}";
        }
    }

    public void UpdateHealthBarUI(float healthPoint, float maxHealthPoint)
    {
        valueHealthBar.text = healthPoint.ToString() + " / " + maxHealthPoint.ToString();
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
        else if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
        else
        {
            lerpTimer = 0;
        }
    }

    void UpgradeHealthUI()
    {
        Debug.Log("Resize to 200HP!");
    }

    private void ResetHealthUI()
    {
        Debug.Log("Resize to 100HP!");
    }

    public void ResetLerptime()
    {
        lerpTimer = 0;
    }

    private void OnEnable()
    {
        onUltimateActivedEvent.OnUltimateActivedEvent   += UpgradeHealthUI;
        onUltimateDeactiveEvent.OnUltimateDeactiveEvent += ResetHealthUI;
    }

    private void OnDisable()
    {
        onUltimateActivedEvent.OnUltimateActivedEvent   -= UpgradeHealthUI;
        onUltimateDeactiveEvent.OnUltimateDeactiveEvent -= ResetHealthUI;
    }
}
