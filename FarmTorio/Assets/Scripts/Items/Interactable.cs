using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public string itemName;
    public Item item;
    public bool canPickup;
    void Start()
    {
        item = Database.ItemLookup(itemName);
        if (item == null)
            return;
        
        if (canPickup)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = item.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
