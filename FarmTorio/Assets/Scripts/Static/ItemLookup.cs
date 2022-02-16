using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemLookup
{
    public static List<Item> items;

    public static void initItems()
    {
        items = new List<Item>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("GUI");

        items.Add(Item.CreateInstance(sprites[21], 1, "Coin"));
        Debug.Log("All items /loaded/");
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
}
