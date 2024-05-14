using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target; // The player or object the camera will follow.
    public float followSpeed = 2f; // How fast the camera catches up to the target.
    public Tilemap map; // Assign your Tilemap here.

    private Vector2 minCameraPos, maxCameraPos;
    private Camera cam;

    void Start()
    {
        cam = Camera.main; // Get the main camera.
        CalculateBounds();
    }

    void CalculateBounds()
    {
        if (map == null)
        {
            Debug.LogError("Map Tilemap not assigned.");
            return;
        }

        // Calculate the camera's viewable bounds.
        float cameraHeight = 2f * cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;

        Bounds mapBounds = map.localBounds; // Get the local bounds of the Tilemap.

        // Calculate min and max camera positions.
        minCameraPos.x = mapBounds.min.x + cameraWidth / 2;
        maxCameraPos.x = mapBounds.max.x - cameraWidth / 2;
        minCameraPos.y = mapBounds.min.y + cameraHeight / 2;
        maxCameraPos.y = mapBounds.max.y - cameraHeight / 2;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPos, followSpeed * Time.deltaTime);

            // Clamp the camera's position to ensure it doesn't go beyond the map bounds.
            float clampedX = Mathf.Clamp(smoothedPosition.x, minCameraPos.x, maxCameraPos.x);
            float clampedY = Mathf.Clamp(smoothedPosition.y, minCameraPos.y, maxCameraPos.y);

            transform.position = new Vector3(clampedX, clampedY, smoothedPosition.z);
        }
    }
}
