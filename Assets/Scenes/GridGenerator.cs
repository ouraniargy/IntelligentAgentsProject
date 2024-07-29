using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int columns = 100;  // Αριθμός στηλών
    public int rows = 100;  // Αριθμός γραμμών
    public GameObject cellPrefab;  // Prefab για το κάθε κελί

    public GameObject woodPrefab;  // Prefab για την Ξυλεία
    public GameObject goldPrefab;  // Prefab για τον Χρυσό
    public GameObject ironPrefab;  // Prefab για τον Σίδηρο
    public GameObject village1Prefab;  // Prefab για το Χωριό της Ομάδας 1
    public GameObject village2Prefab;  // Prefab για το Χωριό της Ομάδας 2
    private GameObject[,] grid;

    // Καθορισμός πόρων
    private Dictionary<GameObject, int> resources = new Dictionary<GameObject, int>()
    {
        { woodPrefab, 50 },  // Πλήθος θέσεων με ξυλεία
        { goldPrefab, 30 },  // Πλήθος θέσεων με χρυσό
        { ironPrefab, 20 }   // Πλήθος θέσεων με σίδηρο
    };

    // Καθορισμός χωριών
    private Dictionary<GameObject, int> villages = new Dictionary<GameObject, int>()
    {
        { village1Prefab, 1 },  // Ένα χωριό για την ομάδα 1
        { village2Prefab, 1 }   // Ένα χωριό για την ομάδα 2
    };


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        PlaceResources();
        PlaceVillages();
    }

    void GenerateGrid()
    {
        grid = new GameObject[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(i, 0, j), Quaternion.identity);
                grid[i, j] = cell;
                cell.transform.SetParent(this.transform);
            }
        }
    }

    void PlaceResources()
    {
        foreach (var resource in resources)
        {
            int count = resource.Value;
            GameObject prefab = resource.Key;
            while (count > 0)
            {
                int x = Random.Range(0, rows);
                int z = Random.Range(0, columns);
                if (grid[x, z] == null)  // Αν η θέση είναι κενή
                {
                    GameObject resourceObject = Instantiate(prefab, new Vector3(x, 0.5f, z), Quaternion.identity);
                    grid[x, z] = resourceObject;
                    resourceObject.transform.SetParent(this.transform);
                    count--;
                }
            }
        }
    }

    void PlaceVillages()
    {
        foreach (var village in villages)
        {
            int count = village.Value;
            GameObject prefab = village.Key;
            while (count > 0)
            {
                int x = Random.Range(0, rows);
                int z = Random.Range(0, columns);
                if (grid[x, z] == null)  // Αν η θέση είναι κενή
                {
                    GameObject villageObject = Instantiate(prefab, new Vector3(x, 0.5f, z), Quaternion.identity);
                    grid[x, z] = villageObject;
                    villageObject.transform.SetParent(this.transform);
                    count--;
                }
            }
        }
    }
}
