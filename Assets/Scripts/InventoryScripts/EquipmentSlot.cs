using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
    //===ITEM DATA===//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemType;

    private SpriteRenderer inGameMainHandSR, inGameOffHandSR, inGameCloackSR;

    //===ITEM SLOT===//
    [SerializeField]
    private Image itemImage;

    //===Equipped Slot===
    [SerializeField]
    private EquippedSlot mainHandSlot, offHandSlot, headSlot, bodySlot, relicSlot, feetSlot, cloackSlot, legsSlot;
    //public Image eqippedItemImg;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

        inGameMainHandSR = GameObject.Find("MainHand").GetComponent<SpriteRenderer>();
        inGameOffHandSR = GameObject.Find("OffHand").GetComponent<SpriteRenderer>();
        inGameCloackSR = GameObject.Find("Cloack").GetComponent<SpriteRenderer>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        // Check if slot is already full
        if (isFull)
        {
            return quantity;
        }

        // Update Item Type
        this.itemType = itemType;

        // Update Name
        this.itemName = itemName;

        // Update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = this.itemSprite; // Check

        // Update Description
        this.itemDescription = itemDescription;

        // Update Quantity
        this.quantity = 1;
        isFull = true;

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            EquipGear();
        }
        else
        {
            inventoryManager.DeSelectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
    }

    private void EquipGear()
    {
        if (itemType == ItemType.head)
        {
            headSlot.EquipGear(itemSprite, itemName);
        }
        if (itemType == ItemType.cloack)
        {
            cloackSlot.EquipGear(itemSprite, itemName);
            inGameCloackSR.sprite = itemSprite;
        }
        if (itemType == ItemType.body)
        {
            bodySlot.EquipGear(itemSprite, itemName);
        }
        if (itemType == ItemType.relic)
        {
            relicSlot.EquipGear(itemSprite, itemName);
        }
        if (itemType == ItemType.feet)
        {
            feetSlot.EquipGear(itemSprite, itemName);
        }
        if (itemType == ItemType.mainHand)
        {
            mainHandSlot.EquipGear(itemSprite, itemName);
            inGameMainHandSR.sprite = itemSprite;
        }
        if (itemType == ItemType.offHand)
        {
            offHandSlot.EquipGear(itemSprite, itemName);
            inGameOffHandSR.sprite = itemSprite;
        }
        if (itemType == ItemType.legs)
        {
            legsSlot.EquipGear(itemSprite, itemName);
        }

        EmptySlot();
    }

    private void EmptySlot()
    {
        itemImage.sprite = emptySprite;
        isFull = false;
    }

    public void OnRightClick() { }
}



