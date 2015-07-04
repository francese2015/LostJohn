using UnityEngine;
using System.Collections;

public class StorageManager : MonoBehaviour {

	public const string SCORE = "score";

	public const string LIFES = "lifes";

	public const string EXP = "exp";

	public const string BEST_SCORE = "bestScore";

	public const string LAST_ACCESS = "lastAccess";

	public const string COINS = "coins";

	public const string REDCOINS = "redCoins";

	public const string ID = "id";

	public const string SKIN = "skin";

	public const string LEVEL = "playerLevel";

	public const string GAME_LEVEL = "gameLevel";

	public const string NEXT_GOAL = "nextGoal";

	public const string PLAYER_ID = "idPlayer";
	
	public const string PLAYER_NAME = "namePlayer";

	public const string MUSIC_SETTING = "musics";
	
	public const string SOUNDS_SETTING = "sounds";

	public const string DATE_TIME = "dateTime";

	public const string LEVELUP = "levelUp";

	
	public static bool storeOnDisk(string key, string value){
		PlayerPrefs.SetString (key, value);
		//check if storage process had success
		return (PlayerPrefs.GetString (key) == value);
	}

	public static bool storeOnDisk(string key, int value){
		PlayerPrefs.SetInt (key, value);
		//check if storage process had success
		return (PlayerPrefs.GetInt (key) == value);
	}

	public static bool storeOnDisk(string key, float value){
		PlayerPrefs.SetFloat (key, value);
		//check if storage process had success
		return (PlayerPrefs.GetFloat (key) == value);
	}

	public static bool storeOnDisk(string key, bool value){
		PlayerPrefs.SetFloat (key, value ? 1 : 0);
		//check if storage process had success
		return (loadBoolFromDisk(key));
	}


	public static string loadStringFromDisk(string key){
		return PlayerPrefs.GetString (key);
	}
	
	public static int loadIntFromDisk(string key){
		return PlayerPrefs.GetInt (key);
	}
	
	public static float loadFloatFromDisk(string key){
		return PlayerPrefs.GetFloat (key);
	}

	public static bool loadBoolFromDisk(string key){
		int value = loadIntFromDisk (key);
		return value == 1;
	}
	
	public static System.DateTime loadDateFromDisk() {
		string savedDate = PlayerPrefs.GetString (DATE_TIME);

		if (savedDate == "") {
			storeDateOnDisk(System.DateTime.Now);
		}
		System.DateTime toReturn;
		System.DateTime.TryParse(savedDate, out toReturn);
		return toReturn;
	}

	public static void storeDateOnDisk(System.DateTime dateTime) {
		PlayerPrefs.SetString(DATE_TIME, dateTime.ToString());
	}


}

