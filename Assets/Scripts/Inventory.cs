using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static bool InventoryIsOpen = false;

    public GameObject InventoryUI;

    public int item;

    private void Start()
    {
        close();
        InputManager.instance.OnInventoryKeyPressed += () =>
        {
            if (!InventoryIsOpen)
            {
                open();
            } else
            {
                close();
            }
        };
    }

    void Update()
    {

       
    }

    public void close()
    {
        InventoryUI.SetActive(false);
        Time.timeScale = 1f;
        InventoryIsOpen = false;
    }

    public void open()
    {
        InventoryUI.SetActive(true);
        Time.timeScale = 0f;
        InventoryIsOpen = true;
    }
}
