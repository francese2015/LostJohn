using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	// CONSTANTS
	public float DEFAULT_DOWN_FACTOR = 3f;
	public float DEFAULT_SPEED = 1f;
	public float forwardSpeed; //forward

	private const float UPPER_LIMIT = 2f;
	private const float BOTTOM_LIMIT = -2f;


	// Player movement fields
	public float difficult_factor = 0.005f; //must be between 0 and 1
	private float upSpeed;
	private float downFactor;

	private bool isFlying = false;

	public AudioClip jump;
	private AudioSource jumpAudioSource;

	private Animator animator;

	public ParticleSystem jetpack;
	
	/**
	 * 
	 */
	void Start () {
		this.upSpeed = DEFAULT_SPEED;
		this.downFactor = DEFAULT_DOWN_FACTOR;
		chechDiffucultFactor ();
		transform.Rotate (new Vector3(0,0,-10));

		jumpAudioSource = GetComponents<AudioSource> ()[1];
		jumpAudioSource.bypassReverbZones = true;

		animator = GetComponent<Animator> ();
	}

	/**
	 * 
	 */
	void Update () {
		// player falls down if user don't force it up
		isFlying = Input.GetMouseButton (0) || Input.GetKeyDown (KeyCode.Space);
		fly (isFlying);

		animator.SetBool ("flying", isFlying);
		adjustJetpack (transform.position.y);
	}

	/*
	void FixedUpdate() {
		Vector3 vel = new Vector3 (forwardSpeed, 0, 0);
		transform.position += vel * Time.deltaTime;
	}
	*/

	private void fly(bool isflying) {
		if (isflying) {
			goUp();
		} else {
			goDown();
		}
	}
	

	private void chechDiffucultFactor (){
		if (difficult_factor > 1) {
			difficult_factor = difficult_factor / 100;
		}
	}

	/**
	 * make the player goes up
	 */
	private void goUp(){
		if (transform.position.y >= UPPER_LIMIT) { 
			return;
		}
		transform.position += Vector3.up * upSpeed * Time.deltaTime;
		Utility.playSoundOnSource (jumpAudioSource, jump, true, 0.3f);
	}
	
	private void resetSpeed(){
		this.upSpeed = DEFAULT_SPEED;
	}

	/**
	 * make the player goes down
	 */
	private void goDown(){
		if (transform.position.y <= BOTTOM_LIMIT) { 
			return;
		}
		transform.position -= Vector3.up * downFactor * Time.deltaTime;
		Utility.playSoundOnSource (jumpAudioSource, jump, true, 0.1f);

	}

	/**
	 * Input value range will be (-1.25, 1.25)
	 */
	public void adjustJetpack(float power) {

		jetpack.emissionRate = power < 0 ? 50f : 300f;

	}
}



