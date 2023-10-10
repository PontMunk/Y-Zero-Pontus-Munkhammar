using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] GameObject uiManager;         //Don't even need this right? Why do I need the SM attached to ScenesManager object?
    
    public static ScenesManager _scenesManager;
    public static UIManager _uIManager;

    private void Awake()
    {
        _scenesManager = this;
    }
    
    /*      What should I destroy when the game ain't running/on QuitGema button?
    private void OnDestroy()
    {
        if (SceneManager.sceneCountInBuildSettings == 4);
    }
    */
    public enum Scene       //Creates a hierarchy to load from the BuildIndex...?
    {
        CourtOne,
        CourtTwo,
        CourtThree
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());       //what does this method even do?
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.CourtOne.ToString());
        //call OnDestroy?
        _uIManager.Awake();
        //Time.timeScale = 0f;        //This is done in the UIM, get rid of?
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        //Access the GameUI once more to get it working in the next scene
    }
}
