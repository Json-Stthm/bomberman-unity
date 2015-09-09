using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	void OnParticleCollision(GameObject other) {
		Debug.Log("Hit!");
		Rigidbody body = other.GetComponent<Rigidbody>();
		if (body) {
			//Vector3 direction = other.transform.position - transform.position;
			//direction = direction.normalized;
			//body.AddForce(direction * 5);
			Debug.Log("Hit: " + other.name);
		}
	}
}
