using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource; // Assign an AudioSource in the Inspector
    public AudioClip winMusic;      // Assign your win music here

    [Header("Delay")]
    public float delayBeforeMusic = 2f; // seconds

    private bool musicPlayed = false;

    private void Start()
    {
        // Start the delayed music coroutine
        if (audioSource != null && winMusic != null)
        {
            Invoke(nameof(PlayWinMusic), delayBeforeMusic);
        }
        else
        {
            Debug.LogWarning("AudioSource or WinMusic not assigned!");
        }
    }

    private void Update()
    {
        // Reload scene when R is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }

    private void PlayWinMusic()
    {
        if (!musicPlayed)
        {
            audioSource.clip = winMusic;
            audioSource.Play();
            musicPlayed = true;
            Debug.Log("Win music started!");
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
