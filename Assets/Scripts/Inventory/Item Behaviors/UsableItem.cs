using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An example of how to add behaviors or functionality to items
// Inherits data from SimpleObject, but does not contain a specific
// implementation for Use(), since this is moreso a template for other
// objects to look back to.

// Note: Since this is an abstract class, I do not want to be able to make them in the Editor
public abstract class UsableItem : SimpleItem
{
    public abstract void Use();
}
