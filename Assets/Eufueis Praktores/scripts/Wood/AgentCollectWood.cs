﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCollectWood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent")) // Έλεγχος αν ο παίκτης πλησιάζει
        {
            Debug.Log("Agent collected wood.");
            FindObjectOfType<AgentWoodCounter>().AgentCollectWood(); // Ενημέρωση του μετρητή
            Destroy(gameObject); // Καταστροφή του ξύλου
        }
        if (other.CompareTag("PlayerTeam"))
        {
            Debug.Log("Team of Player collected a piece of wood.");
            FindObjectOfType<WoodCounter>().CollectWood();
            Destroy(gameObject);
        }
    }
}
