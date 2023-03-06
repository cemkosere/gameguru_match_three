using System;
using System.Collections.Generic;
using CameraSystem;
using GridSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Grid")]
        [SerializeField] private int gridSize;
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private Transform gridParent;
        private GgGrid _currentGrid;
        
        
        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            _currentGrid = GridCreator.CreateGrid(gridSize, tilePrefab, gridParent);
            Camera.main.OrthographicFitter(gridSize);
            Tile.OnSelectTile += OnTileSelected;
        }

        private void OnTileSelected(Tile tile)
        {
            SearchDfs(tile);
        }

        private void SearchDfs(Tile startTile)
        {
            var stack = new Stack<Tile>();
            stack.Push(startTile);

            var selectedNeighbours = new List<Tile> {startTile};

            var currentTile = startTile;

            while (stack.Count > 0)
            {
                var addedAny = false;
                var neighbours = _currentGrid.GetNeighbours(currentTile);
                foreach (var neighbour in neighbours)
                {
                    if(neighbour == null) continue;
                    if(!neighbour.IsSelected) continue;
                    if(selectedNeighbours.Contains(neighbour)) continue;
                    stack.Push(neighbour);
                    selectedNeighbours.Add(neighbour);
                    currentTile = neighbour;
                    addedAny = true;
                }

                if (!addedAny)
                {
                    currentTile = stack.Pop();
                }
            }

            if (selectedNeighbours.Count < 3) return;
            foreach (var tile in selectedNeighbours)
            {
                tile.Deselect();
            }

        }

    }
}
