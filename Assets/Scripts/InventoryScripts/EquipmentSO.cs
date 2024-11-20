using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemData", order = 1)]
public class EquipmentSO : ScriptableObject
{
    public enum ItemID
    {
        Lantern,
        MossyAxe,
        PlantSeed,
        FeatherCloack,
    }

    public ItemID id;
    public string itemName;
    //public GameObject itemPrefab;
}
