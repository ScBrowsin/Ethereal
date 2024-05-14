using UnityEngine;
using UnityEngine.Tilemaps;

public class TileReplacerSigPedLow : MonoBehaviour
{
    public TileBase etherealTopTile; // Tile to replace with
    public Tilemap theTilemap;
    public Vector2Int[] tilePositions; // Positions to replace tiles at

    // Method to replace top tiles with the specified tile at the specified positions
    public void ReplaceTiles(Tilemap etherealTopTilemap, Vector2Int position)
    {
        Vector3Int tilePosition = new Vector3Int(position.x, position.y, 0);
        etherealTopTilemap.SetTile(tilePosition, etherealTopTile);
        Debug.Log("Replaced top tile at position: " + tilePosition);
    }

}
