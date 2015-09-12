using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

    private int nb_players;
	// Use this for initialization
    public int NbPlayers
    {
        get { return nb_players; }
        set { nb_players = value; }
    }

	void Awake () {
        DontDestroyOnLoad(gameObject);
	}
}
