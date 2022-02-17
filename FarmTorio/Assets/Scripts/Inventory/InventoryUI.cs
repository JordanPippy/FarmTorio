using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventoryUI;
    private GameObject hotbar;
    private List<InventorySlot> hotbarSlots;

    Inventory inventory;
    private List<InventorySlot> slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = new List<InventorySlot>();
        hotbarSlots = new List<InventorySlot>();
        InventorySlot[] inventorySlots = GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < inventorySlots.Length; i++)
            slots.Add(inventorySlots[i]);
        
        hotbar = GameObject.FindWithTag("Hotbar");
        hotbar = hotbar.transform.GetChild(0).GetChild(0).gameObject;

        for (int i = 0; i < hotbar.transform.childCount; i++)
            hotbarSlots.Add(hotbar.transform.GetChild(i).GetComponent<InventorySlot>());

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
        UpdateHotBar();

        if (!inventoryUI.activeSelf)
            return;

        List<Item> items = inventory.items;


        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    private void UpdateHotBar()
    {
        List<Item> items = inventory.items;


        for (int i = 0; i < hotbarSlots.Count; i++)
        {
            if (i < inventory.items.Count)
            {
                hotbarSlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                hotbarSlots[i].ClearSlot();
            }
        }
    }
}
