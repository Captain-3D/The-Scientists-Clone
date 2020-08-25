using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton

	private static Inventory instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

	public static Inventory Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("Inventory").AddComponent<Inventory> ();
			}
 
			return instance;
		}
	}

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 40;	// Amount of item spaces

	// Our current list of items in the inventory
	public List<Item> items = new List<Item>();

	// Add a new item if enough room
	public void Add (Item item)
	{
		if (item.showInInventory) 
		{
			if (items.Count >= space) 
			{
				Debug.Log ("Not enough room.");
				return;
			}

			items.Add(item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke ();
		}
	}

	// Remove an item
	public void Remove (Item item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

	public List<Item> returnList ()
	{
		return items;
	}

	public void getList(List<Item> itemsList)
	{
		items = itemsList;
	}
}