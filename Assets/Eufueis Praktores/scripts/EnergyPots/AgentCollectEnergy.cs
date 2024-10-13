using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCollectEnergy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent")) 
        {
            Debug.Log("Agent collected an energy pot.");
            FindObjectOfType<AgentEnergyCounter>().AgentCollectEnergy(); 
            Destroy(gameObject); 
        }
        if (other.CompareTag("PlayerTeam"))
        {
            Debug.Log("Team of Player collected an energy pot.");
            FindObjectOfType<EnergyCounter>().CollectEnergy();
            Destroy(gameObject);
        }
    }

}
