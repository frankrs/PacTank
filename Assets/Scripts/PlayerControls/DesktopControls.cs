using UnityEngine;
using System.Collections;

public class DesktopControls : MonoBehaviour {

	public TankMovenent tm;
	public FollowTank ft;



	void Update () {
		// send the up down left right controls
		tm.userInput.vH = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
		// send wether you're holding the mouse button down
		tm.userInput.firing = Input.GetMouseButton(0);
		// if you are holding the mose down send where the cursor is in world 
		if(Input.GetMouseButton(0)){
			tm.userInput.mouseClickedPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.transform.position.y));
		}


		//set the contols for the camera zoom
		ft.zoom.zoomingIn = Input.GetAxis("Zoom");

	}
}
