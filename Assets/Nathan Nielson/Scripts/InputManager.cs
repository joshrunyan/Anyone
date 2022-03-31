using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    //This is teh singleton
    public static InputManager instance;

    private Controls controls;

    public Vector2 move;
    public Vector2 look;

    public float moveAmount;

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

    void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        //read in movement amounts and limit them.
        controls.Locomotion.Move.performed += controls =>
        {
            move = controls.ReadValue<Vector2>();
            moveAmount = Mathf.Clamp01(Mathf.Abs(move.x) + Mathf.Abs(move.y));
        };


        // read in camera look amounts
        controls.Locomotion.Look.performed += controls => look = controls.ReadValue<Vector2>();

    }

}
