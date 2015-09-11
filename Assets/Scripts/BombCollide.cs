using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombCollide : MonoBehaviour {

	private List<GameObject> contactPlayers = new List<GameObject>();

	void OnTriggerEnter(Collider col) {

		if (col.CompareTag ("Player")) {
			col.GetComponent<Player_controller>().CanDrop = false;
			contactPlayers.Add(col.gameObject);
		}
	}

	void OnTriggerExit(Collider col) {

		if (col.CompareTag ("Player")) {
			transform.parent.gameObject.layer = 0;
			col.GetComponent<Player_controller>().CanDrop = true;
			contactPlayers.Remove(col.gameObject);
		}
	}
	
	void OnDestroy() {
		
		foreach (GameObject player in contactPlayers) {
			player.GetComponent<Player_controller>().CanDrop = true;
		}
	}
}
