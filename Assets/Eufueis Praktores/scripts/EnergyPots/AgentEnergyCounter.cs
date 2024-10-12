using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgentEnergyCounter : MonoBehaviour
{
    public TextMeshProUGUI potsCountText; 
    private int potsCount = 0;

    public TextMeshProUGUI clockText;  // UI για να εμφανίζεται ο χρόνος του agent
    private float countdown = 100f;    // Αρχική τιμή του χρόνου
    private float decreaseAmount = 1f; // Ποσότητα μείωσης κάθε δευτερόλεπτο
    private float potTimeValue = 20f;  // Πόσα δευτερόλεπτα προσθέτει κάθε pot

    void Start()
    {
        // Ξεκινάει το Coroutine που μειώνει τον χρόνο κάθε δευτερόλεπτο
        StartCoroutine(ReduceTimeCoroutine());
        UpdateClockDisplay();  // Ενημέρωση της αρχικής εμφάνισης του χρόνου
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

        Debug.Log("Agent's time is up!");
    }

    // Συνάρτηση που καλείται όταν ο agent συλλέγει ένα pot
    public void AgentCollectEnergy()
    {
        potsCount++; 
        potsCountText.text = "Agent Energy Pots : " + potsCount;

        // Προσθήκη χρόνου όταν συλλέγεται ένα pot
        AddTimeFromPot();

        Debug.Log("Energy Pots collected! Total pots: " + potsCount);
    }

    // Προσθέτει χρόνο στο countdown όταν συλλέγεται ένα pot
    void AddTimeFromPot()
    {
        countdown += potTimeValue;  // Προσθέτει 20 δευτερόλεπτα για κάθε pot
        UpdateClockDisplay();       // Ενημέρωση του UI για τον νέο χρόνο
    }

    // Ενημερώνει το UI στοιχείο για την εμφάνιση του χρόνου
    void UpdateClockDisplay()
    {
        clockText.text = "Agent Time Left: " + Mathf.Max(countdown, 0).ToString("F1") + "s";  // Εμφανίζει τον χρόνο με ένα δεκαδικό
    }
}
