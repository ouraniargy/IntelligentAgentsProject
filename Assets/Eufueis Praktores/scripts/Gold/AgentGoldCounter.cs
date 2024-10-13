using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgentGoldCounter : MonoBehaviour
{
    public TextMeshProUGUI goldCountText;
    private int goldCount = 0;

    public void AgentCollectGold()
    {
        goldCount = goldCount + 10;
        goldCountText.text = "Coins: " + goldCount;
        Debug.Log("10 Coins collected! Total Coins: " + goldCount);
    }

    public int GetGoldCount()
    {
        return goldCount;
    }
}
