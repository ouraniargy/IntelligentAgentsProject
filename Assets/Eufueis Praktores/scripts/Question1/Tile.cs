using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    // Δείχνει τι πόρος υπάρχει στο πλακίδιο
    public bool hasWood = false;
    public bool hasShield = false;
    public GameObject resourceObject; // Το αντικείμενο που αντιστοιχεί στον πόρο

    // Δημιουργούμε ένα κενό πλακίδιο (χωρίς πόρο)
    public Tile()
    {
        hasWood = false;
        hasShield = false;
        resourceObject = null;
    }

    // Ιδιότητα για να ελέγξουμε αν το πλακίδιο είναι κενό
    public bool isEmpty
    {
        get
        {
            return !hasWood && !hasShield && resourceObject == null;
        }
    }

    // Αναβάθμιση του πλακιδίου με ξύλο
    public void SetWood(GameObject woodPrefab)
    {
        hasWood = true;
        resourceObject = woodPrefab;
    }

    // Αναβάθμιση του πλακιδίου με ασπίδα
    public void SetShield(GameObject shieldPrefab)
    {
        hasShield = true;
        resourceObject = shieldPrefab;
    }
}



