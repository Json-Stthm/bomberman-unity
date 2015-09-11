using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetPlayerCount : MonoBehaviour {

	public void ChangeValue(float value) {

		GetComponent<Text> ().text = value.ToString () + " PLAYERS";
	}

}
