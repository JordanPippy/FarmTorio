using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("UseItem"))
        {
            Item activeItem = HotbarUI.GetActiveItem();
            if (activeItem == null)
                return;
            activeItem.Use();
        }
    }
}
