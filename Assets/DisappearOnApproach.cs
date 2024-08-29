using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnApproach : MonoBehaviour
{


    public Transform hint; // Αν το χρησιμοποιείς, βεβαιώσου ότι είναι σωστά ρυθμισμένο.

    private void Start()
    {
        // Επιβεβαίωση ότι το Collider είναι σωστά ρυθμισμένο
        if (GetComponent<Collider>() == null)
        {
            Debug.LogError("Collider not found!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Έλεγχος αν το αντικείμενο που μπήκε στο trigger είναι ο παίκτης
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            // Εξαφάνιση του αντικειμένου
            gameObject.SetActive(false);
        }
    }
}
