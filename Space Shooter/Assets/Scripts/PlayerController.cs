using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[System.Serializable]
public class Boundry
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	


	private Rigidbody rb;

	public float speed;
	public float tilt;
	public Boundry boundry;

	public AudioSource input;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		input = GetComponent<AudioSource>();
	}
	// fired a shot when you use the left click mouse button
	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
//			GameObject clone =
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);   //as GameObject;
			input.Play ();

		}
	}
	// moves the player along the x and z axis 
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3 
		(
			Mathf.Clamp (rb.position.x, boundry.xMin, boundry.xMax), // makes the player stay inside the screen
			0.0f, 
			Mathf.Clamp (rb.position.z, boundry.zMin, boundry.zMax) // makes the player stay inside the screen
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt); // tilts the player's ship when it is moving
	}
}