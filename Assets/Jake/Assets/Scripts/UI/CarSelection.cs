using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public GameObject allCarsContainers;
    private GameObject[] allCars;
    private int currentCarIndex = 0;

    private void Start()
    {
        allCars = new GameObject[allCarsContainers.transform.childCount];
        for (int i = 0; i < allCarsContainers.transform.childCount; i++)
        {
            allCars[i] = allCarsContainers.transform.GetChild(i).gameObject;
            allCars[i].SetActive(false);
        }

        if (PlayerPrefs.HasKey("SelectedCarIndex"))
        {
            currentCarIndex = PlayerPrefs.GetInt("SelectedCarIndex");
        }

        ShowCurrentCar();
    }


    void ShowCurrentCar()
    {
        foreach (GameObject car in allCars)
        {
            car.SetActive(false);
        }

        allCars[currentCarIndex].SetActive(true);
    }

    public void NextCar()
    {
        currentCarIndex = (currentCarIndex + 1) % allCars.Length;

        ShowCurrentCar();
    }

    public void PreviousCar()
    {
        currentCarIndex = (currentCarIndex - 1 + allCars.Length) % allCars.Length;
        ShowCurrentCar();
    }

    public void SelectCar()
    {
        PlayerPrefs.SetInt("SelectedCarIndex", currentCarIndex);
        PlayerPrefs.Save();
        Debug.Log("Selected Car Index: " + currentCarIndex);

        SceneManager.LoadSceneAsync(0);
    }
}
