using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class testLeaderboard : MonoBehaviour {

	Text text;
	LeaderBoardManager m;
	dreamloLeaderBoard dl;


	IEnumerator Start () {
		this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();

		text = GetComponent<Text> ();
		m = LeaderBoardManager.getInstance ();
		Debug.Log ("Score inviato");
		m.addScore ("antonio", 400);

		yield return new WaitForSeconds (2);
		scoreList = m.getScoresFromHihgToLow ();

		yield return new WaitForSeconds (2);
		//score = m.getScore ("antonio");
		score = m.getScore ("antonio");

		rangeTest = m.getAroundPlayer ("antonio", 2);

		Debug.Log ("Score richiesto ");


	}

	bool loaded = false;
	int score = -1;
	List<dreamloLeaderBoard.Score> scoreList = null;
	List<dreamloLeaderBoard.Score> rangeTest = null;

	// Update is called once per frame
	void Update () {
		/*
		if (scoreList == null) 
		{
			Debug.Log("loading");
		} 	else {
			int maxToDisplay = 20;
			int count = 0;
			Debug.LogError("stampo");

			foreach (dreamloLeaderBoard.Score currentScore in scoreList)
			{
				count++;
				Debug.LogError(currentScore.playerName + " - " + currentScore.score.ToString());
				//text.text = currentScore.playerName + " - " + currentScore.score.ToString();
				if (count >= maxToDisplay) break;
			}
		}


		if (score == -1) {
			text.text = "loading...";
		} else {
			text.text = "" + score;

		}
*/
		if (rangeTest == null) {
			Debug.Log ("loading");
		} else {
			for (int i = 0; i < rangeTest.Count; i++) {
				text.text += (rangeTest[i].playerName + " -> " + rangeTest[i].score) + "\n";
			}
		}

	}

}
