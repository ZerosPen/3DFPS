using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LosePanelUI : MonoBehaviour
{
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI actionText;

    public void UpdateLosePanel(int kills, int scores, int actions)
    {
        killsText.text = kills.ToString();
        scoreText.text = scores.ToString();
        actionText.text = actions.ToString();
    }
}
