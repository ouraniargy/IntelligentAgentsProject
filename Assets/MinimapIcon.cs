using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIcon : MonoBehaviour
{
    public Transform player; // Αναφορά στον παίκτη
    private Vector3 offset; // Χρησιμοποιείται για να κρατήσει τον δείκτη στην ίδια θέση σε σχέση με τον παίκτη

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.position + offset;
        transform.position = newPosition;
    }
}
