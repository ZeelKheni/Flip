using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gamePanel;

    [Header("Managers")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SaveManager saveManager;

    [Header("UI Buttons")]
    [SerializeField] private Button continueButton;

    private void Start()
    {
      
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);

     
        if (continueButton != null)
        {
            continueButton.interactable = saveManager.HasSaveData();
        }
    }



    public void SelectGrid2x2() => SetupGame(2, 2);
    public void SelectGrid2x3() => SetupGame(2, 3);
    public void SelectGrid5x6() => SetupGame(5, 6);

    public void ContinueSavedGame()
    {
        if (saveManager.HasSaveData())
        {
            SwitchToGameUI();
            gameManager.LoadGame();
        }
    }

    private void SetupGame(int rows, int cols)
    {
        SwitchToGameUI();
        gameManager.StartNewGame(rows, cols);
    }

    private void SwitchToGameUI()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}