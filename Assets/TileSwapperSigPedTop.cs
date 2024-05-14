using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwapperSigPedTop : MonoBehaviour
{
    public TileBase etherealTopTileToSwap; // Tile to swap with
    public Tilemap theTilemap;

    // Method to swap a single top tile with the specified tile at the specified position
    public void SwapTile(Tilemap theTilemap, int tilePosX, int tilePosY)
    {
        Vector3Int tilePos = new Vector3Int(tilePosX, tilePosY, 0);
        TileBase currentTile = theTilemap.GetTile(tilePos);
        if (currentTile != null)
        {
            Debug.Log("Swapping top tile at position: " + tilePos);
            theTilemap.SetTile(tilePos, etherealTopTileToSwap);
        }
        else
        {
            Debug.LogWarning("No top tile found at position: " + tilePos);
        }
    }
}
