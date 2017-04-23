using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPidController : MonoBehaviour
{
	[SerializeField]
	private Transform target;

	[SerializeField]
	private Rigidbody rigidbodyWhichFollows;

	private readonly VectorPid angularVelocityController = new VectorPid (33.7766f, 0, 0.2553191f);
	private readonly VectorPid headingController = new VectorPid (9.244681f, 0, 0.06382979f);

	public void FixedUpdate ()
	{
		var angularVelocityError = rigidbodyWhichFollows.angularVelocity * -1;
		Debug.DrawRay (rigidbodyWhichFollows.transform.position, rigidbodyWhichFollows.angularVelocity * 10, Color.black);

		var angularVelocityCorrection = angularVelocityController.Update (angularVelocityError, Time.deltaTime);
		Debug.DrawRay (rigidbodyWhichFollows.transform.position, angularVelocityCorrection, Color.green);

		rigidbodyWhichFollows.AddTorque (angularVelocityCorrection);

		var desiredHeading = target.position - rigidbodyWhichFollows.transform.position;
		Debug.DrawRay (rigidbodyWhichFollows.transform.position, desiredHeading, Color.magenta);

		var currentHeading = rigidbodyWhichFollows.transform.up;
		Debug.DrawRay (rigidbodyWhichFollows.transform.position, currentHeading * 15, Color.blue);

		var headingError = Vector3.Cross (currentHeading, desiredHeading);
		var headingCorrection = headingController.Update (headingError, Time.deltaTime);

		rigidbodyWhichFollows.AddTorque (headingCorrection);
	}
}