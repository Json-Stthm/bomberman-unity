using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameInfo : MonoBehaviour {

    private int         nb_players;
    private List<int>   playerIDS = new List<int>();
    private bool        end = false;
    private string      end_text;
	// Use this for initialization
    public int NbPlayers
    {
        get { return nb_players; }
        set { nb_players = value; }
    }
    public string EndText
    {
        get { return end_text; }
        set { end_text = value; }
    }
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}

    public void PlayerIDS() {

        if (playerIDS.Count != 0) {
            playerIDS.Clear();
        }
        for (int i = 0; i < nb_players; i++)
        {
            playerIDS.Add(i + 1);
        }
    }

    public void DeathPlayer(int id) {

        if (playerIDS.Count > 0)
        {
            playerIDS.Remove(id);
        }
        if (!end && playerIDS.Count == 1) {
            end = true;
            Invoke("EndGame", 0.2f);
        }
    }

    private void EndGame() {

        if (playerIDS.Count == 1)
        {
            end_text = "Player " + playerIDS[0] + " win !";
        }
        else {
            end_text = "Draw game :(";
        }
        end = false;
        Application.LoadLevel(2);
    }
}
