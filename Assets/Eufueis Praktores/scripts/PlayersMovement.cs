using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject targetResource;  // Current target resource
    private bool hasLoggedNoResources = false; // Flag to log no resources message
    private Animator animator; // Αναφορά στον Animator
    public Transform[] waypoints; // Σημεία προορισμού (Waypoints)
    public float speed = 0.5f;       // Walking speed
    private int currentWaypointIndex = 0; // Τρέχον σημείο προορισμού

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>(); // Παίρνουμε τον Animator
        agent.speed = speed; // Ορισμός ταχύτητας στον NavMeshAgent


        MoveToNearestResource();
    }

    void MoveToNearestResource()
    {
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

        if (targetResource != null)
        {
            agent.SetDestination(targetResource.transform.position);
        }

        if (waypoints.Length == 0) return;

        agent.destination = waypoints[currentWaypointIndex].position;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    private string task;

    public void AssignTask(string taskToCollect)
    {
        task = taskToCollect;
        Debug.Log($"{gameObject.name} assigned to collect {task}");
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

    public AudioClip collectSound;


    private void CollectWood()
    {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            FindObjectOfType<WoodCounter>().CollectWood();
            Destroy(gameObject);
    }

    private void CollectAxes()
    {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            FindObjectOfType<AxesCounter>().CollectAxes();
            Destroy(gameObject);
    }

    private void CollectResource()
    {
        // If the task is "Wood", collect wood
        if (task == "Wood" && targetResource.CompareTag("Wood"))
        {
            CollectWood();
        }
        // If the task is "Axe", collect axes
        else if (task == "Axe" && targetResource.CompareTag("Axe"))
        {
            CollectAxes();
        }

        // Destroy the resource after collection
        Destroy(targetResource);
        targetResource = null;

        // Move to the next nearest resource
        MoveToNearestResource();
    }
}