using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VirtualClock : MonoBehaviour
{
    public TextMeshProUGUI clockText;  // UI στοιχείο για να εμφανίζεται το ρολόι
    private float countdown = 100f;    // Η μεταβλητή που θέλουμε να μειώνεται
    private float decreaseAmount = 10f; // Η ποσότητα μείωσης κάθε 5 δευτερόλεπτα

    void Start()
    {
        // Ξεκινάει το timer που μειώνει το countdown ανά 5 δευτερόλεπτα
        InvokeRepeating("ReduceTime", 0f, 5f); 
        UpdateClockDisplay();  // Αρχική εμφάνιση του ρολογιού
    }

    // Η συνάρτηση που θα καλείται κάθε 5 δευτερόλεπτα
    void ReduceTime()
    {
        if (countdown > 0)
        {
            countdown -= decreaseAmount;
            UpdateClockDisplay();
        }
        else
        {
            CancelInvoke("ReduceTime");  // Σταματάει όταν ο χρόνος φτάσει στο 0
            Debug.Log("Time's up!");
        }
    }

    // Ενημερώνει το UI στοιχείο για την εμφάνιση του χρόνου
    void UpdateClockDisplay()
    {
        clockText.text = "Time Left: " + Mathf.Max(countdown, 0).ToString("F1") + "s";  // Εμφανίζει τον χρόνο με ένα δεκαδικό
    }
}
