using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GamesManager : MonoBehaviour
{
    [SerializeField] Button playerOne;
    //[SerializeField] Button playerTwo;
    
    public static GamesManager Instance;
    public GameState State;

    
    //public static event Action<GameState> OnGameStateChanged;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        UpdateGameState(GameState.SelectPlayers);
        //instantiate the cars
        //instantiate the the whole track?

    }

    private void Start()
    {
        
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.SelectPlayers:
                HandleSelectPlayers(); 
                break;
            case GameState.MovementIntroPlayerOne:
                break;
            case GameState.MovementIntroPlayerTwo:
                break;
            case GameState.CountDown:
                break;
            case GameState.GameModeState:
                break;
            case GameState.NextCourt:
                break;
            case GameState.ScoreBoard:
                break;
            case GameState.PauseState: 
                break;
            case GameState.ThanksForPlaying: 
                break;
            default:
                break; //throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        //OnGameStateChanged?.Inwoke(newState);

    }

    private void HandleSelectPlayers()
    {
        //mouse on klick "PlayerOne" -> Movement intro "Oneplayer specific"
        //mouse on klick "PlayerTwo" -> Movement intro "Twoplayer specific"

        //OnButtonClick.PlayerOne(HandleMovementIntroPlayerOne());
             
        //Same with player two

    }
    public void OnClick()
    {
        
    }

    private void HandleMovementIntroPlayerOne()
    {

    }

    private void HandleCountDown()
    {
        //Start a negative counter
    }



    public enum GameState
    {
        SelectPlayers,
        MovementIntroPlayerOne,
        MovementIntroPlayerTwo,
        CountDown,
        GameModeState,
        NextCourt,
        ScoreBoard,
        PauseState,
        ThanksForPlaying
    }
}
