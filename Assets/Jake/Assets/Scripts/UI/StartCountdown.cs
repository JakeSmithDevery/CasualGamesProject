using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class StartCountdown : MonoBehaviour
{
    public Text[] countdownText; // Reference to the UI Text component
    public float countdownTime = 3f; // Countdown time in seconds
    private CarController[] playerCars; // Array to hold player car references
    private NetCarController[] netCars;
    private OpponentCar[] opponentCars; // Array to hold opponent car references
    private OpponentCarWaypoints[] opponentCarWaypoints; // Array to hold opponent car waypoints

    private bool HaveWeCountedYet = false;

    private void Awake()
    {
        playerCars = FindObjectsOfType<CarController>();
        netCars = FindObjectsOfType<NetCarController>();
        opponentCars = FindObjectsOfType<OpponentCar>();
        opponentCarWaypoints = FindObjectsOfType<OpponentCarWaypoints>();
    }
    private void Update()
    {
        if (HaveWeCountedYet == true) return;
        if (SceneManager.GetActiveScene().name == "NetGame")
        {
            if (playerCars.Length == 2)
            {
                StartCoroutine(NetGameCountdown());
            }
            else
            {
                DisableScripts();
            }
        }
        else
        {
            StartCoroutine(StartCountdownRoutine());
        }
    }
    IEnumerator NetGameCountdown()
    {
        HaveWeCountedYet = true;
        Time.timeScale = 1f;
        UpdateCountdownText("Get Ready!");
        yield return new WaitForSeconds(.1f);
        DisableScripts();
        yield return new WaitForSeconds(2f);

        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            UpdateCountdownText(currentTime);
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        EnableScripts();

        UpdateCountdownText("GO!");
        yield return new WaitForSeconds(1f);
        SetCountdownTextActive(false);
    }

    IEnumerator StartCountdownRoutine()
    {
        HaveWeCountedYet = true;
        Time.timeScale = 1f;
        UpdateCountdownText("Get Ready!");
        yield return new WaitForSeconds(.1f);
        DisableScripts();
        yield return new WaitForSeconds(2f);

        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            UpdateCountdownText(currentTime);
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        EnableScripts();

        UpdateCountdownText("GO!");
        yield return new WaitForSeconds(1f);
        SetCountdownTextActive(false);
    }

    void DisableScripts()
    {
        foreach (CarController car in playerCars)
        {
            car.enabled = false;
        }
        foreach (OpponentCar car in opponentCars)
        {
            car.enabled = false;
        }
        foreach (OpponentCarWaypoints waypoints in opponentCarWaypoints)
        {
            waypoints.enabled = false;
        }
        foreach (NetCarController car in netCars)
        {
            car.enabled = false;
        }
    }

    void EnableScripts()
    {
        foreach (CarController car in playerCars)
        {
            car.enabled = true;
        }
        foreach (OpponentCar car in opponentCars)
        {
            car.enabled = true;
        }
        foreach (OpponentCarWaypoints waypoints in opponentCarWaypoints)
        {
            waypoints.enabled = true;
        }
        foreach (NetCarController car in netCars)
        {
            car.enabled = true;
        }
    }

    void UpdateCountdownText(string text)
    {
        foreach (Text countdown in countdownText)
        {
            countdown.text = text;
        }
    }

    void UpdateCountdownText(float text)
    {
        foreach (Text countdown in countdownText)
        {
            countdown.text = text.ToString("0");
        }
    }

    void SetCountdownTextActive(bool active)
    {
        foreach (Text countdown in countdownText)
        {
            countdown.gameObject.SetActive(active);
        }
    }

}
