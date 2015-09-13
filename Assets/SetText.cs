using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = GameObject.Find("Game_info").GetComponent<GameInfo>().EndText;
        Invoke("Reload", 5);
	}

    void Reload() {
        Application.LoadLevel(0);
    }
}
