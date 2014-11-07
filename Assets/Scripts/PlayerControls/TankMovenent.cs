using UnityEngine;
using System.Collections;

public class TankMovenent : MonoBehaviour {

	public UserInput userInput;
	public Movement movement;
	public Gun gun;
	public GameDetails gameDetails;


	// find and set up certain variables
	void Start (){
		gameDetails.manager = GameObject.FindGameObjectWithTag("GameController");
	}



	void FixedUpdate () {
		rigidbody.AddRelativeForce(Vector3.forward * userInput.vH.x * movement.speed);
		rigidbody.AddRelativeTorque(Vector3.up * userInput.vH.y * movement.turnSpeed);
	}

	void LateUpdate(){
		//turn on bullets if firing
		gun.bullets.enableEmission = userInput.firing;
		// turn and shoot torrent only if firring
		if(userInput.firing){
			// turn the torret towards where the user is pointing
			Vector3 targetDir = userInput.mouseClickedPos - gun.turrent.position;
			float step = movement.turrentSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(gun.turrent.forward, targetDir, step, 0.0F);
			gun.turrent.rotation = Quaternion.LookRotation(newDir);

			// lock the rotation to only one axis
			gun.turrent.localEulerAngles = new Vector3(0f,gun.turrent.localEulerAngles.y,0f);
		}
	}


	// this gets called when running over packages
	void OnTriggerEnter(Collider col){

		// tests to see if what you hit was a package
		if(col.tag == "Package"){
			col.gameObject.SetActive(false);
			gameDetails.manager.SendMessage("ScorePackage");
		}



	}


	// this gets called when running over bad guys
	void OnCollisionEnter(Collision col){
		// tests to see if what you hit was a badguy
		if(col.collider.tag == "BadGuy"){
			Debug.Log("bg");
			BadGuy bg = col.collider.GetComponent<BadGuy>();
			if(bg.ai.loaded){
				gameDetails.manager.SendMessage("HitBadGuy");
			}
		}
	}



}


[System.Serializable]
public class UserInput{
	public Vector2 vH;
	public bool firing = false;
	public Vector3 mouseClickedPos;
}

[System.Serializable]
public class Movement{
	public float speed = 1f;
	public float turnSpeed = 30f;
	public float turrentSpeed = 60f;
}

[System.Serializable]
public class Gun{
	public Transform turrent;
	public ParticleSystem bullets;
}

[System.Serializable]
public class GameDetails {
	public GameObject manager;
}

