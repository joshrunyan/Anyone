using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Data Item")]
public class InventoryDataItem : ScriptableObject
{
    public string id;
    public string DisplayName;
    public Sprite icon;
    public GameObject prefab;
}
