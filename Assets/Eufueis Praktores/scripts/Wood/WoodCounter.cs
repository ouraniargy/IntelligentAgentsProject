using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodCounter : MonoBehaviour
{
    public TextMeshProUGUI woodCountText;
    private int woodCount = 0;
    private int requiredWood = 20; // Update to 20

    public void CollectWood()
    {
        woodCount++;
        woodCountText.text = "Wood: " + woodCount;
        if (woodCount >= requiredWood)
        {
            woodCountText.text = "Wood Collected: " + woodCount;
        }
    }

    public int GetWoodCount()
    {
        return woodCount; // To allow GoldCounter to access wood count
    }
}
