using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreateUILeaderBoard : MonoBehaviour {

	private bool completed;
	private List<dreamloLeaderBoard.Score> result = null;

	public GameObject leaderboardItem;
	public GameObject scoresContainer;

	public float startY = -50f;
	public float ySpace = 0;
	private float startZ = 5f;


	public Text loading;

	private string LOADING_MSG = "loading...";
	private string NO_CONNECTION_MSG = "sorry, no connection available";

	private dreamloLeaderBoard dl;

	private string playerName;



	IEnumerator Start () {
		//playerName = PlayerManager.getInstance ().getName ();
		completed = false;
		playerName = "antonio";

		dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard ();

		if (dl == null) {
			Debug.LogError("dreamlo component not loaded!");
		}

		Debug.Log("Sending data for leaderboard.");

		dl.AddScore ("zero", 0);
		
		Debug.Log("data sent correctly");
		
		yield return new WaitForSeconds(2);
		
		result = dl.ToListHighToLow ();
		
		yield return new WaitForSeconds(2);

	}


	void OnGUI() {

		if (!completed) {

			if (result == null) {

				loading.text = LOADING_MSG;

			} else {

				loading.text = "";	

				createUI (result);
			}
		}

	}
	
	private Vector3 lastPos;

	private void createUI(List<dreamloLeaderBoard.Score> result) {

		lastPos = scoresContainer.transform.position;

		//result = getAroundPlayer ("lala", 6);

		Debug.Log ("creto UI con " + result.Count + " elementi");

		Vector3 pos = new Vector3 (0, startY, startZ);

		for (int i = 0; i < result.Count; i++) {

			Debug.Log("analyzing " + result[i].playerName + " " + result[i].score);

			GameObject item = (GameObject) Instantiate(leaderboardItem, lastPos, Quaternion.identity);

			// IMPORTANT! sets as parent the object scoresContainer.
			// In this way all objects will be stored in it and used together.
			item.transform.parent = scoresContainer.transform;

			Canvas canvas = (Canvas) item.GetComponent<Canvas>();

			Text posText = item.GetComponentsInChildren<Text>()[0];

			Text nameText = item.GetComponentsInChildren<Text>()[1];

			Text scoreText = item.GetComponentsInChildren<Text>()[2];

			posText.text = result[i].position + ".";

			nameText.text = result[i].playerName;

			scoreText.text = result[i].score + "";

			lastPos = item.transform.position;
			lastPos.y += ySpace;
		}
		completed = true;
		Debug.Log("completed");
	}



	
	public int getScore(string player) {
		int index = getPlayerPosition (result, player);
		return index < 0 ? -1 : result[index].score;
	}


	
	public int getPlayerPosition(List<dreamloLeaderBoard.Score> list, string player) {
		for (int i = 0; i < list.Count; i++) {
			if (list[i].playerName == player) {
				return i;
			}
		}
		return -1;
	}
	
	
	public List<dreamloLeaderBoard.Score> getAroundPlayer(string player, int delta) {

		List<dreamloLeaderBoard.Score> toReturn = new List<dreamloLeaderBoard.Score>();
		
		int playerIndex = getPlayerPosition (result, player);
		int start = playerIndex - (delta / 2);
		int end = playerIndex + (delta / 2);
		
		if (start < 0) {
			end += playerIndex - start - 1;
			start = 0;
		}
		
		if (end >= result.Count) {
			end = result.Count - 1;
		}
		
		for (int i = start; i < end; i++) {
			toReturn.Add(result[i]);
		}
		return toReturn;
	}


}
