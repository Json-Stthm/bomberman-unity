using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Player_inventory : MonoBehaviour {
	[System.Serializable]
	public class Inventory
	{
		public int capacity = 8;
		public int start_capacity = 1;
		public string tag;
		private int current_capacity;
		public Inventory() {
			current_capacity = start_capacity;
		}
		public int Current_capacity
		{
			get{return current_capacity;}
			set{current_capacity = value;}
		}
	}
	public Inventory[] player_inventory;
	private Dictionary<string, Inventory> inventory_player = new Dictionary<string, Inventory>();

	void Start() {

        foreach (Inventory item in player_inventory)
        {
            inventory_player.Add(item.tag, item);
        }
	}
	void OnTriggerEnter(Collider col) {
		
		if (inventory_player.ContainsKey(col.tag)) {
			if (inventory_player[col.tag].Current_capacity < inventory_player[col.tag].capacity) {
				inventory_player[col.tag].Current_capacity += 1;
			}
			Destroy(col.gameObject);
		}
	}
    public int Get_current_capacity(string key)
    {
        return inventory_player[key].Current_capacity;
    }
    public void RemoveItem(string key){

        if (inventory_player[key].Current_capacity > 0) {
            inventory_player[key].Current_capacity -= 1;
        }
        if (key == "inventory_life" && inventory_player[key].Current_capacity == 0)
        {
            GetComponent<Player_controller>().Death();
        }
    }

}
