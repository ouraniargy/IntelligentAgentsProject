using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
public GameObject door; // Reference to the door object
    private bool doorOpen = false;
    // Start is called before the first frame update
   
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Change the tag as needed
        {
            if (!doorOpen)
            {
                OpenDoor();
            }
           
        }
    }

    private void OpenDoor()
    {
        door.transform.Rotate(0, 90, 0); // Adjust rotation as needed
        doorOpen = true;
    }
    private void CloseDoor()
    {
        door.transform.Rotate(0, -90, 0); // Adjust rotation as needed
        doorOpen = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
