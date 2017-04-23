using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

	[SerializeField]
	private Transform lookAtTarget;

	[SerializeField]
	private Camera currentCamera;
	
	// Update is called once per frame
	void Update ()
	{
		currentCamera.transform.rotation = Quaternion.Slerp (currentCamera.transform.rotation, Quaternion.LookRotation (lookAtTarget.transform.position - currentCamera.transform.position), Time.deltaTime);

	}
}
