using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;

    public int CurrentScore { get; private set; }
    private int currentCombo = 0;

    public void AddScore(bool isMatch)
    {
        if (isMatch)
        {
            currentCombo++;
            int pointsEarned = 10 * currentCombo;
            CurrentScore += pointsEarned;
        }
        else
        {
            currentCombo = 0; // Reset combo on mismatch
            CurrentScore = Mathf.Max(0, CurrentScore - 2); // Small penalty
        }
        UpdateUI();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        currentCombo = 0;
        UpdateUI();
    }

    public void SetScore(int score)
    {
        CurrentScore = score;
        currentCombo = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText) scoreText.text =  CurrentScore.ToString();
        if (comboText) comboText.text = currentCombo > 1 ? $"Combo: x{currentCombo}!" : "";
    }
}