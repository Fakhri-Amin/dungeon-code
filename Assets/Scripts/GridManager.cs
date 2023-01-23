using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GridManager : MonoBehaviour
{
    [SerializeField] private float width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x}{y}";
                var offset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(offset);
            }
        }

        // cam.transform.position = new Vector3((float)width, (float)height / 2 - 1f, -10);
    }
}
