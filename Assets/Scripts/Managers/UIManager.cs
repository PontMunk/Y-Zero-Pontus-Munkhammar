using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public ScenesManager scenesManager;
    public CanvasAttribute canvasSelectPlayers;
    
    [SerializeField] Button PlayerOne;
    //[SerializeField] Button playerTwo;

    [SerializeField] Button Play;

    [SerializeField] Button Resume;
    [SerializeField] Button QuitGame;



    private bool OnScene = true;

    /*
     * What do I need this to do?
     * Get the current Scene, to address what commands should be available
     * Enable them to the current scene
     * if other scene, disable/destroy the other UI's
     */

    private void Awake()
    {
        
    }
    void Start()
    {
        PlayerOne.onClick.AddListener(PlayerSelectOne);
    }

    private void PlayerSelectOne()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.CourtOne);
    }

    /*
    private void PlayerSelectTwo()
    {

    }
    */

    private void PauseMenu()
    { 
        
        Resume.onClick.AddListener(ScenesManager.Instance.UnPause);
        QuitGame.onClick.AddListener(ScenesManager.Instance.LoadNewGame);
        
    }
}
