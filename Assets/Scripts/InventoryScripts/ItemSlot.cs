using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //===ITEM DATA===//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;


    [SerializeField]
    private int maxNummberOfItems;


    //===ITEM SLOT===//
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;


    //===Item Description Slot===//
    public Image itemDescriptionImg;
    public TMP_Text itemDescritionNameText;
    public TMP_Text itemDescriptionText;


    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        // Check if slot is already full
        if (isFull)
        {
            return quantity;
        }

        // Update the Name
        this.itemName = itemName;

        // Update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        // Update Description
        this.itemDescription = itemDescription;

        // Update Quantity
        this.quantity += quantity;
        if (this.quantity >= maxNummberOfItems)
        {
            quantityText.text = maxNummberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            // Return the lEFTOVERS
            int extraItems = this.quantity - maxNummberOfItems;
            this.quantity = maxNummberOfItems;
            return extraItems;
        }
        // Update Quantity Text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

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
        inventoryManager.DeSelectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        itemDescritionNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImg.sprite = itemSprite;

        if (itemDescriptionImg == null)
        {
            itemDescriptionImg.sprite = emptySprite;
        }
    }
    public void OnRightClick() { }
}

