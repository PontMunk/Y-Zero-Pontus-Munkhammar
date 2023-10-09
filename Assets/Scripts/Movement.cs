using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    [SerializeField] InputActionReference rotationInput;
    [SerializeField] InputActionReference moveInput;
    [SerializeField] InputActionReference driftInput;
    [SerializeField] InputActionReference pauseAction;

    [SerializeField] public float speed = 10f;
    [SerializeField] public float rotationSpeed = 3f;
    
    private bool isDrifting = false;
    private float driftRotationSpeed = 3f;
    private bool isPaused = false;


    public PlayerInput playerInput;
    public Rigidbody carRb;
    public float movement;
    private Vector2 rotation;

    
    public StatesManager stateManager;



    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
       //rotationInput.Disable();  //When InputAction
    }
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        carRb = GetComponent<Rigidbody>();
        //rotationInput.Enable();  //when InputAction
    }
    void FixedUpdate()
    {
        
    }

    public void OnMove()
    {
        Debug.Log(movement);
    }
    public void Move(InputAction.CallbackContext context)
    {
        //carRb.AddForce(transform.forward * speed, ForceMode.Acceleration);  // old
        carRb.AddForce(transform.forward * speed);
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        rotation = context.ReadValue<Vector2>() * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, -rotationSpeed);
        Debug.Log(rotation);
    }
    
}
