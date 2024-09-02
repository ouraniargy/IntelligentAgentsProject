﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class WoodCounter : MonoBehaviour
{
    public TextMeshProUGUI woodCountText; // Αναφορά στο UI Text για το μέτρημα των ξύλων
    private int woodCount = 0; // Αρχικός αριθμός ξύλων

    // Κλήση όταν ο player συλλέγει ένα ξύλο
    public void CollectWood()
    {
        woodCount++; // Αύξηση του αριθμού των ξύλων
        woodCountText.text = "Wood Collected: " + woodCount; // Ενημέρωση του κειμένου
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
