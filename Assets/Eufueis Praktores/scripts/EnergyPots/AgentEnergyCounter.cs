using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgentEnergyCounter : MonoBehaviour
{
    public TextMeshProUGUI potsCountText; 
    private int potsCount = 0;

    public void AgentCollectEnergy()
    {
        potsCount++; 
        potsCountText.text = "Agent Energy Pots : " + potsCount; 
        Debug.Log("Energy Pots collected! Total pots: " + potsCount);
    }

}
