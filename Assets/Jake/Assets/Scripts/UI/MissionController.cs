using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    public float timeLimitInSeconds = 60f; // Time limit for the mission in seconds
    private float elapsedTime = 0f; // Time elapsed since the mission started
    private bool missionCompleted = false; // Flag to check if the mission is completed

    public Text timerText; // Reference to the UI Text component to display the timer
    public Text resultText; // Reference to the UI Text component to display the result

    void Start()
    {
        resultText.text = ""; // Clear the result text at the start
        UpdateTimerText(); // Initialize the timer text
    }

    private void Update()
    {
        if (!missionCompleted)
        {
            elapsedTime += Time.deltaTime; // Increment the elapsed time
            if (elapsedTime >= timeLimitInSeconds)
            {
                EndMission(false); // End the mission if the time limit is reached

            }
                UpdateTimerText(); // Update the timer text
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CarController carController = other.GetComponent<CarController>();

        if(carController != null)
        {
            EndMission(true); // End the mission successfully if the player collides with the trigger
        }
    }

    void UpdateTimerText()
    {
        float remainingTime = Mathf.Max(0f, timeLimitInSeconds - elapsedTime);
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndMission(bool success)
    {
        missionCompleted = true;
        if (success)
        {
            resultText.text = "Mission Completed!";
        }
        else
        {
            resultText.text = "Mission Failed!";
        }

        Invoke("LoadMainMenuScene", 3f); // Load the main menu scene after 3 seconds
    }

    void LoadMainMenuScene()
    {
        SceneManager.LoadSceneAsync(0); // Load the main menu scene
    }
}
