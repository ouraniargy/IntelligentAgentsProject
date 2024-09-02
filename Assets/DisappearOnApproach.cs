using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnApproach : MonoBehaviour
{
    public Transform player;       // Αναφορά στον παίκτη
    public float disappearDistance = 2.0f; // Απόσταση στην οποία το αντικείμενο θα εξαφανιστεί

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player transform not assigned!");
            return;
        }

        // Υπολογίζουμε την απόσταση μεταξύ του παίκτη και του αντικειμένου
        float distance = Vector3.Distance(player.position, transform.position);

        // Αν η απόσταση είναι μικρότερη ή ίση με την disappearDistance, το αντικείμενο εξαφανίζεται
        if (distance <= disappearDistance)
        {
            gameObject.SetActive(false);
        }
    }
}
