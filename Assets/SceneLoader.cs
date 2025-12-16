using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("Button clicked — loading GameScene");
        SceneManager.LoadScene("GameScreen");
    }
}