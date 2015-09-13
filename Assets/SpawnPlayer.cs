using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

    public  Transform[]     spawn;
    public  GameObject      player_prefab;
	// Use this for initialization
	void Start () {
        GameObject info = GameObject.Find("Game_info");
        if (info) {
            int nb_player = info.GetComponent<GameInfo>().NbPlayers;
            for (int i = 0; i < nb_player; i++)
            {
                GameObject player = (GameObject)Instantiate(player_prefab, spawn[i].position, Quaternion.identity);
                player.GetComponent<Player_controller>().PlayerID = i + 1;
                player.GetComponent<Player_controller>().SetColor();
            }
        }
	}
}
