using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    public TextMeshProUGUI goldCountText; 
    private int goldCount = 0; 

    public void CollectGold()
    {
        goldCount = goldCount + 10;
        goldCountText.text = "Coins: " + goldCount; 
    }
}
