using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Για τη χρήση του UI

public class EnergyCounter : MonoBehaviour
{
    public TextMeshProUGUI potCountText;
    private int potsCount = 0;

    public TextMeshProUGUI clockText;  // UI στοιχείο για να εμφανίζεται το ρολόι
    private float countdown = 100f;    // Η μεταβλητή που θέλουμε να μειώνεται
    private float decreaseAmount = 1f; // Η ποσότητα μείωσης ανά δευτερόλεπτο
    private float potTimeValue = 20f;  // Ο χρόνος που προσθέτει κάθε pot

    public int coins = 100;  // Νομίσματα του παίκτη
    public TextMeshProUGUI coinText;  // Εμφάνιση νομισμάτων

    public GameObject tradePanel;  // Παράθυρο συναλλαγής
    public AgentEnergyCounter agentCounter;  // Αναφορά στον agent

    void Start()
    {
        StartCoroutine(ReduceTimeCoroutine());
        UpdateClockDisplay();  
        UpdateCoinDisplay();   // Αρχική εμφάνιση των νομισμάτων
    }

    IEnumerator ReduceTimeCoroutine()
    {
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1f); 
            countdown -= decreaseAmount;
            UpdateClockDisplay();

            // Έλεγχος για το εάν μπορεί να ξεκινήσει η συναλλαγή
            CheckForTrade();
        }

        Debug.Log("Time's up!");
    }

    void UpdateClockDisplay()
    {
        clockText.text = "Time Left: " + Mathf.Max(countdown, 0).ToString("F1") + "s";
    }

    public void CollectEnergy()
    {
        potsCount++; 
        potCountText.text = "Energy Pots: " + potsCount; 
        AddTimeFromPot();
    }

    void AddTimeFromPot()
    {
        countdown += potTimeValue; 
        UpdateClockDisplay();
    }

    // Ενημέρωση της εμφάνισης των νομισμάτων
    void UpdateCoinDisplay()
    {
        coinText.text = "Coins: " + coins;
    }

    // Συνάρτηση που ελέγχει αν πληρούνται οι συνθήκες για την έναρξη συναλλαγής
    void CheckForTrade()
    {
        if (potsCount > 10 || agentCounter.GetPotsCount() >10)
        {
            // Εμφάνιση του παράθυρου συναλλαγής
           // tradePanel.SetActive(true);
        }
    }

    // Συνάρτηση που καλείται όταν ο παίκτης επιλέγει "Ναι" στο παράθυρο συναλλαγής
    public void AcceptTrade()
    {
        if (coins >= 20)
        {
            potsCount += 50;
            agentCounter.TransferPotsToPlayer(50);  // Ο agent δίνει pots στον παίκτη
            coins -= 20;
            UpdateCoinDisplay();  // Ενημέρωση νομισμάτων
            potCountText.text = "Energy Pots: " + potsCount;  // Ενημέρωση pots
            tradePanel.SetActive(false);  // Κλείσιμο του παράθυρου συναλλαγής
        }
        else
        {
            Debug.Log("Not enough coins to complete the trade!");
        }
    }

    // Συνάρτηση που καλείται όταν ο παίκτης επιλέγει "Όχι" στο παράθυρο συναλλαγής
    public void DeclineTrade()
    {
        tradePanel.SetActive(false);  // Κλείσιμο του παράθυρου συναλλαγής
    }
}
