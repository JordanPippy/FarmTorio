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

    public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

    public int space = GameStateHelper.inventorySpace;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            print("Inventory full");
            return false;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
            
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
