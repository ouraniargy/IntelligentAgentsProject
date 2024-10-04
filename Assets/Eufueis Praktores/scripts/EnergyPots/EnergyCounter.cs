using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnergyCounter : MonoBehaviour
{
    public TextMeshProUGUI potCountText;
    private int potsCount = 0; // Αρχικός αριθμός σπαθιων

    public void CollectEnergy()
    {
        potsCount++; // Αύξηση του αριθμού των σπαθιων
        potCountText.text = "Energy Pots: " + potsCount; // Ενημέρωση του κειμένου
    }
}
