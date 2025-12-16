using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // assign your Panel here in Inspector
    private bool isPaused = false;

    void Update()
    {
        if (isPaused){
            if (Input.GetKeyDown(KeyCode.Q)){
                Debug.Log("Q key pressed!");
                Time.timeScale = 1f;        // ensure game is running
                if (pauseMenu != null) Destroy(pauseMenu);
                SceneManager.LoadScene("MainMenu"); // or Application.Quit() in build
            }
        }
        // Toggle pause when "P" is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P key pressed!");
            if (isPaused)

                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);  // show the menu
        Time.timeScale = 0f;        // freeze the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // hide the menu
        Time.timeScale = 1f;        // resume the game
        isPaused = false;
    }

}