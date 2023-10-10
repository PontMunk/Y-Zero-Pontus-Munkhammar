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

    [SerializeField] GameObject _canvasSelectPlayers;
    [SerializeField] GameObject _buttonPlayerOne;
    //[SerializeField] GameObject _buttonPlayerTwo;

    [SerializeField] GameObject _canvasMovementIntro1;
    [SerializeField] GameObject _playButton;
    //[SerializeField] GameObject _canvasMovementIntro2;
    //[SerializeField] GameObject _playButton;

    [SerializeField] GameObject _canvasGameUI;

    [SerializeField] GameObject _canvasPause;

    [SerializeField] GameObject Resume;
    [SerializeField] GameObject QuitGame;


    public ScenesManager scenesManager;     //what for?

    private bool OnScene = true;
    private float onMouseDown = 0f;
    /*
     * What do I need this to do?
     * Get the current Scene, to address what commands should be available
     * Enable them to the current scene
     * if other scene, disable/destroy the other UI's
     */

    private void Awake()
    {
        PlayerSelectOne();      //shows mainmenu
    }
    
    private void Update()
    {
        //OnPlayButtonClick();        //need to assign a action to this, not do it in the update
        //PauseMenu();
        //OnResume();
        //OnQuitGame();
    }
    
    public void PlayerSelectOne()
    {
        //ScenesManager.Instance.LoadScene(ScenesManager.Scene.CourtOne);       //why load the scene here? Already done in the scenesmanager?
        
        //Enable CanvasPlayerSelectOne & button
        _canvasSelectPlayers.SetActive(true);
        Time.timeScale = 1f;
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            OnPlayerOneClick();
        }
    }

    private void OnPlayerOneClick()         //This action is set in the OnClick, attached to previous button
    {
        _canvasSelectPlayers.SetActive(false);
        _canvasMovementIntro1.SetActive(true);

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            OnPlayButtonClick();
        }
    }

    /*
    private void PlayerSelectTwo()
    {
        _canvasSelectPlayers.SetActive(false);
        _canvasMovementIntro2.SetActive(true);
    }
    */

    private void OnPlayButtonClick()        //This action is set in the OnClick, attached to previous button
    {
        _canvasMovementIntro1.SetActive(false);
        //_canvasMovementIntro2.SetActive(false);
        _canvasGameUI.SetActive(true);
        Time.timeScale = 1.0f;
    }
    
    private void PauseMenu()
    {
        Time.timeScale = 0f;
        _canvasGameUI.SetActive(false);
        _canvasPause.SetActive(true);

        //gameObject.GetComponent<CanvasAttribute>().enabled = true;
        //https://www.youtube.com/watch?v=Z3tO8FPCM_w
    }

    private void OnResume()
    {
        _canvasGameUI.SetActive(true);
        _canvasPause.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnQuitGame()
    {
        scenesManager.LoadNewGame();
    }
}
