using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An example of how to make an Item ScriptableObject
// This class will contain all of the information that we need
// in order to show an item in the inventory

[CreateAssetMenu] // tells Unity to add Item as an option to the "Create" dropdown in the Editor
public class SimpleItem : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    [TextArea(5, 10)]   // gives us a larger textbox in the Inspector that is 5-10 lines long
    public string Description;
}
