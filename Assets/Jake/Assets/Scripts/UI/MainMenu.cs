using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void VsCPU()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void Practice()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void TimeTrial()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void Online()
    {
        SceneManager.LoadSceneAsync(6);
        //Debug.Log("Online mode is not implemented yet.");
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OpenGarage()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void RemoveAds()
    {
        // Implement the logic to remove ads here
        Debug.Log("Ads removed.");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
        isGamePaused = true;
        pauseMenuUI.SetActive(true); // Show the pause menu

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        isGamePaused = false;
        pauseMenuUI.SetActive(false); // Hide the pause menu
    }

    public void TogglePause()
    {
        if (isGamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
