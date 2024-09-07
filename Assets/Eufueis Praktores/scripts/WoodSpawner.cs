using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    public GameObject existingWood; // Το ήδη υπάρχων αντικείμενο ξύλου που έχεις δημιουργήσει
    public int numberOfWoods = 10; // Πόσα ξύλα θα κλωνοποιηθούν
    public float fixedHeight = 1.0f; // Σταθερό ύψος εμφάνισης
    private Terrain terrain;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        SpawnWoods();
    }

    void SpawnWoods()
    {
        float terrainWidth = terrain.terrainData.size.x * terrain.transform.localScale.x;
        float terrainLength = terrain.terrainData.size.z * terrain.transform.localScale.z;
        float terrainPosX = terrain.transform.position.x;
        float terrainPosZ = terrain.transform.position.z;

        for (int i = 0; i < numberOfWoods; i++)
        {
            float randomX = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            float randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
            float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));

            Vector3 spawnPosition = new Vector3(randomX, terrainHeight, randomZ);

            // Κλωνοποίηση του ήδη υπάρχοντος αντικειμένου αντί να δημιουργήσεις νέο prefab
            Instantiate(existingWood, spawnPosition, Quaternion.identity);
        }
    }
}
