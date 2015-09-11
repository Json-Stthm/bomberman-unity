using UnityEngine;
using System.Collections;

public class Player_controller : MonoBehaviour {

	public GameObject bombPrefab;

	private bool canDrop = true;
	private int nbBombs = 0;
	private int playerID = 0;

	public bool CanDrop
	{
		get{return canDrop;}
		set{canDrop = value;}
	}

	public int NbBombs
	{
		get{return nbBombs;}
		set{nbBombs = value;}
	}

	public int PlayerID
	{
		get{return playerID;}
		set{playerID = value;}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1") && canDrop && nbBombs < GetComponent<Player_inventory>().bomb.Current_capacity) {
			nbBombs++;
			GameObject bomb = (GameObject) Instantiate (bombPrefab, transform.position + new Vector3 (0, 0.3f, 0), transform.rotation);
			bomb.GetComponent<Bomb>().Initialize(gameObject);
		}
	}
}
