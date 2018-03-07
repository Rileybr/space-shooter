/* Brandon Riley
 * 3/7/2018
 * rotates the hazards randomly as they spawn
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	private Rigidbody rb;

	public float tumble;

	// rotates the asteroids randomly as they spawn
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
