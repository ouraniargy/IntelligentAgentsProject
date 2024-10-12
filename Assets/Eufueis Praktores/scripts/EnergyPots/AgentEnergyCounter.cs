using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgentEnergyCounter : MonoBehaviour
{
    public TextMeshProUGUI potsCountText; 
    private int potsCount = 0;

    public TextMeshProUGUI clockText;  
    private float countdown = 100f;   
    private float decreaseAmount = 1f; 
    private float potTimeValue = 20f;  

    void Start()
    {
        StartCoroutine(ReduceTimeCoroutine());
        UpdateClockDisplay();  
    }

    IEnumerator ReduceTimeCoroutine()
    {
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1f);  
            countdown -= decreaseAmount;
            UpdateClockDisplay();
        }

        Debug.Log("Agent's time is up!");
    }

    public void AgentCollectEnergy()
    {
        potsCount++; 
        potsCountText.text = "Agent Energy Pots : " + potsCount;
        AddTimeFromPot();
        Debug.Log("Energy Pots collected! Total pots: " + potsCount);
    }

    void AddTimeFromPot()
    {
        countdown += potTimeValue;
        UpdateClockDisplay();       
    }

    void UpdateClockDisplay()
    {
        clockText.text = "Agent Time Left: " + Mathf.Max(countdown, 0).ToString("F1") + "s"; 
    }

    // Συνάρτηση που καλείται όταν ο παίκτης αγοράζει pots από τον agent
    public void TransferPotsToPlayer(int potsToTransfer)
    {
        if (potsCount >= potsToTransfer)
        {
            potsCount -= potsToTransfer;
            potsCountText.text = "Agent Energy Pots: " + potsCount;
        }
        else
        {
            Debug.Log("Agent doesn't have enough pots for the trade!");
        }
    }

    // Επιστρέφει τον αριθμό των pots του agent
    public int GetPotsCount()
    {
        return potsCount;
    }
}
