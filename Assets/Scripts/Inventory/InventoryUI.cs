using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    // Necessary components loaded from Editor
    [SerializeField] private TMP_Text ItemName, ItemDescription;    // the two text boxes on the right for the item details
    [SerializeField] private Image ItemImage;                       // the image on the right that displays item icon
    [SerializeField] private SimpleItem NothingItem;                // an item with no information, used to reset
    [SerializeField] private GameObject ItemButtonPrefab;           // prefab that is instantiated for every item in inventory
    [SerializeField] private GameObject InventoryBox;               // box that holds all the buttons with item names
    [SerializeField] private Inventory Inventory;                   // reference to the inventory in the scene

    // UI state information
    private List<Button> CurrentItemButtons;                        // list of the current UI buttons in the inventory box
    private int CurrentItem = -1;                                   // index of the button that was last interacted with

    // Main behaviors of the UI
    public void AddItem(SimpleItem item)
    {
        Inventory.AddItem(item);
        GameObject newButtonObj = Instantiate(ItemButtonPrefab, InventoryBox.transform);

        // Writing the item name on the button
        TMP_Text buttonLabel = newButtonObj.GetComponentInChildren<TMP_Text>();
        buttonLabel.text = item.Name;

        // Adding an the OnClick listener to the new button to display the item's information
        Button button = newButtonObj.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            UpdateItemDetails(item);
        });
    }

    public void RemoveItem(int index)
    {
        Inventory.RemoveItem(index);

        // If the removed item is the item that is currently being shown, clear the screen
        if (CurrentItem == index)
        {
            CurrentItem = -1;
            UpdateItemDetails(NothingItem);
        }
    }

    public void SelectItem(int index)
    {
        CurrentItem = index;
        UpdateItemDetails(Inventory.GetItem(index));
    }
    // End of main behaviors of the UI

    // Helper function that will update the display with new item details
    private void UpdateItemDetails(SimpleItem item)
    {
        ItemName.text = item.Name;
        ItemDescription.text = item.Description;
        ItemImage.sprite = item.Icon;
    }
}
