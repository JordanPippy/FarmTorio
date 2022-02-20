using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("UseItem"))
        {
            Item activeItem = HotbarUI.GetActiveItem();
            if (activeItem != null)
                activeItem.Use();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;
        Debug.Log(other.gameObject.tag);
        if (tag == "MinesTeleport")
        {
            player.transform.position = GameStateHelper.minesTeleportLocation;
        }
        else if (tag == "FarmTeleport")
        {
            player.transform.position = GameStateHelper.farmTeleportLocation;
        }
    }
}
