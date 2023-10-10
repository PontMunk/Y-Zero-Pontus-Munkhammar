using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class OldMovement : MonoBehaviour
{
    //[SerializeField] InputAction moveAction;  Sebastians suggestion, where you'll have to bind each key
    //[SerializeField] InputAction turnAction;

    public static GamesManager _gamesManager;

    private float speed = 10f;
    private float turnSpeed = 0.5f;
    private float driftSpeed = 3f;
    

    private float thrust;
    private float turn;
    private float drift;
    private bool isDrifting = false;
    private float _pause = 1.0f;

    public Rigidbody oldCarRb;

    void Start()
    {
        oldCarRb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        Thrust(thrust * Time.fixedDeltaTime); // is this neccessary?
        Turn(turn * Time.fixedDeltaTime);
    }

    public void OnThrust(InputAction.CallbackContext context)
    {
        thrust = context.ReadValue<float>();
        //Debug.Log(m_thrust);
    }

    public void Thrust(float m_thrust)
    {
        if(m_thrust > 0) //hardcoded from the value that the player input gives. Is this ok?
        {
            oldCarRb.AddForce(transform.forward * speed);   
            /*
             * This comes with disadvantages. They are: 
             * You can't, in an easy and natural way, transform the car backwards when collision-bumb 
             * ...
             */
        }
        else if(m_thrust < 0)
        {
            oldCarRb.AddForce(-transform.forward * speed);
        }
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        turn = context.ReadValue<float>();
        //Debug.Log(turn);
    }

    public void Turn(float m_turn)
    {
        //Normal Turn
        if(m_turn > 0)
        {
            transform.Rotate(Vector3.up, turnSpeed);
        }
        else if(m_turn < 0)
        {
            transform.Rotate(Vector3.up, -turnSpeed);
        }
        
        //Drifting Turn
        if(m_turn > 0 && isDrifting == true)
        {
            transform.Rotate(Vector3.up, turnSpeed * driftSpeed);
        }
        else if (m_turn < 0 && isDrifting == true)
        {
            transform.Rotate(Vector3.up, -turnSpeed * driftSpeed);
        }
    }

    public void Drift(InputAction.CallbackContext context)      //To check weather the Drift button is pressed or not
    {
        drift = context.ReadValue<float>();
        
        if(drift == 0)
        {
            isDrifting = false;
        }
        else
        {
            isDrifting = true;
        }
        //Debug.Log(isDrifting);
    }

    public void Pause(InputAction.CallbackContext context)      //https://www.youtube.com/watch?v=9dYDBomQpBQ tip on pausemenu
    {
        _pause = context.ReadValue<float>();
        if (_pause == 1)
        {
            //GamesManager.Instance == PauseState;
            //ScenesManager.Instance.LoadPause();
            Debug.Log("Game Paused");
        }
        if(_pause == 0)
        {
            //ScenesManager.Instance.UnPause();
            Debug.Log("Game Resumed");
        }


        /* Can I work around this problem?
         * press 1 to pause
         * if on pause -> use Mouse.current.leftButton.wasReleasedThisFrame -> to quit maybe? and 1 again to unpause
         */

    }

}
