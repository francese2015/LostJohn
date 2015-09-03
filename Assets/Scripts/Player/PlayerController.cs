using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public GameObject shield;
	private bool isShieldActive = false;

	private SpriteRenderer spriteRender;

	private CoinsManager coins;
	
	private LevelManager level;

	private ScoreManager score;

	private LifeManager life;

	public Text lifesText;
	public Text coinsText;
	public Text asteroidsText;

	public GameObject deathAnimation;
	
	public AudioClip point, death;
	private AudioSource mainAudioSource;

	private bool isAlive = true;

	void Start() {
		coins = CoinsManager.getInstance ();
		level = LevelManager.getInstance ();
		score = ScoreManager.getInstance ();
		life = LifeManager.getInstance ();

		lifesText.text = "x " + life.getLifes();
		coinsText.text = "0";

		mainAudioSource = GetComponents<AudioSource> ()[0];
		mainAudioSource.volume = 0.1f;
		isAlive = true;

		spriteRender = GetComponent<SpriteRenderer> ();

		checkShield ();

	}


	void OnTriggerEnter2D(Collider2D coll) {
//		Debug.Log("Collision entered with " + coll.gameObject);
		if (isAlive) {
			if (coll.gameObject.tag == GameTags.bound) {
				dead ();
			}

			if (coll.gameObject.tag == GameTags.point) {
				increaseScore ();
			}

			if (coll.gameObject.tag == GameTags.coin) {
				increaseCoins ();
			}

			if (coll.gameObject.tag == GameTags.asteroid || coll.gameObject.tag == GameTags.boundaryAsteroid) {
				if (!isShieldActive) {
					dead ();
				} else {
					Debug.Log("Shield has been destroyed against you");
					isShieldActive = false;
				}
			}
		}
	}
	
	/*
	 * Call the dead method of the player
	 * 
	 */
	private void dead()	{
		//add extra exp if a multiplier has been bought
		Debug.LogError ("moltiplicatore: " + LevelManager.getInstance ().getMultiplier ());
		Debug.LogError ("You scored " + score.getScore() + "  and now EXTRA EXP adds " + level.calcExtraExp (score.getScore()));

		level.increaseExp (level.calcExtraExp (score.getScore())); 

		isAlive = false;
		coins.save ();
		level.save ();
		score.checkBestScore ();
		score.save ();

		loadRecap ();

		deadAnimation ();
	}



	private void deadAnimation() {
		Instantiate (deathAnimation, transform.position, transform.rotation);
		Destroy (gameObject);
	}


	private void loadRecap() {
		GameObject g =  GameObject.FindGameObjectWithTag("MainCamera");
		g.GetComponent<LoadRecap> ().loadRecap ();
	}


	void increaseScore(){
		//coins.increaseCoins (); NOT ANYMORE!
		level.increaseExp ();
		score.increaseScore ();
		asteroidsText.text = "" + score.getScore ();
	}

	private void increaseCoins () {
		Utility.playSoundOnSource (mainAudioSource, point, true, 0.3f);
		coins.increaseCoins ();
		score.increaseActualCoin ();
		coinsText.text = "" + score.getActualCoins();

	}


	private void checkShield() {
		if (ShopList.getInstance ().getItem (ShopList.shield).isActivatable ()) {
			Debug.Log("Can activate shield");
			GameObject shieldObject = (GameObject) Instantiate(shield, transform.position, transform.rotation);
			shieldObject.transform.SetParent(transform);

			//put the shield on top of the player
			Vector3 pos = shieldObject.transform.position;
			pos.z = -2;
			pos.y -= 0.02f;
			shieldObject.transform.position = pos;

			isShieldActive = true;
		}
	}
}
