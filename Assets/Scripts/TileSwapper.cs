using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSwapper : MonoBehaviour
{
    public TileBase etherealTopTile;

    // Method to remove top layer tiles in a specified area
    public void RemoveTopLayer(Tilemap etherealTopTilemap, RectInt area)
    {
        Debug.Log("Removing top layer tiles...");

        for (int x = area.xMin; x <= area.xMax; x++)
        {
            for (int y = area.yMin; y <= area.yMax; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0); // Use 0 for Z position

                // Get the top tile at the current position
                TileBase topTile = etherealTopTilemap.GetTile(tilePosition);

                // If there's a top tile, remove it
                if (topTile != null)
                {
                    Debug.Log("Removing top tile at position: " + tilePosition);
                    etherealTopTilemap.SetTile(tilePosition, null);
                }
            }
        }

        Debug.Log("Top layer tiles removed.");
    }

    // Method to swap a top tile with another top tile at a specified position
    public void TileSwapperSigPedLow(Vector2Int position)
    {
        Tilemap etherealTopTilemap = GetComponent<Tilemap>();

        if (etherealTopTilemap != null)
        {
            Vector3Int tilePosition = new Vector3Int(position.x, position.y, 0);
            etherealTopTilemap.SetTile(tilePosition, etherealTopTile);
            Debug.Log("Swapped top tile at position: " + tilePosition);
        }
        else
        {
            Debug.LogWarning("Tilemap component not found.");
        }
    }

    // Method to swap a top tile with another top tile at a specified position
    public void TileSwapperSigPedTop(Vector2Int position)
    {
        Tilemap etherealTopTilemap = GetComponent<Tilemap>();

        if (etherealTopTilemap != null)
        {
            Vector3Int tilePosition = new Vector3Int(position.x, position.y, 0);
            etherealTopTilemap.SetTile(tilePosition, etherealTopTile);
            Debug.Log("Swapped top tile at position: " + tilePosition);
        }
        else
        {
            Debug.LogWarning("Tilemap component not found.");
        }
    }
}
