using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject targetResource;  // Current target resource
    private bool hasLoggedNoResources = false; // Flag to log no resources message
    private Animator animator; // Αναφορά στον Animator
    public Transform[] waypoints; // Σημεία προορισμού (Waypoints)
    public float speed = 0.5f;       // Walking speed
    private int currentWaypointIndex = 0; // Τρέχον σημείο προορισμού

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Παίρνουμε τον Animator
        agent.speed = speed; // Ορισμός ταχύτητας στον NavMeshAgent


        MoveToNearestResource();
    }

    void MoveToNearestResource()
    {
        // Find all resource objects with the tag "Resource"
        GameObject[] resources = GameObject.FindGameObjectsWithTag("Resource");

        if (resources.Length == 0)
        {
            if (!hasLoggedNoResources)
            {
                Debug.Log("No more resources in the scene!");
                hasLoggedNoResources = true; // Log only once
            }
            return;
        }
        else
        {
            hasLoggedNoResources = false; // Reset the flag if resources are found
        }

        // Find the closest resource object
        targetResource = null;
        float shortestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject resource in resources)
        {
            float distanceToResource = Vector3.Distance(currentPosition, resource.transform.position);
            if (distanceToResource < shortestDistance)
            {
                shortestDistance = distanceToResource;
                targetResource = resource;
            }
        }

        // If there's a resource, set the agent's destination
        if (targetResource != null)
        {
            agent.SetDestination(targetResource.transform.position);
        }

        if (waypoints.Length == 0) return;

        // Ορισμός νέου προορισμού
        agent.destination = waypoints[currentWaypointIndex].position;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Κυκλική προορισμός
    }

    void Update()
    {
        // If the agent has reached its destination and is not waiting for a path
        if (targetResource != null && agent.remainingDistance < 0.5f && !agent.pathPending)
        {
            CollectResource();
        }
        else if (targetResource == null)
        {
            // If no target resource, find the next closest resource
            MoveToNearestResource();
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        animator.SetBool("IsWalking", true);

    }

        private void CollectResource()
    {
        // Get the DisappearOnApproach script from the resource and assign the agent
        DisappearOnApproach disappearScript = targetResource.GetComponent<DisappearOnApproach>();
        if (disappearScript != null)
        {
            disappearScript.agent = this.transform; // Assign the agent
        }

        // Collect the resource (it disappears)
        Destroy(targetResource);
        targetResource = null; // Clear the target resource

        // Immediately find the next closest resource
        MoveToNearestResource(); // Starts moving to the next resource
    }
}
