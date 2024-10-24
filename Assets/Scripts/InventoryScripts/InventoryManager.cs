using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject equipmentMenu;

    public ItemSlot[] itemSlot;
    public EquipmentSlot[] equipmentSlot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("InventoryMenu")) 
        {
            Inventory();
        }
        if (Input.GetButtonDown("EquipmentMenu"))
        {
            Equipment();
        }
    }

    void Inventory()
    {
        if (inventoryMenu.activeSelf)
        {
            Time.timeScale = 1;
            inventoryMenu.SetActive(false);
            equipmentMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            inventoryMenu.SetActive(true);
            equipmentMenu.SetActive(false);
        }
    }
    void Equipment()
    {
        if (equipmentMenu.activeSelf)
        {
            Time.timeScale = 1;
            inventoryMenu.SetActive(false);
            equipmentMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            inventoryMenu.SetActive(false);
            equipmentMenu.SetActive(true);
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        if (itemType == ItemType.collectable || itemType == ItemType.crafting || itemType == ItemType.consumable)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
                {
                    int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType);
                    }
                    return leftOverItems;
                }
            }
            return quantity;
        }
        else
        {
            for (int i = 0; i < equipmentSlot.Length; i++)
            {
                if (equipmentSlot[i].isFull == false && equipmentSlot[i].itemName == itemName || equipmentSlot[i].quantity == 0)
                {
                    int leftOverItems = equipmentSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemType);
                    }
                    return leftOverItems;
                }
            }
            return quantity;
        }

        
    }

    public void DeSelectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}

public enum ItemType
{
    None,
    collectable,
    crafting,
    consumable,
    mainHand,
    offHand,
};