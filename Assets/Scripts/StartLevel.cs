using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {

	// Use this for initialization
	void Update () {

        if (Input.GetAxis("Start") != 0) {
            Application.LoadLevel(1);
        }
	}
}
