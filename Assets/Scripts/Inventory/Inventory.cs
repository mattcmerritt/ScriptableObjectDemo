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

    public void RemoveItem(int index)
    {
        Items.RemoveAt(index);
    }
}
