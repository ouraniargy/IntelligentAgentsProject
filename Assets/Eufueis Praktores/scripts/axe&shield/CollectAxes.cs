using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAxes : MonoBehaviour
{
    public AudioClip collectSound; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position); 
            FindObjectOfType<AxesCounter>().CollectAxes(); 
            Destroy(gameObject); 
        }
    }
}
