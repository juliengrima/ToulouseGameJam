using UnityEngine;

public class PersistentAudioManager : MonoBehaviour
{
    // Singleton instance
    private static PersistentAudioManager _instance;

    // Inspector fields
    [SerializeField] private AudioSource _audioSource; // Attach the AudioSource component here
    [SerializeField] private AudioClip _menuMusic;     // Assign the music you want to play in the menu
    [SerializeField] private AudioClip _gameMusic;     // Assign the music you want to play in the game

    // Awake ensures this GameObject persists and doesn't duplicate
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Makes this object persistent across scenes
        }
        else
        {
            Destroy(gameObject); // Ensures there's only one instance
        }
    }

    private void Start()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>(); // Ensure we have an AudioSource
        }

        PlayMusic(_menuMusic); // Start playing the menu music by default
    }

    /// <summary>
    /// Play the specified music clip.
    /// </summary>
    /// <param name="clip">The AudioClip to play.</param>
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return; // Avoid null clips
        if (_audioSource.isPlaying && _audioSource.clip == clip) return; // Avoid restarting the same clip

        _audioSource.clip = clip;
        _audioSource.loop = true; // Set looping for background music
        _audioSource.Play();
    }

    /// <summary>
    /// Stop the currently playing music.
    /// </summary>
    public void StopMusic()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }
}