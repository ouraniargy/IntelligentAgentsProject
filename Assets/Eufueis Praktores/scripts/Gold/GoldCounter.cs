using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    public TextMeshProUGUI goldCountText;
    private int goldCount = 0;
    public WoodCounter woodCounter; // Reference to WoodCounter script
    public AxesCounter axesCounter;
    public GameObject winMessagePanel; // Αναφορά στο UI Panel για το μήνυμα νίκης
    public void CollectGold()
    {
        goldCount += 10;
        goldCountText.text = "Coins: " + goldCount;
        CheckForGamePause();
    }

    public int GetGoldCount()
    {
        return goldCount;
    }

    private void CheckForGamePause()
    {
        if (goldCount >= 100 && woodCounter.GetWoodCount() >= 20 ) //&& axesCounter.GetaxesCount() >= 10
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0; // Pauses the game
        winMessagePanel.SetActive(true);
    }
}
