using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
		
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

	// Use this for initialization
	void Start () {
		load ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string getId() {
		return this.id;
	}

	public void setId(string newId) {
		this.id = newId;
	}

	public string getName() {
		return this.name;
	}

	public void setName(string newName) {
		this.name = newName;
	}

	public string getSkin() {
		return this.skin;
	}

	public void setSkin(string newSkin) {
		this.skin = newSkin;
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

