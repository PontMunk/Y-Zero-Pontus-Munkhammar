using UnityEngine;
using TMPro;

public class Car : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lapText;

    public Rigidbody carRb;

    private int checkpoint;
    public int lap = 0;
    private float boost = 2f;
    private float trackDrag = 0f;
    private float grassDrag = 2f;
    //private float speed = 10f;                //TODO:Not needed in this script...BUT => If I can get the "current speed" from the movement script, I can manipulate this here.
    //private float carBumbForce = 2f;          //Would have liked to made this in an equation relative to the cars speed.

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "Grass")       //I'm I really usin physics? YES! But not friction/a physics material...But I'm!
        {
            carRb.drag = grassDrag;     
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
         * Can I write this in a loop? And get rid of the hard values?
         * checkpoint == currentcheckpoint? */
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
        if (trigger.gameObject.tag == "FinishLine" && checkpoint == 3 && lap == 3)      //TODO: call GamesManager, score/time, next court, at last scene -> go to scoreboard and Play Again
        {
            ScenesManager.scenesManager.LoadNextScene();
            Debug.Log("Goal!");
        }
        /*TODO, edit onto UIscript instead! This is where Magnus helped me with this quickfix
         * Would like to have this displayed on ingame UI. In best case attached to each player. */
        
        else if (trigger.gameObject.tag == "FinishLine" && checkpoint == 3)
        { 
            lap++;
            lapText.text = "Lap: " + lap.ToString() + "/4";        
            checkpoint = 0;                                        
            Debug.Log("Lap: " + lap);       
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if(trigger.gameObject.tag == "Grass")
        {
            carRb.drag = trackDrag;
            Debug.Log("Exited Grass");
        }
        if(trigger.gameObject.tag == "Boost")       //Take away the increased speed, In this state of the game not really needed.
        {
            //Over time, set speed to normal (create a normal/maxNormal)
            Debug.Log("Exited Boost");
        }
        if(trigger.gameObject.tag == "Reversed")    //TODO, don't know how to just yet. Should be able to reassign the keys in runtime with the input system
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
            //Debug.Log("You hit a Car!");
        }
    }
}
