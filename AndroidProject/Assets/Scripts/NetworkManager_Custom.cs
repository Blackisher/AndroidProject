﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager_Custom : NetworkManager {

    public void StartUpHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }


    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }


    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.FindChild("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }
    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            SetupMenuSceneButtons();
        }
        else
        {
            SetupOtherSceneButtons();
        }
    }

    void SetupMenuSceneButtons()
    {
        GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartUpHost);

        GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
    }


    void SetupOtherSceneButtons()
    {
       // GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
       // GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
    }
}
