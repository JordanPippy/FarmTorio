using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory inventory;
    private Item item;
    public Sprite icon;
    void Start()
    {
        inventory = Inventory.instance;
        ItemLookup.initItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Testing1"))
        {
            item = ScriptableObject.CreateInstance<Item>();
            item.id = 42;
            item.sprite = icon;
            inventory.Add(item);
        }
        if (Input.GetButtonDown("Testing2"))
        {
            print("testing2");
            if (inventory.items.Count > 0)
                inventory.Remove(inventory.items[0]);
        }
    }
}
