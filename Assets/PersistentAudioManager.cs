using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PersitentAudioManager : MonoBehaviour
{
    public static PersitentAudioManager instance;

    public AudioSource audioSource;
    public AudioClip[] musicTracks;

    private int currentTrackIndex = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayNextTrack();
    }

    public void PlayNextTrack()
    {
        audioSource.clip = musicTracks[currentTrackIndex];
        audioSource.Play();

        // Move to the next track
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Start loading the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Scene is fully loaded, continue playing music
        audioSource.Play();
    }
}
