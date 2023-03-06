using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public static class GridCreator
    {
        public static GgGrid CreateGrid(int size, Tile tilePrefab, Transform parent)
        {
            var initialX = -(size - 1) / 2f;
            var initialY = (size - 1) / 2f;

            var grid = new GgGrid
            {
                GridSize = size,
                Tiles = new List<Tile>(),
                Tiles2 = new Tile[size][]
            };

            for (var i = 0; i < size; i++)
            {
                grid.Tiles2[i] = new Tile[size];
                for (var j = 0; j < size; j++)
                {
                    var x = initialX + j;
                    var y = initialY - i;
                    var z = 0;
                    var insTile = Object.Instantiate(tilePrefab, new Vector3(x, y, z), Quaternion.identity, parent);
                    grid.Tiles.Add(insTile);
                    grid.Tiles2[i][j] = insTile;
                }
            }
            return grid;
        }
    }
}