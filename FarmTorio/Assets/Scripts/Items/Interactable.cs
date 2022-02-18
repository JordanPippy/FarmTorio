using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public Item item;
    public bool canPickup;
    void Start()
    {
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
