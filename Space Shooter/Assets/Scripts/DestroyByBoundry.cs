/* Brandon Riley
 * 3/7/2018
 * Destroys game objects when they exit the play area
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// destroys game objects when they exit the play area
public class DestroyByBoundry : MonoBehaviour {
	void OnTriggerExit (Collider other){
		Destroy (other.gameObject);
	}
}
