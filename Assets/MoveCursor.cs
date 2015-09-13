using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveCursor : MonoBehaviour {

    public  Slider      slider;
    public  GameObject  jauge;
    public  float       min_value;
    public  float       max_val;
    public  float       start_x = 0;
    public  float       offset = 0.5f;
    public  float       snap_distance = 3.2f;
    private float       min_limit;
    private GameInfo    info;

    void Start() {
        info = GameObject.Find("Game_info").GetComponent<GameInfo>();
        min_limit = -snap_distance + offset;
        if (info.NbPlayers != 0) {
            start_x = info.NbPlayers - min_value;
            slider.value = info.NbPlayers;
        } else {
            info.NbPlayers = (int)min_value;
        }
        float pos_x = min_limit + snap_distance * start_x;
        jauge.transform.localScale = new Vector3(start_x / max_val, jauge.transform.localScale.y, jauge.transform.localScale.z);
        transform.position = new Vector3(pos_x, transform.position.y, transform.position.z);
    }

    public void SetPos(float val) {

        float pos_x = min_limit + snap_distance * (val - min_value);
        jauge.transform.localScale = new Vector3((val - min_value) / max_val, jauge.transform.localScale.y, jauge.transform.localScale.z);
        transform.position = new Vector3(pos_x, transform.position.y, transform.position.z);
        info.NbPlayers = (int) val;
    }
}
