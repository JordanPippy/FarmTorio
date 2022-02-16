using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    private bool pickup;
    private bool canPickup;
    private float cooldownDuration = 0.1f;
    List<GameObject> nearbyItems;
    Inventory inventory;
    void Start()
    {
        pickup = false;
        canPickup = true;
        inventory = Inventory.instance;
        nearbyItems = new List<GameObject>();
        print("Pickup started");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Pickup"))
            pickup = true;
        else
            pickup = false;
    }

    public IEnumerator StartCooldown()
    {
        canPickup = false;
        yield return new WaitForSeconds(cooldownDuration);
        canPickup = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject itemObject = other.gameObject;

        if (itemObject.tag != "Pickup")
            return;
        
        nearbyItems.Add(itemObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        GameObject itemObject = other.gameObject;

        if (itemObject.tag != "Pickup")
            return;

        if (nearbyItems.Remove(itemObject))
        {
            Debug.Log("Moved too far away from item");
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "Pickup")
            return;


        Debug.Log("NearbyItems: " + nearbyItems.Count);
        Debug.Log("Pickup: " + pickup);
        if (pickup && canPickup)
        {
            if (nearbyItems.Count == 0)
                return;
            Item item = ItemLookup.lookup(nearbyItems[0].GetComponent<SpriteRenderer>().sprite);
            if (inventory.Add(item))
            {
                //nearbyItems.Remove(nearbyItems[0]);
                Destroy(nearbyItems[0]);
                StartCoroutine(StartCooldown());
            }
        }
    }

}
