using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Required for UI components like Image

public class GridGenerator : MonoBehaviour
{
    public int columns = 100;  // Number of columns
    public int rows = 100;  // Number of rows
    public GameObject cellPrefab;  // Prefab for each grid cell
    public Sprite Village1Sprite;  // Sprite for Village 1
    public Sprite Village2Sprite;  // Sprite for Village 2
    public Sprite WoodSprite;      // Sprite for Wood
    public Sprite GoldSprite;      // Sprite for Gold
    public Sprite IronSprite;      // Sprite for Iron
    public Sprite EmptySprite;     // Sprite for Empty cell

    private GameObject[,] grid;

    private List<Agent> agents;
    private Agent selectedAgent;

    void Start()
    {
        GenerateGrid();
        InitializeAgents();
    }

    void InitializeAgents()
    {
        agents = new List<Agent>();
        Agent agent = new Agent(new Vector2Int(0, 0));  // Example agent at (0, 0)
        agents.Add(agent);
        UpdateKnownAreas(agent);  // Update the initial known area
    }

    public void SelectAgent(int agentIndex)
    {
        if (agentIndex >= 0 && agentIndex < agents.Count)
        {
            selectedAgent = agents[agentIndex];
            // Update UI for selected agent
            UpdateKnownAreas(selectedAgent);  // Update known areas for the selected agent
        }
    }

    public void MoveAgent(Agent agent, Vector2Int newPosition)
    {
        // Move the agent to the new position
        agent.Move(newPosition);

        // Add new position to known positions
        agent.knownPositions.Add(newPosition);

        // Update the grid appearance
        UpdateKnownAreas(agent);
    }

    public void UpdateKnownAreas(Agent agent)
    {
        // Reset all cells to a default state (semi-transparent for unknown areas)
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var img = grid[i, j].GetComponent<Image>();
                if (img != null)
                {
                    img.color = new Color(0.5f, 0.5f, 0.5f, 1f);  // Color for unknown areas (grey)
                }
            }
        }

        // Update the cells that the agent knows about
        foreach (var position in agent.knownPositions)
        {
            var img = grid[position.x, position.y].GetComponent<Image>();
            if (img != null)
            {
                // Set known areas back to full brightness
                img.color = Color.white;

                // Optionally re-assign the correct sprite and color based on the type of the cell
                char cellType = DetermineCellTypeAtPosition(position); // Assuming you have a way to get the cell type at a specific position
                switch (cellType)
                {
                    case 'W':
                        img.sprite = WoodSprite;
                        img.color = new Color(0.0f, 0.5f, 0.0f);  // Green tint for wood cells
                        break;
                    case 'G':
                        img.sprite = GoldSprite;
                        img.color = new Color(1.0f, 0.84f, 0.0f);  // Custom gold color
                        break;
                    case 'I':
                        img.sprite = IronSprite;
                        img.color = Color.gray;  // Gray tint for iron cells
                        break;
                    case '1':
                        img.sprite = Village1Sprite;
                        img.color = Color.red;  // Red tint for village 1 cells
                        break;
                    case '2':
                        img.sprite = Village2Sprite;
                        img.color = new Color(0.6f, 0.3f, 0.0f);  // Brown tint for village 2 cells
                        break;
                    case ' ':
                        img.sprite = EmptySprite;
                        img.color = Color.white;  // White color for empty cells
                        break;
                }
            }
        }
    }

    private char DetermineCellTypeAtPosition(Vector2Int position)
    {
        // Implement logic to return the correct cell type ('W', 'G', 'I', '1', '2', ' ') for the given position
        // This might involve storing the initial cell type during grid generation or another mechanism.
        // For now, assume it's stored in some data structure.
        // Example (you might have a 2D array storing the cell types):
        // return cellTypesGrid[position.x, position.y];
        return ' ';  // Replace with actual logic
    }

    void GenerateGrid()
    {
        {
            Debug.Log("Generating Grid...");
            grid = new GameObject[rows, columns];
            System.Random random = new System.Random();  // Create a random number generator

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    GameObject cell = Instantiate(cellPrefab, new Vector3(j * 32, i * 32, 0), Quaternion.identity);
                    cell.transform.SetParent(this.transform, false);
                    Image img = cell.GetComponent<Image>();

                    if (img != null)
                    {
                        char[] cellTypes = new char[] { 'W', 'G', 'I', '1', '2', ' ' };
                        char randomCellType = cellTypes[random.Next(cellTypes.Length)];

                        switch (randomCellType)
                        {
                            case 'W':  // Wood
                                img.sprite = WoodSprite;
                                img.color = new Color(0.6f, 0.3f, 0.0f);  // Custom brown color
                                break;
                            case 'G':  // Gold
                                img.sprite = GoldSprite;
                                img.color = new Color(1.0f, 0.84f, 0.0f);  // Custom gold
                                break;
                            case 'I':  // Iron
                                img.sprite = IronSprite;
                                img.color = Color.grey;
                                break;
                            case '1':  // Village 1
                                img.sprite = Village1Sprite;
                                img.color = Color.red;
                                break;
                            case '2':  // Village 2
                                img.sprite = Village2Sprite;
                                img.color = Color.blue;
                                break;
                            case ' ':  // Empty space
                                img.sprite = EmptySprite;
                                img.color = Color.white;
                                break;
                        }

                        //img.color = Color.white;   // Ensure the color is set to white, so the sprite is fully visible
                        Debug.Log($"Cell at ({i},{j}) set to sprite: {img.sprite.name}");
                    }
                    else
                    {
                        Debug.LogError("No Image component found on cell prefab.");
                    }

                    grid[i, j] = cell;  // Add cell to grid array
                }
            }
        }
    }



    public class Agent
    {
        public Vector2Int position;
        public List<string> carriedGoods;
        public HashSet<Vector2Int> knownPositions;

        public Agent(Vector2Int startPosition)
        {
            position = startPosition;
            carriedGoods = new List<string>();
            knownPositions = new HashSet<Vector2Int>();
            knownPositions.Add(startPosition);  // Agent knows its starting position
        }

        public void Move(Vector2Int newPosition)
            {
            // Ενημέρωση της θέσης του πράκτορα
            position = newPosition;

            // Προσθήκη της νέας θέσης στη λίστα των γνωστών θέσεων
            if (!knownPositions.Contains(newPosition))
            {
                knownPositions.Add(newPosition);
            }
    }


        public void PickUpResource(string resource)
        {
            carriedGoods.Add(resource);
        }
    }
}