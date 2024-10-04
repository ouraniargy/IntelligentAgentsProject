using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnergyCounter : MonoBehaviour
{
    public TextMeshProUGUI potCountText;
    private int potsCount = 0;

    public void CollectEnergy()
    {
        potsCount++; 
        potCountText.text = "Energy Pots: " + potsCount; 
    }
}
