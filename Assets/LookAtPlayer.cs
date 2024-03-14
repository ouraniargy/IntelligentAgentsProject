using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform playerCamera;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    private void Update()
    {
        // Make the object look at the player's camera
        transform.LookAt(playerCamera);

        // Calculate the distance between the object and the player's camera
        float distanceToPlayer = Vector3.Distance(transform.position, playerCamera.position);

        // Move the object towards the player's camera only if it's within a certain distance
        if (distanceToPlayer < 10f) // Adjust this distance as needed
        {
            // Calculate the movement direction
            Vector3 moveDirection = playerCamera.position - transform.position;

            // Normalize the direction to have consistent movement speed
            moveDirection.Normalize();

            // Move the object towards the player's camera
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
