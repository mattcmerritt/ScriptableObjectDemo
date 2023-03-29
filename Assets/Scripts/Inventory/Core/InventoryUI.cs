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
    private List<Button> CurrentItemButtons = new List<Button>();   // list of the current UI buttons in the inventory box
    private int CurrentButton = -1;                                 // index of the button that was last interacted with

    // Player stats information for second demo
    [SerializeField] private TMP_Text StatsBox;                     // the textbox with the player stats
    private int Health = 100, Attack = 10;

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
        int itemIndex = CurrentItemButtons.Count;
        button.onClick.AddListener(() =>
        {
            SelectItem(itemIndex);
        });
        CurrentItemButtons.Add(button);
    }

    public void SelectItem(int index)
    {
        CurrentButton = index;
        UpdateItemDetails(Inventory.GetItem(index));
    }

    public void UseCurrentItem()
    {
        if (CurrentButton != -1)
        {
            Inventory.UseItem(CurrentButton);
            RemoveItem(CurrentButton);
        } 
    }

    public void RemoveItem(int index)
    {
        Inventory.RemoveItem(index);

        // If the removed item is the item that is currently being shown, clear the screen
        if (CurrentButton == index)
        {
            CurrentButton = -1;
            UpdateItemDetails(NothingItem);
        }
        // If the item was added to the inventory after this item, adjust the CurrentButton counter to match it again
        else if (CurrentButton > index)
        {
            CurrentButton--;
        }

        // removing the last button from the list of active buttons and deleting it from the game
        Button removed = CurrentItemButtons[CurrentItemButtons.Count - 1];
        CurrentItemButtons.RemoveAt(CurrentItemButtons.Count - 1);
        Destroy(removed.gameObject);

        // relabeling all the buttons again to make them line up with inventory again
        for (int i = 0; i < CurrentItemButtons.Count; i++)
        {
            TMP_Text buttonLabel = CurrentItemButtons[i].GetComponentInChildren<TMP_Text>();
            buttonLabel.text = Inventory.GetItem(i).Name;
        }
    }
    // End of main behaviors of the UI

    // Player control methods
    public void AddPlayerAttack(int attack)
    {
        Attack += attack;
        UpdatePlayerUI();
    }

    public void AddPlayerHealth(int health)
    {
        Health += health;
        UpdatePlayerUI();
    }

    public void UpdatePlayerUI()
    {
        StatsBox.text = $"Health: {Health}\nAttack: {Attack}";
    }
    // End of player control methods

    // Helper function that will update the display with new item details
    private void UpdateItemDetails(SimpleItem item)
    {
        ItemName.text = item.Name;
        ItemDescription.text = item.Description;
        ItemImage.sprite = item.Icon;
    }
}
