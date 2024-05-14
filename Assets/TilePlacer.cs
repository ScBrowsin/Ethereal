using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour
{
    public TileBase etherealTopTile;

    // Method to place top layer tiles in a specified area
    public void PlaceTiles(Tilemap etherealTopTilemap, RectInt area)
    {
        Debug.Log("Placing top layer tiles...");

        for (int x = area.xMin; x <= area.xMax; x++)
        {
            for (int y = area.yMin; y <= area.yMax; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0); // Use 0 for Z position

                // Place the top tile at the current position
                Debug.Log("Placing top tile at position: " + tilePosition);
                etherealTopTilemap.SetTile(tilePosition, etherealTopTile);
            }
        }

        Debug.Log("Top layer tiles placed.");
    }
}
