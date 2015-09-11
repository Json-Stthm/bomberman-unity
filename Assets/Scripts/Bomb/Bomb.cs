using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public GameObject explosionParticle;

	private Vector3 bombNormalScale = new Vector3 (0.7F, 0.7F, 0.7F);
	private ParticleSystem explosion;
	private float bombPopDuration = 0.1f;
	private float currentPopTime = 0f;
	private float bombBreathAmplitude = 0.01f;
	private float bombBreathPeriod = 0.1f;
	private float currentBreathTime = 0f;
	private bool initOk = false;
	private bool bombScaled = false;
	private GameObject dropPlayer;
	protected float explodeDelay = 2;

	public void Initialize(GameObject player){

		dropPlayer = player;
		initOk = true;
		Invoke("Explode", explodeDelay);
	}

	void FixedUpdate(){

		if (initOk) {
			float perc;
			if(!bombScaled && transform.localScale != bombNormalScale){
				// Pop smooth
				currentPopTime += Time.deltaTime;
				if (currentPopTime > bombPopDuration) {
					currentPopTime = bombPopDuration;
				}
				perc = currentPopTime / bombPopDuration;
				perc = 1f - Mathf.Cos (perc * Mathf.PI * 0.5f);

				transform.localScale = Vector3.Lerp (transform.localScale, bombNormalScale, perc);
			} else {
				// Breathing
				currentBreathTime += Time.deltaTime;
				bombScaled = true;
				float theta = currentBreathTime / bombBreathPeriod;
				float distance = bombBreathAmplitude * Mathf.Sin (theta);
				transform.localScale = bombNormalScale + new Vector3 (2F, 2F, 2F) * distance;
			}
		}
	}

	void Explode(){
		// launch particle system
		GameObject explosionInstance = (GameObject) Instantiate (explosionParticle, transform.position, explosionParticle.transform.rotation);
		Destroy (gameObject);
		Destroy (explosionInstance, explosionParticle.transform.GetChild(0).GetComponent<ParticleSystem>().duration);
	}
	void OnDestroy() {

		if (dropPlayer) {
			dropPlayer.GetComponent<Player_controller> ().NbBombs -= 1;
		}
	}

	//Getter Setter
	public GameObject DropPlayer
	{
		get{return dropPlayer;}
		set{dropPlayer = value;}
	}
	public float ExplodeDelay
	{
		get{return explodeDelay;}
		set{explodeDelay = value;}
	}
}
