using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class Car : MonoBehaviour
{
    public static ScenesManager _scenesManager;
    public static UIManager _uiManager;
    public static Car Instance;     //Why this?

    [SerializeField] TextMeshProUGUI lapText;

    public Rigidbody carRb;

    private int checkpoint;
    public int lap = 0;
    private float boost = 2f;
    private float trackDrag = 0f;
    private float grassDrag = 2f;
    //private float speed = 10f;        //Not needed in this script...BUT => If I can get the "current speed" from the movement script, I can manipulate this here.
    //private float carBumbForce = 2f;  //would have liked to made this in an equation relative to the cars speed.

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }

    private void Update()       //Needed?
    {
        //Debug.Log(speed); //Speedcheck
    }

    /*
    public void StartRebinding()
    {
        turnAction.PerformInteractiveRebinding();       //For Reversed?? cansleout
    }
    */

    void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Grass")
        {
            carRb.drag = grassDrag;     //I'm I really usin physics? YES! But not friction/a physics material...But I'm!
            Debug.Log("Entered Grass");
        }
        if (trigger.gameObject.tag == "Boost")
        {
            carRb.AddForce(transform.forward * boost, ForceMode.Impulse);
            Debug.Log("Entered Boost");
        }
        if (trigger.gameObject.tag == "Reversed")       /* TODO: Inwoke the reversed stearing a=d & -> = <-
                                                         * Ribinding in runtime https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/ActionBindings.html#runtime-rebinding */
        {
            Debug.Log("Entered Reversed");
        }

        //Checkpoints   
        /* I konw that there should be a more efficient way to do this, this makes it easy for me for now.
         * TODO: Don't use different tags for each chekcpoint, But do create some sort of list or order.
         * Can I write this in a loop? And get rid of the hard values? */
        if (trigger.gameObject.tag == "Checkpoint")          
        {
            if (checkpoint == 0)
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

        // LapCounter
        if (trigger.gameObject.tag == "FinishLine" && checkpoint == 3 && lap == 3) //Goalcheck  //TODO: call GamesManager, score/time, next court
        {
            ScenesManager._scenesManager.LoadNextScene();
            Debug.Log("Goal!");
        }
        else if (trigger.gameObject.tag == "FinishLine" && checkpoint == 3)
        {
            lap++;
            lapText.text = "Lap: " + lap.ToString() + "/4";        //TODO, edit onto UIscript
            checkpoint = 0;
            Debug.Log("Lap: " + lap);       //Would like to have this displayed on ingame UI. In best case attached to each player.
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if(trigger.gameObject.tag == "Grass")
        {
            carRb.drag = trackDrag;     //Removes the slowdown effect/ status normal
            Debug.Log("Exited Grass");
        }
        if(trigger.gameObject.tag == "Boost")
        {
            //Take away the increased speed, In this state of the game not really needed.
        }
        if(trigger.gameObject.tag == "Reversed")    //This is currently not working, TODO
        {
            //Revert the turn back
            Debug.Log("Exited Reversed");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Wall")     // TODO: Rotate playe in a "physics kind of way"
        {
            //Debug.Log("You hit a wall!");
        }
        if (collision.gameObject.tag == "Car")      // TOD: This is where the "bump-into-car-effect" should go, right?
        {
            //carRb.GetComponent<Transform>().position = carRb.AddForce(transform.position * carBumbForce);
            //carRb.AddForce(-transform.position * speed * carBumbForce); //do I need to disable the "move forward function"?
            //carRb.AddForce(-Vector3.up * carBumbForce, ForceMode.Impulse);

            //Debug.Log("You hit a Car!");
        }
    }
}
