using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgentWoodCounter : MonoBehaviour
{
    public TextMeshProUGUI woodCountText;
    private int woodCount = 0;
    private int requiredWood = 10;


    public void AgentCollectWood()
    {
        woodCount++;
        woodCountText.text = "Wood :" + woodCount;
        if (woodCount >= requiredWood)
        {
            woodCountText.text = "Wood Collected:" + woodCount;
        }
    }
}
