using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody carRb;
    private float rotationDegrees = 0.5f;
    private float drift = 3f;
    private float speed = 10f;
    
    void Start()
    {
        carRb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //remember to add Time.deltaTime in the right places!
        if (Keyboard.current.upArrowKey.isPressed)
        {
            carRb.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            carRb.AddForce(-transform.forward * speed);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            transform.Rotate(Vector3.up, -rotationDegrees); //Source: https://www.youtube.com/watch?v=rKGsELBgpQY&t=32s
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            transform.Rotate(Vector3.up, rotationDegrees);
        }

        // + Buttom to Drift  // This function I made myself to get a little more depth in the stearing
        if (Keyboard.current.leftArrowKey.isPressed && Keyboard.current.numpad0Key.isPressed) 
        {
            transform.Rotate(Vector3.up, -rotationDegrees * drift);
        }
        if (Keyboard.current.rightArrowKey.isPressed && Keyboard.current.numpad0Key.isPressed)
        {
            transform.Rotate(Vector3.up, rotationDegrees * drift);
        }
    }
}

