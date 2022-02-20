using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Database
{
    public static List<Item> items;

    public static void InitItems()
    {
        items = new List<Item>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("");
        items.Add(new Tool(sprites[26], 1, "Hoe", GameStateHelper.ToolType.HOE));
        items.Add(new Tool(sprites[42], 2, "Pickaxe", GameStateHelper.ToolType.PICKAXE));
        items.Add(new Item(sprites[22], 20, "Diamond"));
        items.Add(new Item(sprites[21], 21, "Coin"));
    }
    public static Item ItemLookup(Sprite sprite)
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

    public static Item ItemLookup(string name)
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
