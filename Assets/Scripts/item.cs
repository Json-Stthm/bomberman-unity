using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {

	void FixedUpdate () {
		transform.Rotate (Vector3.up * 2);
	}
}
