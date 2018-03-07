using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// destroys game objects when they exit the play area
public class DestroyByBoundry : MonoBehaviour {
	void OnTriggerExit (Collider other){
		Destroy (other.gameObject);
	}
}
