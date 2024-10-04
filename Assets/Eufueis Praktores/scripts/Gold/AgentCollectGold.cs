using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCollectGold : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent")) 
        {
            Debug.Log("Agent collected 10 coins.");
            FindObjectOfType<AgentGoldCounter>().AgentCollectGold(); 
            Destroy(gameObject); 
        }
    }
}
