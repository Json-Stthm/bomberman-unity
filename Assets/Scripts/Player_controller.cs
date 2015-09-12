using UnityEngine;
using System.Collections;

public class Player_controller : MonoBehaviour {

    //Player_controller variables
	public GameObject bombPrefab;
	private bool canDrop = true;
	private int nbBombs = 0;
	private int playerID = 0;
    //Player_movement varaiables
    public float speed = 3f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;  

    /*********************************************/
    /************** PLAYER MOVEMENT **************/
    /*********************************************/
    void Awake()
    {
        // Set up references.
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal_P" + playerID.ToString());
        float v = Input.GetAxisRaw("Vertical_P" + playerID.ToString());
        // Move the player around the scene.
        Move(h, v);
        // Animate the player.
        Animating(h, v);
    }
    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;
        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
        // Rotate the player to it's looking direction
        Vector3 moveDirection = new Vector3(h, 0, v);
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 4 * speed);
        }
    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;
        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
    /*********************************************/
    /************** PLAYER CONTROLLER ************/
    /*********************************************/
	void Update () {

		if (Input.GetButtonDown ("Fire1_P" + playerID.ToString()) && canDrop && nbBombs < GetComponent<Player_inventory>().bomb.Current_capacity) {
			nbBombs++;
			GameObject bomb = (GameObject) Instantiate (bombPrefab, transform.position + new Vector3 (0, 0.3f, 0), transform.rotation);
			bomb.GetComponent<Bomb>().Initialize(gameObject);
		}
	}
    public bool CanDrop
    {
        get { return canDrop; }
        set { canDrop = value; }
    }

    public int NbBombs
    {
        get { return nbBombs; }
        set { nbBombs = value; }
    }

    public int PlayerID
    {
        get { return playerID; }
        set { playerID = value; }
    }
}
