using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemLookup
{
    public static List<Item> items;

    public static void InitItems()
    {
        items = new List<Item>();
        Item[] tempItems = Resources.LoadAll<Item>("Items/");
        for (int i = 0; i < tempItems.Length; i++)
            items.Add(tempItems[i]);

        tempItems = null; //No longer need reference to loaded resource.
    }
    public static Item lookup(Sprite sprite)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (sprite == items[i].sprite)
            {
                Debug.Log("HOLY FUCK WE FOUND IT");
                return items[i];
            }
        }
        return null;
    }

    public static Item lookup(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (name == items[i].title)
            {
                Debug.Log("HOLY FUCK WE FOUND IT");
                return items[i];
            }
        }
        return null;
    }
}
