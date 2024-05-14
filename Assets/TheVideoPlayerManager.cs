using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TheVideoPlayerManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Subscribe to the videoPlayer's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Event handler for when the video ends
    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the next scene
        SceneManager.LoadScene("EtherealScene1PondOfBeginnings");
    }
}
