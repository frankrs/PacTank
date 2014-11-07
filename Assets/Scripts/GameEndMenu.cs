using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class GameEndMenu : MonoBehaviour {

	public EndResult endResult;

	public Vector2 screen;
	public Styles styles;



	void Update () {
		screen = new Vector2 (Screen.width,Screen.height);
	}




	void OnGUI (){
		
		GUILayout.BeginArea(new Rect(screen.x*.25f,screen.y*.25f,screen.x*.5f,screen.y));
		GUILayout.BeginVertical();
		
		// if in startpage show startpage
		if(endResult == EndResult.win){
			WinPage();
		}

		if(endResult == EndResult.loose){
			LoosePage();
		}

		GUILayout.EndVertical();
		GUILayout.EndArea();
		
	}
	
	
	
	void WinPage (){
		GUILayout.Box ("Win","box");
		if(GUILayout.Button("PlayAgain","button")){
			Time.timeScale = 1;
			Application.LoadLevel(1);
		}
		
	}

	void LoosePage (){
		GUILayout.Box ("Loose","box");
		if(GUILayout.Button("PlayAgain","button")){
			Time.timeScale = 1;
			Application.LoadLevel(1);
		}
		
	}


}

[System.Serializable]
public enum EndResult {
	win,loose
}



