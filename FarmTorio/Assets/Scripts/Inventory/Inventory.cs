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
        init();
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

        public InternalItem()
        {
            this.item = null;
            count = 0;
        }
    }
    public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

    //public List<InternalItem> items = new List<InternalItem>();
    public InternalItem[] items = new InternalItem[GameStateHelper.inventorySpace];
    public static int numberOfItems = 0;
    public bool Add(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item == item && items[i].count < GameStateHelper.maxItemStack)
            {
                items[i].count++;
                UpdateUI();
                return true;
            }
        }

        if (numberOfItems >= GameStateHelper.inventorySpace)
        {
            print("Inventory full");
            return false;
        }

        AddItem(item);
        numberOfItems++;

        UpdateUI();
        return true;
    }

    private void AddItem(Item item)
    {
        for (int i = 0; i < GameStateHelper.inventorySpace; i++)
        {
            if (items[i].item == null)
            {
                items[i].item = item;
                items[i].count = 1;
                break;
            }
        }
    }

    private void RemoveItem(int index)
    {
        items[index].item = null;
        items[index].count = 0;
        numberOfItems--;
    }

    public void Remove(Item item)
    {
        if (item == null)
            return;
        
        for (int i = 0; i < GameStateHelper.inventorySpace; i++)
        {
            if (items[i].item == item)
            {
                if (items[i].count == 1)
                {
                    RemoveItem(i);
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
        if (items[index].item == null || index < 0 || index > GameStateHelper.inventorySpace)
            return;
        
        if (items[index].count == 1)
        {
            RemoveItem(index);
        }
        else if (items[index].count > 1)
            items[index].count--;
        else
            return;
        UpdateUI();
    }

    private void init()
    {
        for (int i = 0; i < GameStateHelper.inventorySpace; i++)
        {
            items[i] = new InternalItem();
        }
    }

    public void UpdateUI()
    {
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
