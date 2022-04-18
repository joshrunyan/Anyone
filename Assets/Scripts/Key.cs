using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public bool pickUp = false;


    public override void Interact()
    {
        pickUp = true;
    }
}
