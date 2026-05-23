using UnityEngine;
using System.IO;

public class GridMake : MonoBehaviour
{
    private GridData config;

    void Start()
    {
        // Load JSON file
        string path = Path.Combine(Application.streamingAssetsPath, "gridConfig.json");
        string jsonData = File.ReadAllText(path);

        // Parse JSON into GridData object
        config = JsonUtility.FromJson<GridData>(jsonData);

        Debug.Log($"Grid: {config.gridSizeX}x{config.gridSizeY}x{config.gridSizeZ}, Cell size: {config.cellSize}");

        // Generate cubes
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < config.gridSizeX; x++)
        {
            for (int y = 0; y < config.gridSizeY; y++)
            {
                // Only X and Y, no Z
                Vector3 pos = new Vector3(x, y, 0) * config.cellSize;
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = pos;
                cube.transform.localScale = Vector3.one * config.cellSize * 0.9f;
                cube.name = $"Cell_{x}_{y}";
            }
        }
    }
}
