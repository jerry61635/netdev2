using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager
{
    public event System.Action<Player> OnLocalPlayerJoin;
    private GameObject gameObject; 

    private static gameManager m_Instance;
    public static gameManager Instance
    {
        get
        {
            if(m_Instance == null)
            {
                m_Instance = new gameManager();
                m_Instance.gameObject = new GameObject("_gameManager");
                m_Instance.gameObject.AddComponent<InputController>();
            }
            return m_Instance;
        }
    }

    private InputController m_InputController;
    public InputController inputController
    {
        get
        {
            if (m_InputController == null)
                m_InputController = gameObject.GetComponent<InputController>();
            return m_InputController;
        }
    }

    private Player m_LocalPlayer;
    public Player LocalPlayer
    {
        get
        {
            return m_LocalPlayer;
        }
        set
        {
            m_LocalPlayer = value;
            if (OnLocalPlayerJoin != null)
                OnLocalPlayerJoin(m_LocalPlayer);
        }
    }
}
