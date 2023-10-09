using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    public static GamesManager Instance;

    private void Awake()
    {
        MainMenuState();
    }
    void Start()
    {
        GameState();
    }


    void Update()
    {
        // GameState(); ?? here as well
    }

    public void MainMenuState()
    {
        //Enable Mouse movement
    }

    public void GameInit()
    {
        //GameInit UI
    }

    public void GameState()
    {

    }
    public void PauseState()
    {
        Debug.Log("Game Paused");
    }
}
