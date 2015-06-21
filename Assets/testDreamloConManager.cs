using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class testDreamloConManager : MonoBehaviour {

	// Use this for initialization

	dreamloLeaderBoard dl;
	Text label;
	List<dreamloLeaderBoard.Score> result;

	bool completed = false;
	string highscore;

	IEnumerator Start () {
		label = GetComponent<Text> ();
		dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard ();
		label = GetComponent<Text> ();

		if (dl == null) {
			Debug.LogError("dreamlo component not loaded!");
		}

		Debug.Log("invio dati!");
		
		dl.AddScore ("zero", 0);
		
		Debug.Log("dati inviati");
		
		yield return new WaitForSeconds(2);
		
		result = dl.ToListHighToLow ();
		
		yield return new WaitForSeconds(2);
		
		Debug.Log("ricevo dati");

		//LeaderboardManager manager = LeaderboardManager.getInstance ();
		//result = manager.getOrderedScores ();
	}



	void OnGUI()
	{
		if (!completed) {

			if (result == null) {

				label.text = "loading...";

			} else {

				Debug.Log("ricevuti "+ result.Count + " elementi");

				label.text = "";

				for ( int i = 0; i < result.Count; i++) {
					label.text += result[i].playerName + ". " + result[i].score + "\n";
				}
			}
		}
	}
}
