using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

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
		coinsText.text = "" + coins.getCoins();

		mainAudioSource = GetComponents<AudioSource> ()[0];
		isAlive = true;

		spriteRender = GetComponent<SpriteRenderer> ();
	}


	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("Collision entered with " + coll.gameObject);
		if (isAlive) {
			if (coll.gameObject.tag == "Bound") {
				dead ();
			}

			if (coll.gameObject.tag == "PointZone") {
				increaseScore ();
			}

			if (coll.gameObject.tag == "Asteroid") {
				applyForce (coll.gameObject.transform);
				dead ();
			}
		}
	}
	
	/*
	 * Call the dead method of the player
	 * 
	 */
	private void dead()	{
		isAlive = false;

		coins.save ();
		level.save ();
		score.checkBestScore ();
		score.save ();

		loadRecap ();

		deadAnimation ();
	}



	private void deadAnimation() {
		Utility.playSoundOnSource (mainAudioSource, death, true, 0.3f);

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

		coinsText.text = "" + coins.getCoins ();
		asteroidsText.text = "" + score.getScore ();

		Debug.Log (score.getScore());

		//mainAudioSource.PlayOneShot(point);
		Utility.playSoundOnSource (mainAudioSource, point, true, 1f);
	}


	void applyForce(Transform meteor) {

		Vector3 p = transform.position;
		Vector3 m = meteor.position;
		p *= 10;
		m *= 10;

		Vector3 dir = (p - m) / 5;

		this.rigidbody2D.AddForceAtPosition(dir, transform.position, ForceMode2D.Impulse);
	}

}
