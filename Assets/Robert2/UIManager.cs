using UnityEngine;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject lobbyUI;  // Lobby/Join UI
    public GameObject gameUI;   // Game UI (HUD, etc.)

    private void Start()
    {
        LobbyTime();
    }
    public void GameTime()
    {
        lobbyUI.SetActive(false);
        gameUI.SetActive(true);
    }

    public void LobbyTime()
    {
        lobbyUI.SetActive(true);
        gameUI.SetActive(false);
    }
}
