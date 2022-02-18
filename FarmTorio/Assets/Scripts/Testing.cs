using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    Inventory inventory;
    public Item item;
    void Start()
    {
        inventory = Inventory.instance;
        ItemLookup.InitItems();
        inventory.Add(ItemLookup.lookup("Hoe"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Testing1"))
        {
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
