using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageDisplay : MonoBehaviour
{
    public GameObject messageDisplayObject; //can be text or 3d object

    private void OnTriggerEnter(Collider other)
    {
        //filter only player
        if (other.CompareTag("Player"))
        {
            messageDisplayObject.SetActive(true);
        }
    }
}
