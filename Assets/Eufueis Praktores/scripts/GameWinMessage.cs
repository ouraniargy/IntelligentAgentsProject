using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameWinManager : MonoBehaviour
{
    public TextMeshProUGUI winMessageText;

    // References to other resource scripts
    public WoodCounter woodCounter;
    public GoldCounter goldCounter;
    public AxesCounter axeCounter;

    // Required amounts for each resource
    private int requiredWood = 20;
    private int requiredGold = 10;
    private int requiredAxes = 5;

    void Start()
    {
        // Hide the win message at the start of the game
        winMessageText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check win condition in each frame
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        // Check if all resources meet their required amounts
        if (woodCounter.GetWoodCount() >= requiredWood &&
            goldCounter.GetGoldCount() >= requiredGold &&
            axeCounter.GetaxesCount() >= requiredAxes)
        {
            DisplayWinMessage();
        }
    }

    private void DisplayWinMessage()
    {
        winMessageText.gameObject.SetActive(true);
        winMessageText.text = "You Win! All resources collected!";
    }
}
