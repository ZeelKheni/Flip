using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int rows;
    public int cols;
    public int score;
    public List<int> cardIds = new List<int>();
    public List<bool> cardFlippedStates = new List<bool>();
    public List<bool> cardMatchedStates = new List<bool>();
}

public class SaveManager : MonoBehaviour
{
    private const string SAVE_KEY = "CardMatchSaveState";

    public void SaveGame(List<Card> cards, int rows, int cols, int score)
    {
        SaveData data = new SaveData { rows = rows, cols = cols, score = score };

        foreach (Card c in cards)
        {
            data.cardIds.Add(c.CardID);
            data.cardFlippedStates.Add(c.IsFlipped);
            data.cardMatchedStates.Add(c.IsMatched);
        }

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
    }

    public SaveData LoadGameData()
    {
        string json = PlayerPrefs.GetString(SAVE_KEY);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public bool HasSaveData()
    {
        return PlayerPrefs.HasKey(SAVE_KEY);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteKey(SAVE_KEY);
    }
}