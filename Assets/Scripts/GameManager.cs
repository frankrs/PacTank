using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameStats gameStats;
	public Factory factory;
	public GameEndMenu gameEndMenu;

	void Start (){
		// set count of packages at start
		CountPackages();
		// start making bad guys
		InvokeRepeating("MakeBadGuy",factory.productionInterval,factory.productionInterval);
	}

	void MakeBadGuy(){
		GameObject bg = GameObject.Instantiate(factory.badGuyPrefab,factory.factoryPoint.position,Quaternion.identity) as GameObject;
	}


	void ScorePackage (){
		// add a package score
		gameStats.packagesScored ++;
		// recount the packages
		CountPackages();
		if(gameStats.packagesLeft.Length == 0){
			Win();
		}
	}


	void HitBadGuy(){
		Loose();
	}


	void CountPackages(){
		gameStats.packagesLeft = null;
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Package");
		gameStats.packagesLeft = gos;
	}


	void Loose (){
		Time.timeScale = 0;
		gameEndMenu.endResult = EndResult.loose;
		gameEndMenu.enabled = true;
	}

	void Win (){
		Time.timeScale = 0;
		gameEndMenu.endResult = EndResult.win;
		gameEndMenu.enabled = true;
	}
	
}


[System.Serializable]
public class GameStats{
	public int score;
	public int packagesScored;
	public GameObject[] packagesLeft;
	public GameObject[] badGuys;
}


[System.Serializable]
public class Factory{
	public float productionInterval;
	public Transform factoryPoint;
	public GameObject badGuyPrefab;
}

