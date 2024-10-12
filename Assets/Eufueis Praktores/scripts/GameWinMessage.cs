using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWinManager : MonoBehaviour
{
    public TextMeshProUGUI winMessageText;
    public GameObject winMessagePanel; // Αναφορά στο UI Panel για το μήνυμα νίκης

    // References to other resource scripts
    public WoodCounter woodCounter;
    public GoldCounter goldCounter;
    public AxesCounter axesCounter;

    // Required amounts for each resource
    private int requiredWood = 20;
    private int requiredGold = 100;
    private int requiredAxes = 0;

    void Start()
    {
        winMessageText.gameObject.SetActive(false);
        winMessagePanel.SetActive(false);
    }

    void Update()
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (woodCounter.GetWoodCount() >= requiredWood &&
            goldCounter.GetGoldCount() >= requiredGold &&
            axesCounter.GetAxesCount() >= requiredAxes)
        {
            DisplayWinMessage();
        }
    }

    private void DisplayWinMessage()
    {
        winMessagePanel.SetActive(true);
        winMessageText.gameObject.SetActive(true);
        winMessageText.text = "You Win! All resources collected!";
    }
}
