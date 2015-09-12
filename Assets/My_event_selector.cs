using UnityEngine;
using System.Collections;

public class My_event_selector : MonoBehaviour {

    public GameObject obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") != 0) {
            obj.SendMessage("OnSelect");
        }
	}
}
