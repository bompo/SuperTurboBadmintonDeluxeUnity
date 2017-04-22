using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctupusPhysicController : MonoBehaviour {

	[SerializeField]
	private Rigidbody head;

	[SerializeField]
	private List<Rigidbody> upperBones;

	[SerializeField]
	private List<Rigidbody> lowerBones;


	[SerializeField]
	private Vector3 forceLowerBones = new Vector3(0,0,0);

	[SerializeField]
	private Vector3 forceUpperBones = new Vector3(0,0,0);

	[SerializeField]
	private Vector3 forceHead = new Vector3(0,0.9f,0);
		
	private void OnEnable() {
		Debug.Log ("OctupusPhysicController:OnEnable");
		Debug.Log (Camera.main.transform.position);
	}

	private void FixedUpdate() {
		head.AddForce (forceHead);

		if (Time.fixedTime < 1f) {
			return;
		}

		int i = 0;
		foreach (var lowerBone in lowerBones) {
			lowerBone.AddForce (forceLowerBones * Mathf.Sin((i/(float)lowerBones.Count) + Time.fixedTime));
			i++;
		}

		i = 0;
		foreach (var upperBone in upperBones) {
			upperBone.AddForce (forceUpperBones * Mathf.Sin((i/(float)upperBones.Count) + Time.fixedTime));
			i++;
		}
	}
}
