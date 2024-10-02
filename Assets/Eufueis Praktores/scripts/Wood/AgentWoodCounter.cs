using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgentWoodCounter : MonoBehaviour
{
    public TextMeshProUGUI woodCountText; 
    private int woodCount = 0; 

    public void AgentCollectWood()
    {
        woodCount++; 
        woodCountText.text = "Agent Wood : " + woodCount; 
        Debug.Log("Wood collected! Total Wood: " + woodCount);
    }
}
