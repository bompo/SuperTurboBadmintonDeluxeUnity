using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuttleMachine : MonoBehaviour {

	[SerializeField]
	private GameObject shuttle;

	[SerializeField]
	private GameObject racket;

	[SerializeField]
	private Transform shuttleSpawnPoint;

	[SerializeField]
	private float shuttleSpawnInterval = 2f;

	private float passedTime;

	private void FixedUpdate () {
		passedTime += Time.deltaTime;
		if (passedTime < shuttleSpawnInterval) {
			return;
		}
		passedTime = 0;

		var go = Instantiate (shuttle, shuttleSpawnPoint.position, Quaternion.identity);
		go.transform.rotation.SetLookRotation(racket.transform.position);
		go.GetComponent<Rigidbody> ().AddForce (racket.transform.position * Random.Range(80,160));
	}
}
