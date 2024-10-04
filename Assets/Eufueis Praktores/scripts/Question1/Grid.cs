using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public int N = 100; // Πλάτος του κόσμου
    public int M = 100; // Ύψος του κόσμου
    public GameObject woodPrefab; // Prefab για ξύλο
    public GameObject shieldPrefab; // Prefab για ασπίδα
    public int numberOfWoods = 10; // Πόσα ξύλα
    public float resourceProbability = 0.1f; // Πιθανότητα εμφάνισης πόρου
    public int numberOfShields = 10; // Πόσες ασπίδες
    public GameObject villagePrefab; // Prefab για χωριό
    private Terrain terrain; // Αναφορά στο Terrain

    void Start()
    {
        terrain = Terrain.activeTerrain; // Λάβετε την ενεργή επιφάνεια

        // Κλήση των μεθόδων για να τοποθετηθούν τα χωριά και οι πόροι
        PlaceVillages();
        GenerateResources();
    }

    // Τοποθέτηση χωριών
    void PlaceVillages()
    {
        // Λάβετε το ύψος από το terrain για κάθε χωριό
        float y1 = terrain.SampleHeight(new Vector3(0, 0, 0));
        float y2 = terrain.SampleHeight(new Vector3(N - 1, 0, M - 1));

        Vector3 village1Pos = new Vector3(0, y1, 0); // Στην άκρη του χάρτη
        Vector3 village2Pos = new Vector3(N - 1, y2, M - 1); // Στην άλλη άκρη

        Instantiate(villagePrefab, village1Pos, Quaternion.identity);
        Instantiate(villagePrefab, village2Pos, Quaternion.identity);
    }

    // Δημιουργία πόρων
    void GenerateResources()
    {
        for (int x = 0; x < N; x++)
        {
            for (int y = 0; y < M; y++)
            {
                if (Random.value < resourceProbability)
                {
                    Vector3 position = new Vector3(x, 0, y);

                    // Λάβετε το ύψος από το terrain για την τοποθέτηση του πόρου
                    float terrainHeight = terrain.SampleHeight(position);
                    position.y = terrainHeight;

                    GameObject resource;
                    if (Random.value < 0.5f)
                    {
                        resource = Instantiate(woodPrefab, position, Quaternion.identity);
                    }
                    else
                    {
                        resource = Instantiate(shieldPrefab, position, Quaternion.identity);
                    }
                    resource.transform.SetParent(this.transform);
                }
            }
        }
    }
}

