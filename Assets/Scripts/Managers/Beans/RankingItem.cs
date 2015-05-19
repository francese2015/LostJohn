public class RankingItem {

	private string id;

	private int bestScore;

	private int level;

	public RankingItem (string id, int bestScore, int level) {
		this.id = id;
		this.bestScore = bestScore;
		this.level = level;
	}


	//FIXME: must add getters and setters

	public string getId() {
		return this.id;
	}


	public int getBestScore() {
		return this.bestScore;
	}


	public int getLevel() {
		return this.level;
	}

}


