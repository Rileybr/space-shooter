/* Brandon Riley
 * 3/7/2018
 * destroys the game object after a set amount of time
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
	public float lifetime;

	// destroys the game object after a set amount of time
	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}
