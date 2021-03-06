﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctupusPhysicController : MonoBehaviour
{

	[SerializeField]
	private Rigidbody head;

	[SerializeField]
	private List<Rigidbody> upperBones;

	[SerializeField]
	private List<Rigidbody> lowerBones;

	[SerializeField]
	private Rigidbody racket;

	[SerializeField]
	private float sinDelay = 2f;

	[SerializeField]
	private Vector3 forceLowerBones = new Vector3 (0, 0, 0);

	[SerializeField]
	private Vector3 forceUpperBones = new Vector3 (0, 0, 0);

	[SerializeField]
	private Vector3 forceHead = new Vector3 (0, 0.9f, 0);

	[SerializeField]
	private Vector3 forceRacketBone = new Vector3 (0, 5f, 0);

	private void FixedUpdate ()
	{
		if (Time.fixedTime < 1f) {
			return;
		}

		head.AddForce (forceHead);

		int i = 0;
		foreach (var lowerBone in lowerBones) {
			lowerBone.AddForce (forceLowerBones * Mathf.Sin (((i / (float)lowerBones.Count) * sinDelay) + Time.fixedTime));
			i++;
		}

		i = 0;
		foreach (var upperBone in upperBones) {
			upperBone.AddForce (forceUpperBones * Mathf.Sin (((i / (float)upperBones.Count) * sinDelay) + Time.fixedTime));
			i++;
		}

		racket.AddForce (forceRacketBone);
	}
}
