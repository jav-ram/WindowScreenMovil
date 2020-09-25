using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject connectButton;
    public GameObject reconnectButton;

    public TCP_Client client;

    public void Connect() {
        Debug.Log("testing");
        client.ConnectToTcpServer("192.168.1.17", 8052);
        
        connectButton.active = !connectButton.active;
        reconnectButton.active = !reconnectButton.active;
    }
}
