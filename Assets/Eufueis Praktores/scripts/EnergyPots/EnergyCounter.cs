using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyCounter : MonoBehaviour
{
    public TextMeshProUGUI potCountText;
    private int potsCount = 0;

    public TextMeshProUGUI clockText;  // UI στοιχείο για να εμφανίζεται το ρολόι
    private float countdown = 100f;    // Η μεταβλητή που θέλουμε να μειώνεται
    private float decreaseAmount = 1f; // Η ποσότητα μείωσης ανά δευτερόλεπτο
    private float potTimeValue = 20f;   // Ο χρόνος που προσθέτει κάθε pot

    void Start()
    {
        // Ξεκινάει το Coroutine που μειώνει το χρόνο ανά δευτερόλεπτο
        StartCoroutine(ReduceTimeCoroutine());
        UpdateClockDisplay();  // Αρχική εμφάνιση του ρολογιού
    }

    // Coroutine που μειώνει τον χρόνο κάθε δευτερόλεπτο
    IEnumerator ReduceTimeCoroutine()
    {
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1f);  // Περιμένει 1 δευτερόλεπτο
            countdown -= decreaseAmount;
            UpdateClockDisplay();
        }

        Debug.Log("Time's up!");
    }

    // Ενημερώνει το UI στοιχείο για την εμφάνιση του χρόνου
    void UpdateClockDisplay()
    {
        clockText.text = "Time Left: " + Mathf.Max(countdown, 0).ToString("F1") + "s";  // Εμφανίζει τον χρόνο με ένα δεκαδικό
    }

    // Συνάρτηση για να συλλέγει το pot και να προσθέτει χρόνο
    public void CollectEnergy()
    {
        potsCount++; 
        potCountText.text = "Energy Pots: " + potsCount; 

        // Προσθήκη χρόνου κάθε φορά που συλλέγεται ένα pot
        AddTimeFromPot();
    }

    // Προσθέτει χρόνο στο countdown όταν συλλέγεται ένα pot
    void AddTimeFromPot()
    {
        countdown += potTimeValue;  // Προσθέτει τον χρόνο που δίνει το pot
        UpdateClockDisplay();       // Ενημέρωση της εμφάνισης του χρόνου
    }
}
