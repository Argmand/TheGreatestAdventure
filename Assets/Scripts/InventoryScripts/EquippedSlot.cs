using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EquippedSlot : MonoBehaviour, IPointerClickHandler
{
    //Slot Appearance//
    [SerializeField]
    private Image slotImage;

    [SerializeField]
    private TMP_Text slotName;

    [SerializeField]
    private Image playerDisplayImage;


    //Slot Data//
    [SerializeField]
    private ItemType itemType = new ItemType();

    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;

    private InventoryManager inventoryManager;

    //Other Variables//
    private bool slotInUse;

    [SerializeField]
    public GameObject selectedShader;

    [SerializeField]
    public bool thisItemSelected;

    [SerializeField]
    private Sprite emptySprite;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // On Left Click
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        // On Right Click
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    private void OnLeftClick() 
    {
        if (thisItemSelected && slotInUse)
        {
            UnEquipGear();
        }
        else 
        { 
            inventoryManager.DeSelectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
    }
    private void OnRightClick() 
    {
        UnEquipGear();
    }

    public void EquipGear(Sprite itemSprite, string itemName) 
    {
        // If something is already equiped, send back before re-writing the data for this slot 
        if (slotInUse)
        {
            UnEquipGear();
        }

        // Update Image
        this.itemSprite = itemSprite;
        slotImage.sprite = this.itemSprite;
        slotName.enabled = false;

        // Update Data
        this.itemName = itemName;

        // Update Display Image
        playerDisplayImage.sprite = itemSprite;

        slotInUse = true;
    }

    public void UnEquipGear() 
    {
        inventoryManager.DeSelectAllSlots();

        inventoryManager.AddItem(itemName, 1, itemSprite, itemDescription, itemType);
         
        // Update Slot Image
        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        slotName.enabled = true;

        playerDisplayImage.sprite = emptySprite;
    }
}
