using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAxes : MonoBehaviour
{
    public AudioClip collectSound; // Αναφορά στο AudioClip για τον ήχο συλλογής

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Έλεγχος αν ο παίκτης πλησιάζει
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position); // Παίζει ο ήχος
            FindObjectOfType<AxesCounter>().CollectAxes(); // Ενημέρωση του μετρητή
            Destroy(gameObject); // Καταστροφή του ξύλου
        }
    }
}
