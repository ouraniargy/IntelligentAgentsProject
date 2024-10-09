using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    public GameObject existingWood;  // Το prefab του αντικειμένου ξύλου
    public int numberOfWoods = 10;   // Πόσα ξύλα θα κλωνοποιηθούν
    private Terrain terrain;         // Αναφορά στο terrain

    void Start()
    {
        // Βρίσκουμε το ενεργό terrain
        terrain = Terrain.activeTerrain;

        if (terrain == null)
        {
            Debug.LogError("Δεν βρέθηκε ενεργό Terrain στη σκηνή!");
            return; // Σταματάμε την εκτέλεση αν δεν υπάρχει terrain
        }

        // Καλούμε τη μέθοδο για να κλωνοποιήσουμε ξύλα
        SpawnWoods();
    }

    void SpawnWoods()
    {
        // Παίρνουμε τις διαστάσεις και τη θέση του terrain
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;
        float terrainPosX = terrain.transform.position.x;
        float terrainPosZ = terrain.transform.position.z;

        // Κλωνοποιούμε ξύλα σε τυχαίες θέσεις
        for (int i = 0; i < numberOfWoods; i++)
        {
            // Επιλέγουμε τυχαία X και Z συντεταγμένες εντός των ορίων του terrain
            float randomX = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            float randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);

            // Υπολογίζουμε το ύψος του terrain στη θέση αυτή και προσθέτουμε την αρχική θέση του terrain
            float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0, randomZ)) + terrain.transform.position.y;

            // Δημιουργία της θέσης κλωνοποίησης
            Vector3 spawnPosition = new Vector3(randomX, terrainHeight, randomZ);

            // Κλωνοποιούμε το αντικείμενο ξύλου
            Instantiate(existingWood, spawnPosition, Quaternion.identity);
        }
    }
}
