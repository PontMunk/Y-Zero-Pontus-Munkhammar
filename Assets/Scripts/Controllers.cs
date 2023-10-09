using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
[CreateAssetMenu(menuName = "InputReader")]
public class Controllers : ScriptableObject//, PlayerInputs.IPlayerOneActions, PlayerInputs.IPlayerTwoActions
{
    //https://www.youtube.com/watch?v=ZHOWqF-b51k

    public PlayerInputs playerOneControls;
    private InputAction move;
    private InputAction rotate;
    private InputAction pause;

    
    public PlayerInput playerTwoControls;
    private InputAction _move;
    private InputAction _rotate;
    private InputAction _pause;

    private void OnEnable()
    {
        move.Enable();
        rotate.Enable();
        pause.Enable();
        if (playerOneControls == null) //is this where I should connect the UI on select amount of player button?
        {
            playerOneControls = new PlayerInputs();

            //playerOneControls.PlayerOne.SetCallbacks(this); //Call Movement methods

        }
        if (playerTwoControls != null)
        {
            playerTwoControls = new PlayerInput();

            //playerTwoControls.PlayerTwo.SetCallbacks(this);
        }
    }

    //Here is where the actuall move functions calculations can be done.

    private void OnDisable()
    {
        move.Disable();
        rotate.Disable();
        pause.Disable();
    }

    //Own API
    public event Action<Vector2> MoveEvent;
    public event Action<Vector2> RotateEvent;

    public event Action PauseEvent;


    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log($"phase {context.phase}, Velue {context.ReadValue<Vector2>()}");
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        //Call Rotate(); function
        //If "space or 0" is pressed call driftfunction
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        //Call pause function to enter PausState
        //Disable any MovementActions(PlayerOne & Two inputactions
        //Enable UI Actions, aka MouseActions

        //OnMouseklick.Resume => Call a delay and the GamePlayState => Enable player inputactions 
    }
}
*/