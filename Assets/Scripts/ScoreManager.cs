using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI comboText;

    [Header("Scoring Rules")]
    [SerializeField] private int baseMatchPoints = 10;
    [SerializeField] private int basePenaltyPoints = 2;

    public int CurrentScore { get; private set; }
    private int currentCombo = 0;
    private int consecutiveMisses = 0;

    public void AddScore(bool isMatch)
    {
        if (isMatch)
        {
            currentCombo++;
            consecutiveMisses = 0; // Reset misses
            int pointsEarned = baseMatchPoints * currentCombo;
            CurrentScore += pointsEarned;
        }
        else
        {
            currentCombo = 0; // Reset combo
            consecutiveMisses++;

            // Scaling penalty: -2, then -4, then -6...
            int penalty = basePenaltyPoints * consecutiveMisses;
            CurrentScore = Mathf.Max(0, CurrentScore - penalty); // Prevents negative score
        }
        UpdateUI();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        currentCombo = 0;
        consecutiveMisses = 0;
        UpdateUI();
    }

    public void SetScore(int score)
    {
        CurrentScore = score;
        currentCombo = 0;
        consecutiveMisses = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText) scoreText.text = $"{CurrentScore}";
        if (comboText) comboText.text = currentCombo > 1 ? $"Combo: x{currentCombo}!" : "";
    }
}