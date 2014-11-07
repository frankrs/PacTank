using UnityEngine;
using System.Collections;

public class FollowTank : MonoBehaviour {

	public Transform tankTransform;
	public Zoom zoom;



	void LateUpdate () {

		// set zoom lev
		zoom.zoomLev = Mathf.Clamp(zoom.zoomLev+(zoom.zoomingIn*zoom.zoomSpeed*Time.deltaTime),0f,1f);
		// lerp the camera y hight according to the zoom
		transform.position = new Vector3(transform.position.x,Mathf.Lerp(zoom.zoomedIn,zoom.zoomedOut,zoom.zoomLev),transform.position.z);

		// follow the tank
		transform.position = new Vector3(tankTransform.position.x,transform.position.y,tankTransform.position.z);

	}
}


[System.Serializable]
public class Zoom{
	public float zoomLev = 0f;
	public float zoomedIn = 15f;
	public float zoomedOut = 30;
	public float zoomSpeed;
	public float zoomingIn;
}