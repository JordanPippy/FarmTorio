using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite icon;
    public Item item;
    public int count = 0;
    public void AddItem(Item item)
    {
        transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>()[0].sprite = item.sprite;
        this.item = item;
        count++;
    }

    public void ClearSlot()
    {
        transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>()[0].sprite = null;
        item = null;
        count = 0;
    }

}
