using UnityEngine;
using System.Collections;

public class BombDepot : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider col) {
		col.BroadcastMessage("BombDepot",SendMessageOptions.DontRequireReceiver);
	}

}
