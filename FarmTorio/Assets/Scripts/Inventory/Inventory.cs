using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

	public static Inventory instance;

	void Awake ()
	{
		instance = this;
        print("Inventory Singleton Created");
	}

	#endregion

    public class InternalItem
    {
        public Item item;
        public int count;
        public InternalItem(Item item)
        {
            this.item = item;
            count = 1;
        }
    }
    public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

    private int space = GameStateHelper.inventorySpace;

    public List<InternalItem> items = new List<InternalItem>();
    public bool Add(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item == item && items[i].count < GameStateHelper.maxItemStack)
            {
                items[i].count++;
                UpdateUI();
                return true;
            }
        }

        if (items.Count >= space)
        {
            print("Inventory full");
            return false;
        }

        items.Add(new InternalItem(item));

        UpdateUI();
        return true;
    }

    public void Remove(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item == item)
            {
                if (items[i].count == 1)
                {
                    items.RemoveAt(i);
                }
                else if (items[i].count > 1)
                    items[i].count--;
                break;
            }
        }

        UpdateUI();
    }

    public void Remove(int index)
    {
        if (items.Count > index)
        {
            if (items[index].count == 1)
                items.RemoveAt(index);
            else if (items[index].count > 1)
                items[index].count--;
            else
                return;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
