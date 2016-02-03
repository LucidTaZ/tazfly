﻿using UnityEngine;

public class CollisionExplosion : MonoBehaviour {

	bool soundPlayed;

	void Start () {
		soundPlayed = false;
	}

	void OnCollisionEnter (Collision collision) {
		if (!soundPlayed) {
			gameObject.GetComponent<AudioSource>().Play();
			soundPlayed = true;
			DestroyObject(gameObject, gameObject.GetComponent<AudioSource>().clip.length); // Destroy when the sound clip ends

			CameraShake shake;
			if ((shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>()) != null) {
				shake.ShakeAtLocation(transform.position);
			}
		}
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		Collider[] colliders = gameObject.GetComponents<Collider>();
		foreach (Collider thisCollider in colliders) {
			thisCollider.enabled = false;
		}
	}

}
