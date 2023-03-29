using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Usable item implementation that will add attack to the player when used.

[CreateAssetMenu]
public class OffenseItem : UsableItem
{
    public int Attack;

    public override void Use()
    {
        FindObjectOfType<InventoryUI>().AddPlayerAttack(Attack);
    }
}
