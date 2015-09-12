using UnityEngine;
using System.Collections;

public class ExplodeTrigger : MonoBehaviour {

    private bool    resize = false;
	// Use this for initialization
	void Start () {

        Invoke("Explode", 1);
	}
    void Explode() {
        resize = true;
    }
	// Update is called once per frame
	void Update () {

        if (resize && transform.localScale.x > 0.1f) {
            transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime) * 3;
        } else if (resize) {
            GetComponent<Collider>().enabled = false;
        }
	}

    void OnTriggerEnter(Collider col) {

        if (col.tag == "Player") {
            col.GetComponent<Player_inventory>().RemoveItem("inventory_life");
        }
    }
}
