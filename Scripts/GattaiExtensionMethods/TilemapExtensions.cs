using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GattaiExtensionMethods
{
    /// <summary>
    /// This class defines extension methods for the Unity Tilemap class.
    /// </summary>
    public static class TilemapExtensions
    {
        /// <param name="tilemap">The target tilemap.</param>
        /// <returns>Returns an enumerable sequence of Vector3Int positions that correspond to the cells in the tilemap
        /// that have a tile.</returns>
        public static IEnumerable<Vector3Int> GetTilesCellPositions(this Tilemap tilemap)
        {
            foreach (var cellPosition in tilemap.cellBounds.allPositionsWithin)
            {
                if (!tilemap.HasTile(cellPosition)) continue;
                yield return cellPosition;
            }
        }

        /// <param name="tilemap">The target tilemap.</param>
        /// <returns>returns an enumerable sequence of Vector3 positions that correspond to the world positions of the
        /// cells in the tilemap that have a tile</returns>
        public static IEnumerable<Vector3> GetTilesWorldPositions(this Tilemap tilemap) => 
            tilemap.GetTilesCellPositions().Select(tilemap.CellToWorld);

        /// <summary>
        /// Takes an Action Vector3Int delegate and applies it to every cell in the tilemap that has a tile.
        /// </summary>
        /// <param name="tilemap">The target tilemap.</param>
        /// <param name="action">The Action Vector3Int to apply to each tile.</param>
        public static void ForEachTile(this Tilemap tilemap, Action<Vector3Int> action)
        {
            foreach (var cellPosition in tilemap.GetTilesCellPositions())
            {
                action?.Invoke(cellPosition);
            }
        }

        /// <summary>
        /// Copies the tiles from one tilemap to another. It does this by creating a dictionary that maps each tile's
        /// world position to its corresponding tile, then iterating over this dictionary and setting the corresponding
        /// tile in the target tilemap.
        /// </summary>
        /// <param name="sourceTilemap">The source tilemap to copy its tiles.</param>
        /// <param name="targetTilemap">The target tilemap to receive the copy of the source tilemap tiles.</param>
        public static void CopyTilesTo(this Tilemap sourceTilemap, Tilemap targetTilemap)
        {
            var cellToWorldByTile = new Dictionary<Vector3, TileBase>();

            sourceTilemap.ForEachTile(cellPosition => cellToWorldByTile.Add(
                sourceTilemap.CellToWorld(cellPosition), sourceTilemap.GetTile(cellPosition)));

            foreach (var (worldPosition, tile) in cellToWorldByTile)
            {
                var worldToCell = targetTilemap.WorldToCell(worldPosition);
                targetTilemap.SetTile(worldToCell, tile);
            }
        }

        /// <summary>
        /// Clears the tile at the given cell position.
        /// </summary>
        /// <param name="sourceTilemap">The target tilemap.</param>
        /// <param name="cellPosition">The target cell position to clear.</param>
        public static void Clear(this Tilemap sourceTilemap, Vector3Int cellPosition) => 
            sourceTilemap.SetTile(cellPosition, null);

        /// <summary>
        /// Clears all tiles in the tilemap.
        /// </summary>
        /// <param name="sourceTilemap">The target Tilemap.</param>
        public static void Clear(this Tilemap sourceTilemap) => sourceTilemap.ForEachTile(sourceTilemap.Clear);

        /// <summary>
        /// Clears all tiles in the source tilemap that have a corresponding tile in the target tilemap.
        /// </summary>
        /// <param name="sourceTilemap">The source tilemap to clear the tiles.</param>
        /// <param name="targetTilemap">The target tilemap to get the tiles' cells positions.</param>
        public static void Clear(this Tilemap sourceTilemap, Tilemap targetTilemap)
        {
            foreach (var cellPosition in targetTilemap.GetTilesWorldPositions().Select(sourceTilemap.WorldToCell))
            {
                sourceTilemap.Clear(cellPosition);
            }
        }
    }
}