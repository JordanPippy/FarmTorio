using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> slots;
    public Sprite defaultSlot, currentSlot;
    private static int currentSlotIndex, lastSlotIndex;

    private static Item activeItem;
    public static bool awake = false;
    public GameObject grid;
    void Start()
    {
        currentSlotIndex = 0; lastSlotIndex = 0;
        slots = new List<GameObject>();

        for (int i = 0; i < grid.transform.childCount; i++)
            slots.Add(grid.transform.GetChild(i).gameObject);

        slots[0].GetComponent<Image>().sprite = currentSlot;
        print("Hotbar init");
    }

    // Update is called once per frame
    void Update()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        

        if (mouseWheel != 0)
        {
            currentSlotIndex += mouseWheel > 0 ? 1 : -1;
            MoveCurrentSlot();
        }
    }

    private void MoveCurrentSlot()
    {
        currentSlotIndex += GameStateHelper.inventorySpace;
        currentSlotIndex = currentSlotIndex % slots.Count;

        slots[lastSlotIndex].GetComponent<Image>().sprite = defaultSlot;
        slots[currentSlotIndex].GetComponent<Image>().sprite = currentSlot;

        CheckActiveItem();

        lastSlotIndex = currentSlotIndex;
    }

    public void CheckActiveItem()
    {
        activeItem = slots[currentSlotIndex].GetComponent<InventorySlot>().item;
    }

    public static int getActiveItemSlot()
    {
        return currentSlotIndex;
    }

    public static Item GetActiveItem()
    {
        return activeItem;
    }
}
