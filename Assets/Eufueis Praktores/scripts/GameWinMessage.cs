using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWinManager : MonoBehaviour
{
    public TextMeshProUGUI winMessageText;
    public GameObject winMessagePanel; // Αναφορά στο UI Panel για το μήνυμα νίκης

    // References to player's resource scripts
    public WoodCounter woodCounter;
    public GoldCounter goldCounter;
    public AxesCounter axesCounter;

    // References to agent's resource scripts
    public AgentWoodCounter AgentWoodCounter;
    public AgentGoldCounter AgentGoldCounter;
    public AgentAxesCounter AgentAxesCounter;

    // Required amounts for each resource
    private int requiredWood = 20;
    private int requiredGold = 100;
    private int requiredAxes = 20;

    private bool hasGameEnded = false;

    void Start()
    {
        winMessageText.gameObject.SetActive(false);
        winMessagePanel.SetActive(false);
    }

    void Update()
    {
        if (!hasGameEnded) // Έλεγχος μόνο αν το παιχνίδι δεν έχει ήδη τελειώσει
        {
            CheckWinCondition();
        }
    }

    private void CheckWinCondition()
    {
        Debug.Log("Player Wood: " + woodCounter.GetWoodCount() + " / Required: " + requiredWood);
        Debug.Log("Player Gold: " + goldCounter.GetGoldCount() + " / Required: " + requiredGold);
        Debug.Log("Player Axes: " + axesCounter.GetAxesCount() + " / Required: " + requiredAxes);

        Debug.Log("Agent Wood: " + AgentWoodCounter.GetWoodCount() + " / Required: " + requiredWood);
        Debug.Log("Agent Gold: " + AgentGoldCounter.GetGoldCount() + " / Required: " + requiredGold);
        Debug.Log("Agent Axes: " + AgentAxesCounter.GetAxesCount() + " / Required: " + requiredAxes);

        Debug.Log("Checking win condition...");

        // Έλεγχος αν ο παίκτης έχει κερδίσει
        bool playerHasWon = woodCounter.GetWoodCount() >= requiredWood &&
                            goldCounter.GetGoldCount() >= requiredGold &&
                            axesCounter.GetAxesCount() >= requiredAxes;

        // Έλεγχος αν ο agent έχει κερδίσει
        bool agentHasWon = AgentWoodCounter.GetWoodCount() >= requiredWood &&
                           AgentGoldCounter.GetGoldCount() >= requiredGold &&
                           AgentAxesCounter.GetAxesCount() >= requiredAxes;

        if (playerHasWon && agentHasWon)
        {
            Debug.Log("It's a draw!");
            DisplayDrawMessage();
        }
        else if (playerHasWon)
        {
            Debug.Log("Player won!");
            DisplayWinMessage();
        }
        else if (agentHasWon)
        {
            Debug.Log("Agent won!");
            DisplayLoseMessage();

        }
    }

    private void DisplayWinMessage()
    {
        hasGameEnded = true; // Το παιχνίδι τελείωσε
        winMessagePanel.SetActive(true);
        winMessageText.gameObject.SetActive(true);
        winMessageText.text = "You Win! All resources collected!";
    }

    private void DisplayLoseMessage()
    {
        hasGameEnded = true; // Το παιχνίδι τελείωσε
        winMessagePanel.SetActive(true);
        winMessageText.gameObject.SetActive(true);
        winMessageText.text = "You Lose! The agent collected all resources first!";
    }

    private void DisplayDrawMessage()
    {
        hasGameEnded = true; // Το παιχνίδι τελείωσε
        winMessagePanel.SetActive(true);
        winMessageText.gameObject.SetActive(true);
        winMessageText.text = "It's a draw! Both you and the agent collected all resources!";
    }
}
