using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item
{
    // Start is called before the first frame update
    public Sprite sprite;
    public string title;
    public int id;

    public Item()
    {

    }

    public Item(Sprite sprite, int id, string name)
    {
        this.sprite = sprite;
        this.id = id;
        this.title = name;
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
