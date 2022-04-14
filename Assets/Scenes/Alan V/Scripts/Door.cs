using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{

    public int scene;

    public override void Interact()
    {
        SceneSwitch.instance.ChangeScene(scene);
    }

    
}





