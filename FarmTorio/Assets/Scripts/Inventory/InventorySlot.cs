using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite icon;
    public Item item;
    public int count = 0;
    private Image itemDisplayImage;
    void Start()
    {
        itemDisplayImage = transform.GetChild(0).GetComponent<Image>();
        itemDisplayImage.enabled = false;
    }
    public void AddItem(Item item)
    {
        if (itemDisplayImage == null)
        {
            Debug.Log("Yep, im null.");
            itemDisplayImage = transform.GetChild(0).GetComponent<Image>();
        }
        itemDisplayImage.enabled = true;
        itemDisplayImage.sprite = item.sprite;
        this.item = item;
        count++;
    }

    public void ClearSlot()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = null;
        item = null;
        count = 0;

        transform.GetChild(0).GetComponent<Image>().enabled = false;
    }

}
