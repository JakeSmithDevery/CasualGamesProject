using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

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
        //SceneManager.LoadSceneAsync(6);
        Debug.Log("Online mode is not implemented yet.");
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
    public void QuitGame()
    {
        Application.Quit();
    }
}
