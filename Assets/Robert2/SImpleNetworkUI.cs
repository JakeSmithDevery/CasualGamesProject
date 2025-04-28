using Unity.Netcode;
using UnityEngine;

public class SimpleNetworkUI : MonoBehaviour
{
    private void OnGUI()
    {
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            if (GUI.Button(new Rect(10, 10, 100, 50), "Host"))
            {
                NetworkManager.Singleton.StartHost();
            }
            if (GUI.Button(new Rect(10, 70, 100, 50), "Client"))
            {
                NetworkManager.Singleton.StartClient();
            }
        }
    }
}
