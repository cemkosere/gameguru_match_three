using System;
using CameraSystem;
using GridSystem;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Grid")]
        [SerializeField] private int gridSize;
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private Transform gridParent;

        public static GgGrid CurrentGrid;
        
        
        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            CurrentGrid = GridCreator.CreateGrid(gridSize, tilePrefab, gridParent);
            Camera.main.OrthographicFitter(gridSize);

        }
    }
}
