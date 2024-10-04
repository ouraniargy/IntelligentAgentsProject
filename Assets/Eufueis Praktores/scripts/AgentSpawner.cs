using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject agentPrefab; // Το prefab του agent που θέλουμε να κλωνοποιήσουμε
    public int numberOfAgents = 4; // Ο αριθμός των agents που θέλουμε να πολλαπλασιάσουμε
    public Vector3[] spawnPositions; // Θέσεις που θα εμφανιστούν οι agents

    void Start()
    {
        SpawnAgents();
    }

    void SpawnAgents()
    {
        for (int i = 0; i < numberOfAgents; i++)
        {
            Vector3 spawnPos;

            // Αν δεν έχουν οριστεί συγκεκριμένες θέσεις, δημιουργούμε τυχαίες
            if (spawnPositions.Length > i)
            {
                spawnPos = spawnPositions[i]; // Ορίζουμε συγκεκριμένες θέσεις από το array
            }
            else
            {
                spawnPos = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)); // Τυχαίες θέσεις
            }

            Instantiate(agentPrefab, spawnPos, Quaternion.identity); // Κλωνοποιούμε τον agent
        }
    }
}
