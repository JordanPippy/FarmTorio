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
        Database.InitItems();
        inventory.Add(Database.ItemLookup("Hoe"));
        inventory.Add(Database.ItemLookup("Pickaxe"));
        item = Database.ItemLookup("Diamond");
        print("Added Hoe");
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
            if (HotbarUI.GetActiveItem() != null)
                inventory.Remove(HotbarUI.getActiveItemSlot());
                //inventory.Remove(HotbarUI.GetActiveItem());
        }
    }
}
