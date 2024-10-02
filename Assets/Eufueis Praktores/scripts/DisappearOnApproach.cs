using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnApproach : MonoBehaviour
{
    public Transform agent;       // Αναφορά στον πράκτορα ή τον παίκτη
    public float disappearDistance = 2.0f; // Απόσταση στην οποία το αντικείμενο θα εξαφανιστεί

    // Update is called once per frame
    void Update()
    {
        if (agent == null)
        {
            Debug.LogError("Agent transform not assigned!");
            return;
        }

        // Υπολογίζουμε την απόσταση μεταξύ του πράκτορα και του αντικειμένου
        float distance = Vector3.Distance(agent.position, transform.position);

        // Αν η απόσταση είναι μικρότερη ή ίση με την disappearDistance, το αντικείμενο εξαφανίζεται
        if (distance <= disappearDistance)
        {
            gameObject.SetActive(false);
        }
    }
}
