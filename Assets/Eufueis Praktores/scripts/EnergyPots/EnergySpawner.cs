using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpawner : MonoBehaviour
{
    public GameObject existingPot; 
    public int numberOfPots = 10; 
    public float fixedHeight = 1.5f;
    private Terrain terrain;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        SpawnPots();
    }

    void SpawnPots()
    {
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;
        float terrainPosX = terrain.transform.position.x;
        float terrainPosZ = terrain.transform.position.z;

        for (int i = 0; i < numberOfPots; i++)
        {
            // Περιορίζουμε τις τυχαίες συντεταγμένες στις διαστάσεις του terrain
            float randomX = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            float randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);

            // Υπολογισμός ύψους στο terrain για να τοποθετήσουμε σωστά το αντικείμενο
            float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));

            // Δημιουργία της θέσης κλωνοποίησης
            Vector3 spawnPosition = new Vector3(randomX, terrainHeight, randomZ);

            // Κλωνοποίηση του αντικειμένου
            Instantiate(existingPot, spawnPosition, Quaternion.identity);
        }
    }

}
