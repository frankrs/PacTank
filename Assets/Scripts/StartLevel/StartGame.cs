using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class StartGame : MonoBehaviour {
	
	public Vector2 screen;
	public Menue menue;
	public Styles styles;



	// Update is called once per frame
	void Update () {
		screen = new Vector2 (Screen.width,Screen.height);
	}


	void OnGUI (){

		GUILayout.BeginArea(new Rect(screen.x*.25f,screen.y*.25f,screen.x*.5f,screen.y));
		GUILayout.BeginVertical();

		// if in startpage show startpage
		if(menue == Menue.Start){
			StartPage();
		}

		GUILayout.EndVertical();
		GUILayout.EndArea();

	}



	void StartPage (){
		GUILayout.Box ("PacTank","box");
		if(GUILayout.Button("PlayNow","button")){
			Application.LoadLevel(1);
		}

	}


}

[System.Serializable]
public enum Menue{
	Start,Options
}

[System.Serializable]
public class Styles{
	public GUIStyle box;
	public GUIStyle button;
}