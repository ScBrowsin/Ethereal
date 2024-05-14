using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public static BackgroundMusicManager instance;

    private AudioSource titleScreenMusicSource;
    private AudioSource sceneMusicSource;

    // Expose volume properties for title screen and scene music
    [Range(0f, 1f)]
    public float titleScreenMusicVolume = 1f;

    [Range(0f, 1f)]
    public float sceneMusicVolume = 1f;

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

        // Load audio clips for title screen and scene music from Resources folder
        AudioClip titleScreenMusicClip = Resources.Load<AudioClip>("EtherealThemeIntro");
        AudioClip sceneMusicClip = Resources.Load<AudioClip>("PondofBeginningsTheme");

        // Create AudioSources dynamically
        titleScreenMusicSource = gameObject.AddComponent<AudioSource>();
        sceneMusicSource = gameObject.AddComponent<AudioSource>();

        // Assign audio clips to AudioSources
        titleScreenMusicSource.clip = titleScreenMusicClip;
        sceneMusicSource.clip = sceneMusicClip;
    }

    // Other methods omitted for brevity

    // Update the volume of the title screen and scene music based on the public fields
    void Update()
    {
        titleScreenMusicSource.volume = titleScreenMusicVolume;
        sceneMusicSource.volume = sceneMusicVolume;
    }
}
