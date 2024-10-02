using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCollectAxes : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent")) // Έλεγχος αν ο παίκτης πλησιάζει
        {
            Debug.Log("Agent collected an axe.");
            FindObjectOfType<AgentAxesCounter>().AgentCollectAxes(); // Ενημέρωση του μετρητή
            Destroy(gameObject); // Καταστροφή του ξύλου
        }
    }
}
