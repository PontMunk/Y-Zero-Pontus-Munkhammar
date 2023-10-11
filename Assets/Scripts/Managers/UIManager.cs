using UnityEngine;

public class UIManager : MonoBehaviour
{
    //Multiplayeroptions keept in Unity, TODO! - Enable instantioation of a second player etc.
    [SerializeField] GameObject _canvasMainMenu;
    [SerializeField] GameObject _buttonPlayersOne;

    [SerializeField] GameObject _canvasMovementMenu;
    [SerializeField] GameObject _playButton;

    [SerializeField] GameObject _canvasGameUI;

    [SerializeField] GameObject _canvasPause;
    [SerializeField] GameObject _resume;
    [SerializeField] GameObject _quitGame;

    public static ScenesManager scenesManager;

    public void Awake()
    {
        Time.timeScale = 0f;
        MainMenu();
    }

    public void Start()
    {
        scenesManager = FindAnyObjectByType<ScenesManager>();
    }

    public void OnDestroy()     //What should go in this, What should go in DontDestroyOnLoad
    {
        MainMenu();
        ToMovementMenu();
    }

    public void MainMenu()
    {
        _canvasMainMenu.SetActive(true);
    }

    public void ToMovementMenu()            //TODO: Include a "back and forth-button"
    {
        _canvasMainMenu.SetActive(false);
        _canvasMovementMenu.SetActive(true);
    }

    public void OnPlayButtonClick()
    {
        _canvasMovementMenu.SetActive(false);
        _canvasGameUI.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void PauseMenu()
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
