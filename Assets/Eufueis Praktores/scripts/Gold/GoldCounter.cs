using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    public TextMeshProUGUI goldCountText;
    private int goldCount = 0;
    private int requiredGold = 100;
    public GameObject winMessagePanel; // Αναφορά στο UI Panel για το μήνυμα νίκης
    public void CollectGold()
    {
        goldCount += 10;
        goldCountText.text = "Coins: " + goldCount;
        if (goldCount >= requiredGold)
        {
            goldCountText.text = "Gold Collected:" + goldCount;
        }
    }

    public int GetGoldCount()
    {
        return goldCount;
    }

}
