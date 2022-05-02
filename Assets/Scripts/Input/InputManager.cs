using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    //This is teh singleton
    public static InputManager instance;

    private Controls controls;

    public Vector2 move;
    
    public float moveAmount;

    public Vector2 look;

    public bool interact = false;

    public event InventoryKeyPressed OnInventoryKeyPressed;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        controls = new Controls();
        controls.Enable();
    }

    

    void Start()
    {
        //read in movement amounts and limit them.
        controls.Locomotion.Move.performed += controls =>
        {
            move = controls.ReadValue<Vector2>();
            moveAmount = Mathf.Clamp01(Mathf.Abs(move.x) + Mathf.Abs(move.y));
        };

        controls.Locomotion.Interact.performed += controls =>
        {
            Debug.Log("Pressed F");
            interact = true;
        };

        controls.Locomotion.Interact.canceled += controls => interact = false;

        controls.Locomotion.Inventory.performed += controls =>
        {
            OnInventoryKeyPressed?.Invoke();
        };

    }

    public delegate void InventoryKeyPressed();

    void OnDisable()
    {
        controls.Disable();
    }

}
