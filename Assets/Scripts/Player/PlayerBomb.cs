using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBomb : MonoBehaviour {

	static int max_bombs = 8;
	//static int max_fire = 8;
	public int bombs_capacity;
	public int fire_capacity;
	public GameObject bombPrefab;
	public List<GameObject> droppedBombs = new List<GameObject>();

	bool onDroppedBomb;

	// Use this for initialization
	void Start () {
		bombs_capacity = 2;
		fire_capacity = 2;
		onDroppedBomb = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Fire1")){
			DropBomb();
		}
	}

	void DropBomb(){
		// bug onDroppedBomb: si je suis sur/contre une bombe quand son collider disparait, je peux plus poser de bombe
		if (!onDroppedBomb && droppedBombs.Count < bombs_capacity) {
			GameObject bomb = Instantiate (bombPrefab, transform.position + new Vector3 (0, 0.3f, 0), transform.rotation) as GameObject;
			Physics.IgnoreCollision (bomb.GetComponent<Collider> (), GetComponent<Collider> ());
			onDroppedBomb = true;
			droppedBombs.Add(bomb);
			bomb.GetComponent<Bomb>().Initialize(this, fire_capacity, 2);
		}
	}

	void OnTriggerEnter(Collider other){
		onDroppedBomb = true;
	}

	void OnTriggerExit(Collider other){
		onDroppedBomb = false;
		Physics.IgnoreCollision (other.gameObject.GetComponent<Collider> (), GetComponent<Collider> (), false);
	}
}
