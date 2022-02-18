using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Item")]
public class Item : ScriptableObject
{
    // Start is called before the first frame update
    public Sprite sprite;
    public string title;
    public int id;

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

    public virtual void Use()
    {
        Debug.Log("Base Use Active Item: " + HotbarUI.GetActiveItem());
    }
}
