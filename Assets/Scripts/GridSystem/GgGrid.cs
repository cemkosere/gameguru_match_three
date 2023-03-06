using System.Collections.Generic;

namespace GridSystem
{
    public class GgGrid
    {
        public int GridSize;
        public Tile[,] Tiles;

        public IEnumerable<Tile> GetNeighbours(Tile tile)
        {
            var index = tile.Index;
            var neighbours = new Tile[4];
            
            neighbours[0] = index.x > 0 ? Tiles[index.x - 1, index.y] : null;
            neighbours[1] = index.y > 0 ? Tiles[index.x, index.y - 1] : null;
            neighbours[2] = index.x < GridSize-1 ? Tiles[index.x + 1, index.y] : null;
            neighbours[3] = index.y < GridSize-1 ? Tiles[index.x, index.y + 1] : null;

            return neighbours;
        }
    }
}