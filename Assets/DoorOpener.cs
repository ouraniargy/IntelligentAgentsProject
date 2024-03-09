using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject door; // Reference to the door object
    private bool doorOpen = false;
    public float doorOpenPosition = 1f; // Adjust the desired x-position for opening the door
    public string playerTag = "Player"; // Set the tag for the player

    private void ToggleDoorState()
    {
        if (!doorOpen)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        door.transform.Rotate(Vector3.up, 90f); // Rotate around the Y-axis by 90 degrees
        doorOpen = true;
    }
   

    private bool IsPlayerAtDoorPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        float playerXPosition = player.transform.position.x;
        float doorXPosition = door.transform.position.x;
        float allowedRange = 2f; // Set the desired range

        return Mathf.Abs(playerXPosition - doorXPosition) <= allowedRange;


        return false;
    }


    private void Update()

    {
        if (IsPlayerAtDoorPosition())
        {
            ToggleDoorState();
        }
    }

    void Start()
    {
       
    }


}
