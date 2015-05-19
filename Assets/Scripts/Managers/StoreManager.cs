using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour {
		
	ArrayList items;

	private static StoreManager instance = null; 
	
	private StoreManager(){
		load ();
		save ();
		items = new ArrayList ();

	}
	
	public static StoreManager getInstance(){
		if(instance == null){
			instance = new StoreManager();
		}
		return instance;
	}
	

	public void addItem(StoreItem item){
		if (items.Contains (item)) {
			return;
		}
		items.Add (item);
	}


	public StoreItem getItem(string name) {
		for (int i=0; i<items.Count; i++) {
			if( ((StoreItem) items[i]).getName() == name) {
				return (StoreItem) items[i];
			}
		}
		return null;
	}

	/**
	 * unlock the item given in input and return true.
	 * if item does not exists return false
	 */
	public bool unlock(StoreItem item) {
		for (int i=0; i<items.Count; i++) {
			if (items [i] == item) {
				((StoreItem)items[i]).setUnlocked(true);
				return true;
			}
		}
		return false;
	}


	public IList getItems() {
		return this.items;
	}

	public void save() {
	}

	public void load() {
	}

}

