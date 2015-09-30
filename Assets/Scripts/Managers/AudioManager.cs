using UnityEngine;
using System.Collections;

public class AudioManager {

	// Use this for initialization
	private static AudioManager instance = null;

	private static bool musics;
	private static bool sounds;
	
	private AudioManager() {
		load ();
		save ();
	}
	
	public static AudioManager getInstance(){
		if(instance == null){
			instance = new AudioManager();
		}
		return instance;
	}

	
	public void save() {
		int m, s;
		if (musics) m = 1; else m = 0;
		if (sounds) s = 1; else s = 0;

		StorageManager.storeOnDisk (StorageManager.MUSIC_SETTING, m);
		StorageManager.storeOnDisk (StorageManager.SOUNDS_SETTING, s);
	}
	
	public void load() {
		int m = StorageManager.loadIntFromDisk (StorageManager.MUSIC_SETTING);
		int s = StorageManager.loadIntFromDisk (StorageManager.SOUNDS_SETTING);

		musics = m == 1;
		sounds = s == 1;
	}

	public bool canPlayMusic() {
		return musics;
	}

	public bool canPlaySounds() {
		return sounds;
	}

	public void setMusics(bool enable) {
		musics = enable;
		save ();
	}

	public void setSounds(bool enable) {
		sounds = enable;
		save ();
	}

}
