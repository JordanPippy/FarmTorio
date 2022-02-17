using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> slots;
    public Sprite defaultSlot, currentSlot;
    private int currentSlotIndex, lastSlotIndex;
    void Start()
    {
        currentSlotIndex = 0; lastSlotIndex = 0;
        slots = new List<GameObject>();

        GameObject temp = transform.GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < temp.transform.childCount; i++)
            slots.Add(temp.transform.GetChild(i).gameObject);

        slots[0].GetComponent<SpriteRenderer>().sprite = currentSlot;
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
        currentSlotIndex += 7;
        currentSlotIndex = currentSlotIndex % slots.Count;

        slots[lastSlotIndex].GetComponent<SpriteRenderer>().sprite = defaultSlot;
        slots[currentSlotIndex].GetComponent<SpriteRenderer>().sprite = currentSlot;

        lastSlotIndex = currentSlotIndex;
    }
}
