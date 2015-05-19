using UnityEngine;
using System.Collections;

public class GameInitializer : MonoBehaviour {

	/*
	 * This class loads all configuration needed 
	 * to start correctly the game.
	 */
	void Start () {

			
		LifeManager.getInstance ().setLifes (10);
		LifeManager.getInstance ().save ();

		ScoreManager.getInstance ().resetScore ();
		ScoreManager.getInstance ().save ();

		//check audio 

		//load player skin
	}
}
