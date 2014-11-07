using UnityEngine;
using System.Collections;

public class BadGuy : MonoBehaviour {

	public AI ai;
	public NavStuff navStuff;


	void Awake(){
		// get game info
		ai.bombDepot = GameObject.FindGameObjectWithTag("Depot");
		ai.player = GameObject.FindGameObjectWithTag("Tank");
	}

	void Update (){
		// check to see if we are loaded with a bomb if so chase player othewise go get one
		if(ai.loaded){
			navStuff.agent.destination = ai.player.transform.position;
		}
		else{
			navStuff.agent.destination = ai.bombDepot.transform.position;
		}
	}


	// this is called when shot by player
	void OnParticleCollision () {
		Shot();
	}
	void Shot (){
		UnLoad();
	}


	//this gets called when this guy makes it to the box of bombs
	void BombDepot (){
		Load();
	}

	void Load (){
		ai.loaded = true;
		renderer.materials[1].color = Color.red;
	}

	void UnLoad(){
		ai.loaded = false;
		renderer.materials[1].color = Color.green;
	}


}

[System.Serializable]
public class AI{
	public bool loaded;
	public GameObject player;
	public GameObject bombDepot;
}

[System.Serializable]
public class NavStuff{
	public NavMeshAgent agent;
}