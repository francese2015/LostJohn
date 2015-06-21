using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeaderBoardManager : MonoBehaviour {

	private static LeaderBoardManager instance = null;
	private GameObject dreamlo;
	private static dreamloLeaderBoard leaderboardManager;
	
	private LeaderBoardManager() {
		GameObject go = GameObject.Find("dreamloPrefab");
		leaderboardManager = go.GetComponent<dreamloLeaderBoard>();
	}


	public static LeaderBoardManager getInstance(){
		if(instance == null){
			instance = new LeaderBoardManager();
		}
		return instance;
	}


	public void addScore(string player, int score) {
		leaderboardManager.AddScore(player, score);
	}


	public int getScore(string player) {
		List<dreamloLeaderBoard.Score> list = getScoresFromHihgToLow ();
		int index = getPlayerPosition (list, player);
		return index < 0 ? -1 : list[index].score;
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
		List<dreamloLeaderBoard.Score> list = getScoresFromHihgToLow ();
		List<dreamloLeaderBoard.Score> toReturn = new List<dreamloLeaderBoard.Score>();

		int playerIndex = getPlayerPosition (list, player);
		int start = playerIndex - (delta / 2);
		int end = playerIndex + (delta / 2);

		if (start < 0) {
			end += playerIndex - start;
			start = 0;
		}

		if (end >= list.Count) {
			end = list.Count - 1;
		}

		for (int i = start; i < end; i++) {
			toReturn.Add(list[i]);
		}
		return toReturn;
	}


	public List<dreamloLeaderBoard.Score> getScoresFromHihgToLow() {
		return leaderboardManager.ToListHighToLow();
	}


}
