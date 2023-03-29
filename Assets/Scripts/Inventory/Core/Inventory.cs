using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<SimpleItem> Items;

    public void AddItem(SimpleItem item)
    {
        Items.Add(item);
    }

    public SimpleItem GetItem(int index)
    {
        return Items[index];
    }

    public void UseItem(int index)
    {
        // To call Use(), we need to cast the reference to be UsableItem instead of SimpleItem
        // However, to be safe, we ensure that the item a UsableItem before casting
        if (Items[index] is UsableItem)
        {
            ((UsableItem)Items[index]).Use(); 
        }
        // If it isn't a UsableItem, then can't assume that it has a Use() method to call and can do nothing
    }

    public void RemoveItem(int index)
    {
        Items.RemoveAt(index);
    }
}
