using UnityEngine;
using System.Collections;

public class PlayerManager {
		
	public const string DEFAULT_SKIN = "";
	
	public const string DEFAULT_PLAYER_NAME = "John";
	
	public const string DEFAULT_ID = "player";

	private static PlayerManager instance = null; 

	private string id;

	private string playerName;

	private string skin;

	private PlayerManager(){
		load ();
		save ();
	}
	
	public static PlayerManager getInstance(){
		if(instance == null){
			instance = new PlayerManager();
		}
		return instance;
	}

	public string getId() {
		return this.id;
	}

	public void setId(string newId) {
		this.id = newId;
		save ();
	}

	public string getName() {
		return playerName;
	}

	public void setName(string newName) {
		this.playerName = newName;
		save ();
	}

	public string getSkin() {
		return this.skin;
	}

	public void setSkin(string newSkin) {
		this.skin = newSkin;
		save ();
	}

	public void save() {
		StorageManager.storeOnDisk (StorageManager.SKIN, this.skin);
		StorageManager.storeOnDisk (StorageManager.ID, this.id);
	}

	public void load() {
		setSkin	(StorageManager.loadStringFromDisk (StorageManager.SKIN));
		setId	(StorageManager.loadStringFromDisk (StorageManager.ID));
	}


}

