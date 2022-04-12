using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLocomotion : MonoBehaviour
{

    // A reference to the InputManager singleton
    private InputManager input;

    // A reference to the CharacterController to move the player
    private CharacterController controller;

    // A reference to the AnimatorHandler
    private AnimatorHandler animationHandler;

    // References to the camera rig
    
    public Transform cam;

    public Transform player;

    // Things for interactables
    [Header("Interactables")]
    public Transform head;
    public LayerMask interactableMask;
    public bool canInteract = false; 

    // Start is called before the first frame update
    void Start()
    {
        

        input = InputManager.instance;
        controller = GetComponent<CharacterController>();

        animationHandler = GetComponent<AnimatorHandler>();

        animationHandler.Initialize();
    }

    void Update()
    {
        HandleMovement(Time.deltaTime);
       

    }


    private void FixedUpdate()
    {
        CheckForInteractable();
    }

    /// <summary>
    /// Make the player move relative to the camera direction
    /// </summary>
    /// <param name="delta"></param>
    private void HandleMovement(float delta)
    {
        Vector3 movement = (input.move.x * cam.right) + (input.move.y * player.forward);

        controller.Move(movement * 5 * delta);
    }

    private void CheckForInteractable()
    {
        RaycastHit hit;

        canInteract = Physics.Raycast(head.position, head.forward, out hit, 3, interactableMask);

        if (canInteract)
        {
            //show prompt
        }

        if(canInteract && input.interact)
        {
            hit.collider.GetComponent<Interactable>().Interact();
        }

    }
    

}

   
    

