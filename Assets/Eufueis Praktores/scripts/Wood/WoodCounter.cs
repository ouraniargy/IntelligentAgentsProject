using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class WoodCounter : MonoBehaviour
{
    public TextMeshProUGUI woodCountText; // Αναφορά στο UI Text για το μέτρημα των ξύλων
    private int woodCount = 0; // Αρχικός αριθμός ξύλων
    public TextMeshProUGUI gameStatusText; // Αναφορά στο UI Text για την κατάσταση του παιχνιδιού (αν μαζεύτηκαν όλα τα ξύλα)
    private int requiredWood = 10; // Ο αριθμός ξύλων που χρειάζονται για το παιχνίδι


    public void CollectWood()
    {
        woodCount++; // Αύξηση του αριθμού των ξύλων
        woodCountText.text = "Wood " + woodCount; // Ενημέρωση του κειμένου
        if (woodCount >= requiredWood)
        {
            gameStatusText.text = "Wood Collected!"; 
        }
    }

   
}
