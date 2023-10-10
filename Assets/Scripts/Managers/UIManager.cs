using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UIManager : MonoBehaviour
{
    //Multiplayeroptions is outcommented, TODO! - Enable instantioation of a second player etc.

    [SerializeField] GameObject _canvasMainMenu;
    [SerializeField] GameObject _buttonPlayersOne;

    [SerializeField] GameObject _canvasMovementMenu;
    [SerializeField] GameObject _playButton;

    [SerializeField] GameObject _canvasGameUI;

    [SerializeField] GameObject _canvasPause;
    [SerializeField] GameObject Resume;
    [SerializeField] GameObject QuitGame;

    public static ScenesManager scenesManager;     //what for?

    public void Awake()
    {
        Time.timeScale = 0f;
        MainMenu();      //shows mainmenu
    }

    public void Start()
    {
        scenesManager = FindAnyObjectByType<ScenesManager>();
    }

    public void OnDestroy()
    {
        MainMenu();
        ToMovementMenu();
    }

    public void MainMenu()                  //Enable CanvasMainMenu & Player(s) button
    {
        _canvasMainMenu.SetActive(true);
    }

    public void ToMovementMenu()            //This action is set in the OnClick, attached to previous button //TODO: Include a "back and forth-button"
    {
        _canvasMainMenu.SetActive(false);
        _canvasMovementMenu.SetActive(true);
    }

    public void OnPlayButtonClick()         /* This action starts the game by setting the timescale and enables GameUI
                                             * However, this way, you won't be able to keep track on runtime or lapcount? */
    {
        _canvasMovementMenu.SetActive(false);
        _canvasGameUI.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void PauseMenu()                 //gameObject.GetComponent<CanvasAttribute>().enabled = true;    https://www.youtube.com/watch?v=Z3tO8FPCM_w
    {
        Time.timeScale = 0f;
        _canvasGameUI.SetActive(false);     //To Disable LapDisplay when paused, neccessary? Guess it's a preferance.
        _canvasPause.SetActive(true);
    }

    public void OnResume()
    {
        _canvasGameUI.SetActive(true);
        _canvasPause.SetActive(false);
        Time.timeScale = 1.0f;
        Debug.Log("Resumed");
    }

    public void OnQuitGame()
    {
        scenesManager.LoadNewGame();
    }
}
