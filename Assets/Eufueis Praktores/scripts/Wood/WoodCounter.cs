using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class WoodCounter : MonoBehaviour
{
    public TextMeshProUGUI woodCountText; 
    private int woodCount = 0; 
    private int requiredWood = 10; 


    public void CollectWood()
    {
        woodCount++; 
        woodCountText.text = "Wood :" + woodCount; 
        if (woodCount >= requiredWood)
        {
            woodCountText.text = "Wood Collected:" + woodCount; 
        }
    }

   
}
