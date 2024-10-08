﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public GameObject existingAgent; 
    public int numberOfAgents = 4; 
    public float fixedHeight = 1.0f;
    private Terrain terrain;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        SpawnAgents();
    }

    void SpawnAgents()
    {
        // Λαμβάνουμε το πλάτος και το μήκος του terrain χωρίς το localScale
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;
        float terrainPosX = terrain.transform.position.x;
        float terrainPosZ = terrain.transform.position.z;

        for (int i = 0; i < numberOfAgents; i++)
        {
            // Περιορίζουμε τις τυχαίες συντεταγμένες στις διαστάσεις του terrain
            float randomX = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            float randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);

            // Υπολογισμός ύψους στο terrain για να τοποθετήσουμε σωστά το αντικείμενο
            float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));

            // Δημιουργία της θέσης κλωνοποίησης
            Vector3 spawnPosition = new Vector3(randomX, terrainHeight + 0.8f, randomZ);

            // Κλωνοποίηση του αντικειμένου
            Instantiate(existingAgent, spawnPosition, Quaternion.identity);
        }
    }


}
