using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip mainGameLoopClip;
    public AudioClip defaultClip;
    private AudioSource audioSource;
    internal static MusicPlayer instance = null;

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
            return;
        }

        audioSource = GetComponent<AudioSource>();
        AudioListener.volume = 0.3f;
        audioSource.clip = defaultClip;

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainGameLoop")
        {
            if (audioSource.clip != mainGameLoopClip)
            {
                audioSource.clip = mainGameLoopClip;

            }

        }

        else if (audioSource.clip != defaultClip)
        {
            audioSource.clip = defaultClip;



        }


        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

