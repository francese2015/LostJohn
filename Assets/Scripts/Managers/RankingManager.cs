using UnityEngine;
using System.Collections;

public class RankingManager : MonoBehaviour {
		
	ArrayList ranking;

	private static RankingManager instance = null; 
	
	private RankingManager(){
		load ();
		save ();
		ranking = new ArrayList ();

	}
	
	public static RankingManager getInstance(){
		if(instance == null){
			instance = new RankingManager();
		}
		return instance;
	}



	public void addItem(RankingItem item){
		if (ranking.Contains (item)) {
			return;
		}
		ranking.Add (item);
	}


	public RankingItem getItem(string id) {
		for (int i=0; i<ranking.Count; i++) {
			if( ((RankingItem) ranking[i]).getId() == id) {
				return (RankingItem) ranking[i];
			}
		}
		return null;
	}

	/**
	 * return the top N of the ranking
	 */
	public IList getTop(int topN) {
		if (topN < 0) {
			return null;
		}
		IList list = new ArrayList ();
		for (int i=0; i<topN; i++) {
			list.Add (ranking [i]);
		}
		return list;
	}

	public IList getRanking() {
		return this.ranking;
	}

	public void save() {
	}

	public void load() {
	}

}

