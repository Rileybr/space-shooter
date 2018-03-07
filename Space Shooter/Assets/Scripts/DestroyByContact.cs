﻿/* Brandon Riley
 * 3/7/2018
 * destorys hazards when they hit a shot or destroys both the hazard and ship if they collide 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosions;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	// 
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	// destroys gameobjects that don't have the tag "Boundry" or "Player" when their colliders overlap
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundry")
		{
			return;
		}
		Instantiate (explosions, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
