using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject existingGold; 
    public int numberOfGold = 10; 
    public float fixedHeight = 0.5f; 
    private Terrain terrain;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        SpawnGold();
    }

    void SpawnGold()
    {
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;
        float terrainPosX = terrain.transform.position.x;
        float terrainPosZ = terrain.transform.position.z;

        for (int i = 0; i < numberOfGold; i++)
        {
            float randomX = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            float randomZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
            float terrainHeight = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));
            Vector3 spawnPosition = new Vector3(randomX, terrainHeight, randomZ);
            Instantiate(existingGold, spawnPosition, Quaternion.identity);
        }
    }

}
