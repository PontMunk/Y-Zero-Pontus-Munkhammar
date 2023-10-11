using UnityEngine;
using UnityEngine.InputSystem;

public class OldMovement : MonoBehaviour
{
    //[SerializeField] InputAction moveAction;  Sebastians suggestion, where you'll have to bind each key
    //[SerializeField] InputAction turnAction;

    public static UIManager uiManager;
    public Rigidbody carRb;

    private float speed = 10f;
    private float turnSpeed = 0.5f;
    private float driftSpeed = 3f;
    
    private float thrust;
    private float turn;
    private float drift;
    private bool isDrifting = false;
    private float pause = 1.0f;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        uiManager = FindAnyObjectByType<UIManager>();       //To manage the Pause Menu below
    }

    void FixedUpdate()
    {
        Thrust(thrust * Time.fixedDeltaTime);       // is this * Time.fixedDeltaTime neccessary?
        Turn(turn * Time.fixedDeltaTime);
    }

    public void OnThrust(InputAction.CallbackContext context)
    {
        thrust = context.ReadValue<float>();
        //Debug.Log(thrust);
    }

    public void Thrust(float _thrust)       /* This comes with disadvantages. You can't, in an easy and natural way, transform the car backwards when collision-bumb
                                             * Backspeed == Forward speed
                                             * When speed boost, only in forward direction
                                             */
    {
        if(_thrust > 0)        //hardcoded from the value that the player input gives. Is this ok? There should be a way around it!
        {
            carRb.AddForce(transform.forward * speed);      
        }
        else if(_thrust < 0)
        {
            carRb.AddForce(-transform.forward * speed);
        }
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        turn = context.ReadValue<float>();
        //Debug.Log(turn);
    }

    public void Turn(float _turn)
    {
        if(_turn > 0)        //Normal Turn
        {
            transform.Rotate(Vector3.up, turnSpeed);
        }
        else if(_turn < 0)
        {
            transform.Rotate(Vector3.up, -turnSpeed);
        }
        
        if(_turn > 0 && isDrifting == true)     //Drifting Turn
        {
            transform.Rotate(Vector3.up, turnSpeed * driftSpeed);
        }
        else if (_turn < 0 && isDrifting == true)
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

    public void Pause(InputAction.CallbackContext context)      /* This Mehmet helped me with by not checkinf for the 0 value, 
                                                                 * and by resuming the pause in the same way that the UI buttons work
                                                                 * TODO: When pausing and resuming more than once, the resumebutton don't reset as it should */
    {                                                           
        pause = context.ReadValue<float>();                    
        if (pause == 1)
        {
            uiManager.PauseMenu();
            Debug.Log("Game Paused");
        }
    }
}
