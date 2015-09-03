using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FB_LeaderboardItemManager : MonoBehaviour {

	public Text Name;
	public Text Level;
	public Text Score;
	public Image Photo;

	public void setName(string s) {
		Name.text = s;
	}

	public void setLevel(string l) {
		Level.text = "lvl " + l;
	}

	public void setScore(string s) {
		Score.text = s;
	}

	public void setPhoto(Sprite photo) {
		Photo.sprite = photo;
	}
}
