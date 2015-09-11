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
	public Inventory bomb;
	public Inventory fire;
	public Inventory roller;
	private Dictionary<string, Inventory> inventory_player = new Dictionary<string, Inventory>();

	void Start() {
		inventory_player.Add(bomb.tag, bomb);
		inventory_player.Add(fire.tag, fire); 
		inventory_player.Add(roller.tag, roller); 
	}
	void OnTriggerEnter(Collider col) {
		
		if (is_inventory(col.tag)) {
			if (inventory_player[col.tag].Current_capacity < inventory_player[col.tag].capacity) {
				inventory_player[col.tag].Current_capacity += 1;
			}
			Destroy(col.gameObject);
		}
	}

	private bool is_inventory(string tag) {
		return (tag == bomb.tag || tag == fire.tag || tag == roller.tag)?true:false;
	}

}
