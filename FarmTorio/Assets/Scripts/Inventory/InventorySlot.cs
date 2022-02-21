using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite icon;
    public Item item;
    private Image itemDisplayImage;
    //private TextMeshPro itemCountText;
    private TextMeshProUGUI itemCountText;
    private Inventory inventory;
    public int index;
    void Start()
    {
        inventory = Inventory.instance;
        itemDisplayImage = transform.GetChild(0).GetComponent<Image>();
        itemCountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemCountText.SetText("");
        itemDisplayImage.enabled = false;
    }

    public void MatchInventory()
    {
        if (itemDisplayImage == null)
            itemDisplayImage = transform.GetChild(0).GetComponent<Image>();
        if (itemCountText == null)
            itemCountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        Debug.Log(index);
        if (inventory.items.Count > index)
        {
            this.item = inventory.items[index].item;
            itemDisplayImage.enabled = true;
            itemDisplayImage.sprite = item.sprite;
            itemCountText.SetText("" + inventory.items[index].count);
        }
        else
        {
            this.item = null;
            itemDisplayImage.sprite = null;
            itemCountText.SetText("");
            itemDisplayImage.enabled = false;
        }
    }
    public void AddItem(Item item)
    {
        if (itemDisplayImage == null)
        {
            Debug.Log("Yep, im null.");
            itemDisplayImage = transform.GetChild(0).GetComponent<Image>();
        }
        if (itemCountText == null)
        {
            itemCountText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }

        itemDisplayImage.enabled = true;
        itemDisplayImage.sprite = item.sprite;
        this.item = item;
        //itemCountText.SetText("" + inventory.itemCounts[item]);
    }

    public void ClearSlot()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = null;
        item = null;
        itemCountText.SetText("");
        transform.GetChild(0).GetComponent<Image>().enabled = false;
    }

}
