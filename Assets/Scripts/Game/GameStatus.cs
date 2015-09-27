using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

	private static bool pause;
	private static bool playerAlive;

	void Start() {
		pause = false;
		playerAlive = true;
	}

	public static bool isGamePaused() {
		return pause;
	}
	
	public static void setGameInPause(bool status) {
		pause = status;
		//Debug.Log("GAME IS " + (pause ? "" : "NOT ") + "PAUSED");
	}
	
	public static bool isPlayerAlive() {
		return playerAlive;
	}
	
	public static void setPlayerAlive(bool status) {
		playerAlive = status;
	}
	


}
