using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item
{
    // Start is called before the first frame update
    public Sprite sprite;
    public string title;
    public int id;

/*
    public static Item CreateInstance()
    {
        return ScriptableObject.CreateInstance<Item>();
    }
    public static Item CreateInstance(Sprite sprite, int id, string name)
    {
        Item item = ScriptableObject.CreateInstance<Item>();
        item.sprite = sprite;
        item.id = id;
        item.title = name;
        return item;
    }
*/
    public Item()
    {

    }

    public Item(Sprite sprite, int id, string name)
    {
        this.sprite = sprite;
        this.id = id;
        this.title = name;
        Debug.Log(this.sprite);
    }

    public virtual void Use()
    {
        Debug.Log("Base Use Active Item: " + HotbarUI.GetActiveItem());
    }

    public override string ToString()
    {
        return this.title;
    }
}
