using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventoryUI;
    public GameObject hotbar;
    public HotbarUI hotbarUI;
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
        {
            slots.Add(inventorySlots[i]);
            slots[i].index = i;
        }
        

        for (int i = 0; i < hotbar.transform.childCount; i++)
        {
            hotbarSlots.Add(hotbar.transform.GetChild(i).GetComponent<InventorySlot>());
            hotbarSlots[i].index = i;
        }

        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            GameStateHelper.UIOpen = inventoryUI.activeSelf ? false : true;

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



        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].MatchInventory();
        }
    }

    private void UpdateHotBar()
    {
        for (int i = 0; i < hotbarSlots.Count; i++)
        {
            hotbarSlots[i].MatchInventory();
        }

        hotbarUI.CheckActiveItem();
    }
}
