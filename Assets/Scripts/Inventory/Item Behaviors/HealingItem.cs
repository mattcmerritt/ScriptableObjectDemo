using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Usable item implementation that will add health to the player when used.

[CreateAssetMenu]
public class HealingItem : UsableItem
{
    public int Health;

    public override void Use()
    {
        FindObjectOfType<InventoryUI>().AddPlayerHealth(Health);
    }
}
