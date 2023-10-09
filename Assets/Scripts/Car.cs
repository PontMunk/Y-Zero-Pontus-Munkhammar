using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public static ScenesManager Scene;
    public static Car Instance;



    [SerializeField] OldMovement movementBehaviour;
    [SerializeField] private InputAction turnAction;

    

    public Rigidbody carRb;
    public BoxCollider FinishLine;
    private int checkpoint;
    private int lap = 0;
    private float speed = 10f;
    private float boost = 2f;
    private float trackDrag = 0f;
    private float grassDrag = 2f;
    private float carBumbForce = 2f; //would have liked to made this in an equation relative to the cars speed.

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        FinishLine = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        //Debug.Log(speed); //Speedcheck
    }

    public void StartRebinding()
    {
        turnAction.PerformInteractiveRebinding();
    }

    void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Grass")
        {
            Debug.Log("Entered Grass");
            carRb.drag = grassDrag;     //I'm I really usin physics? YES! But not friction/a physics material
        }

        if (trigger.gameObject.tag == "Boost")
        {
            carRb.AddForce(transform.forward * boost, ForceMode.Impulse);
            Debug.Log("Entered Boost");
        }

        if (trigger.gameObject.tag == "Reversed")
        {
            // Inwoke the reversed stearing a=d & -> = <-
            //Ribinding in runtime https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/ActionBindings.html#runtime-rebinding
            
            
            /*
            public InputActionReference triggerAction;
            void ChangeBinding()
            {
                InputBinding binding = triggerAction.action.bindings[0];
                binding.overridePath = "<Keyboard>/#(g)";
                triggerAction.action.ApplyBindingOverride(0, binding);
            }
            */
            Debug.Log("Entered Reversed");
        }

        //Checkpoints   //I konw that there is a much more efficient way to do this, this makes it easy for me.
        if(trigger.gameObject.tag == "Checkpoint")
        {
            if(checkpoint == 0)
            {
                checkpoint++;
                Debug.Log("Checkpoint: " +checkpoint);
            }
        }
        if(trigger.gameObject.tag == "Checkpoint2")
        {
            if(checkpoint == 1)
            {
                checkpoint++;
                Debug.Log("Checkpoint: " + checkpoint);
            }
        }
        if(trigger.gameObject.tag == "Checkpoint3")
        {
            if(checkpoint == 2)
            {
                checkpoint++;
                Debug.Log("Checkpoint: " + checkpoint);
            }
        }

        // Lap check
        if (trigger.gameObject.tag == "FinishLine" && checkpoint == 3 && lap == 3) //Goalcheck
        {
            //call GamesManager, score/time, next court
            //onClick "Continue" -> LoadNextScene();
            ScenesManager.Instance.LoadScene(ScenesManager.Scene.CourtTwo);
            Debug.Log("Goal!");
        }
        else if (trigger.gameObject.tag == "FinishLine" && checkpoint == 3)
        {
            lap++;
            checkpoint = 0;
            Debug.Log("Lap: " + lap);
        }

        /*
        checkpoint = 0;
        switch(trigger.gameObject.tag == "FinishLine")
        {
            case checkpoint = 1: lap++; break;
        
            case trigger.gameObject.tag == "FinishLine" && checkpoint != 3)
        {
            //Put a message to the GUI "Move through all the checkpoints before finishing a lap"
        }
        */
    }

    private void OnTriggerExit(Collider trigger)
    {
        if(trigger.gameObject.tag == "Grass")
        {
            carRb.drag = trackDrag;//Remove the slowdown effect/ status normal
            Debug.Log("exited Grass");
        }
        if(trigger.gameObject.tag == "Boost")
        {
            //Take away the increased speed     //Really needed?
        }
        if(trigger.gameObject.tag == "Reversed")
        {
            //Revert the turn back
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Wall")
        {
            //Redirect, reflect the rotation ... or something
            //Debug.Log("hit wall");
        }
        if (collision.gameObject.tag == "Car")
        {
            //carRb.GetComponent<Transform>().position = carRb.AddForce(transform.position * carBumbForce);
            //carRb.AddForce(-transform.position * speed * carBumbForce); //do I need to disable the "move forward function"?
            //carRb.AddForce(-Vector3.up * carBumbForce, ForceMode.Impulse);
            Debug.Log("Bump!");
        }
    }
}
