using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {
	//time of invulnerability after the shield destruction
	private const float INVULNERABILITY_DEFAULT = 1f;
	private static bool isInvulnerable = false;

	private bool isShieldActive = false;
	private bool blinking = false;
	//material used for blink effect
	public Material alternativeMaterial, originalMaterial;

	public GameObject shield;

	private SpriteRenderer spriteRenderer;

	//Managers
	private CoinsManager coinsManager;
	private LevelManager levelManager;
	private ScoreManager scoreManager;
	private LifeManager lifeManager;

	//labels in game to update
	public Text lifesText;
	public Text coinsText;
	public Text asteroidsText;

	public GameObject deathAnimation;

	//audio stuff
	public AudioClip point, death;
	private AudioSource mainAudioSource;



	void Start() {
		GameStatus.setPlayerAlive (true);
		spriteRenderer = GetComponent<SpriteRenderer> ();

		coinsManager = CoinsManager.getInstance ();
		levelManager = LevelManager.getInstance ();
		scoreManager = ScoreManager.getInstance ();
		lifeManager = LifeManager.getInstance ();
		scoreManager.resetScore ();

		lifesText.text = "x " + lifeManager.getLifes();
		coinsText.text = "0";

		mainAudioSource = GetComponents<AudioSource> ()[0];
		mainAudioSource.volume = 0.1f;

		spriteRenderer = GetComponent<SpriteRenderer> ();

		checkShield ();



	}


	void Update() {
		if (blinking) {
			StartCoroutine(blink ());
		}
	}


	void OnTriggerEnter2D(Collider2D coll) {
//		Debug.Log("Collision entered with " + coll.gameObject);
			if (coll.gameObject.tag == GameTags.bound) {
				dead ();
			}

			if (coll.gameObject.tag == GameTags.point) {
				asteroidPassed ();
			}

			if (coll.gameObject.tag == GameTags.coin) {
				increaseCoins ();
			}

			if (coll.gameObject.tag == GameTags.asteroid || coll.gameObject.tag == GameTags.boundaryAsteroid) {
				
				if (isShieldActive) {

					isShieldActive = false;
					StartCoroutine(setInvulnerable (INVULNERABILITY_DEFAULT));
					blinking = true;

				} else if (isInvulnerable) {
					// do nothing
				} else {
					dead ();
				}
			}
	}


	/*
	 * Call the dead method of the player
	 */
	private void dead()	{
		//add extra exp if a multiplier has been bought
		//Debug.LogError ("moltiplicatore: " + LevelManager.getInstance ().getMultiplier ());
		//Debug.LogError ("You scored " + score.getScore() + "  and now EXTRA EXP adds " + level.calcExtraExp (score.getScore()));
		GameStatus.setPlayerAlive (false);

		levelManager.increaseExp (levelManager.calcExtraExp (scoreManager.getScore())); 

		coinsManager.save ();
		levelManager.save ();
		scoreManager.checkBestScore ();
		scoreManager.save ();

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


	void asteroidPassed(){
		//Debug.Log("+1");
		levelManager.increaseExp ();
		scoreManager.increaseScore ();
		asteroidsText.text = "" + scoreManager.getScore ();
		//Debug.Log ("actual score: " + ScoreManager.getInstance ().getScore ());
	}


	private void increaseCoins () {
		Utility.playSoundOnSource (mainAudioSource, point, true, 0.3f);
		coinsManager.increaseCoins ();
		scoreManager.increaseActualCoin ();
		coinsText.text = "" + scoreManager.getActualCoins();

	}


	private void checkShield() {
		if (ShopList.getInstance ().getItem (ShopList.shield).isActivatable ()) {
			//activateShield();
			Debug.Log("Can activate the shield");
		}
	}

	public void activateShield() {
		GameObject shieldObject = (GameObject) Instantiate(shield, transform.position, transform.rotation);
		shieldObject.transform.SetParent(transform);
		
		//put the shield on top of the player
		Vector3 pos = shieldObject.transform.position;
		pos.z = -2;
		pos.y -= 0.02f;
		shieldObject.transform.position = pos;
		
		isShieldActive = true;
	}


	public IEnumerator setInvulnerable(float sec) {
		isInvulnerable = true;
		yield return new WaitForSeconds (sec);
		isInvulnerable = false;
	}


	private IEnumerator blink() {
		while (isInvulnerable) {
			//spriteRenderer.color = Color.blue;
			spriteRenderer.material = alternativeMaterial;
			yield return new WaitForSeconds (0.15f);
			//spriteRenderer.color = Color.white;
			spriteRenderer.material = originalMaterial;
			yield return new WaitForSeconds (0.15f);
		}
	}

}
