using UnityEngine;
using System.Collections;

public class ExplosionLight : MonoBehaviour {

	float currentLightTime = 0f;
	float bombLightDuration;

	// Use this for initialization
	void Start () {
		bombLightDuration = GetComponent<ParticleSystem>().duration * 2f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float perc;
		float bombLightIntensity = GetComponent<Light> ().intensity;
		currentLightTime += Time.deltaTime;
		if (currentLightTime > bombLightDuration) {
			currentLightTime = bombLightDuration;
		}
		perc = currentLightTime / bombLightDuration;
		perc = 1f - Mathf.Cos (perc * Mathf.PI * 0.5f);
		
		GetComponent<Light> ().intensity = Mathf.Lerp (bombLightIntensity, 0f, perc);
	}
}
