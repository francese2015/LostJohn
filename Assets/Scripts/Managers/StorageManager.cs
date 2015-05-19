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


	public static string loadStringFromDisk(string key){
		return PlayerPrefs.GetString (key);
	}
	
	public static int loadIntFromDisk(string key){
		return PlayerPrefs.GetInt (key);
	}
	
	public static float loadFloatFromDisk(string key){
		return PlayerPrefs.GetFloat (key);
	}
	


}

