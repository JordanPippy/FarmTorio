using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventoryUI;

    Inventory inventory;
    private List<InventorySlot> slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = new List<InventorySlot>();
        InventorySlot[] inventorySlots = GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < inventorySlots.Length; i++)
            slots.Add(inventorySlots[i]);

        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if (inventoryUI.activeSelf)
                UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (!inventoryUI.activeSelf)
            return;

        
        List<Item> items = inventory.items;


        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.items.Count)
                slots[i].AddItem(inventory.items[i]);
            else
                slots[i].ClearSlot();
                //slots[i].transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>()[0].sprite = items[i].sprite;
        }
    }
}
