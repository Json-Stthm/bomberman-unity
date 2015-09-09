using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	PlayerBomb owner;
	Light bombLight;
	Vector3 bombNormalScale = new Vector3 (0.7F, 0.7F, 0.7F);
	ParticleSystem explosion;
	AudioSource explosionSound;
	float bombLightDuration;
	float currentLightTime = 0f;
	float bombPopDuration;
	float currentPopTime = 0f;
	float bombBreathAmplitude = 0.01f;
	float bombBreathPeriod = 0.1f;
	float currentBreathTime = 0f;
	bool exploding = false;
	bool initOk = false;
	bool bombScaled = false;

	public GameObject explosionParticle;

	public void Initialize(PlayerBomb playerBomb, int fire, int explodeDelay){
		owner = playerBomb;
		//explosion = transform.Find ("SmokeGround2").gameObject.GetComponent<ParticleSystem>();
		//bombLight = GetComponent<Light> ();
		
		bombLight = explosionParticle.GetComponent<Light>();
		explosionSound = GetComponent<AudioSource> ();
		bombLightDuration = explosionParticle.GetComponent<ParticleSystem>().duration * 3f;
		bombPopDuration = 0.1f;
		initOk = true;
		Invoke("Explode", explodeDelay);
	}

	void FixedUpdate(){

		if (initOk) {
			float perc;
			if (exploding) {
				// Explosion light
				currentLightTime += Time.deltaTime;
				if (currentLightTime > bombLightDuration) {
					currentLightTime = bombLightDuration;
				}
				perc = currentLightTime / bombLightDuration;
				perc = 1f - Mathf.Cos (perc * Mathf.PI * 0.5f);

				//bombLight.intensity = Mathf.Lerp (bombLight.intensity, 0f, perc);
			} else {
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
	}

	void Explode(){
		GameObject explosionInstance;
		// allow owner to drop another bomb
		owner.droppedBombs.Remove (gameObject);
		// launch particle system
		explosionInstance = (GameObject) Instantiate (explosionParticle, transform.position, explosionParticle.transform.rotation);
		//explosion.Play();
		explosionSound.Play ();
		// handle light
		exploding = true;
		bombLight.enabled = true;
		// mask bomb during explosion then destroy it
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		Destroy (gameObject);
		Destroy (explosionInstance, explosionParticle.GetComponent<ParticleSystem>().duration);
	}
}
