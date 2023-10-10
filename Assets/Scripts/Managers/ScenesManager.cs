using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] GameObject _uiManager;
    

    public static ScenesManager Instance;
    public static UIManager uIManager;
    public static OldMovement oldmovement;
    public CanvasAttribute canvasPause;

    private bool isPaused = false;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;        //Must be set to 1f in the instance where the game starts, after every button selection
        
    }

    private void Start()
    {
        
    }

    public enum Scene       //Creates scenes too call?? Has to do with the BuildIndex?
    {
        CourtOne,
        CourtTwo,
        CourtThree
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());       //what does this method do?
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.CourtOne.ToString());
        //ref to MainMenu/Playerselect & stop gametime
        uIManager.PlayerSelectOne();
        Time.timeScale = 0f;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
