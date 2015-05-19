using UnityEngine;
using System.Collections;

public class Player_FlappyMovement : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 flyVelocity;
	public float maxSpeed = 5f;

	private bool isFlying = false;
	public float forwardSpeed = 1f;

	public AudioClip jump;
	private AudioSource source;
	//
	void Start () {
		source = GetComponents<AudioSource> ()[1];
		source.bypassReverbZones = true;
	}

	// Do graphic & input stuff here
	void Update () {
		// player falls down if user don't force it up
		if(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space)){
			isFlying = true;
			playSound();
		}
	}

	private void playSound() {
		if (!source.isPlaying) {
			playSound(jump, 0.2f);
		} else {
			source.Stop();
			playSound(jump, 0.2f);
		}
	}

	private void playSound(AudioClip clip, float volume) {
		source.clip = clip;
		source.volume = volume;
		source.Play ();
	}

	//Do physic stuff here

	void FixedUpdate() {
		fly();
		checkRotation ();	
	}

	private void fly() {
		//to move forward the player, not needed
		velocity.x = forwardSpeed;
		velocity += gravity * Time.deltaTime;

		if(isFlying) {
			velocity.y = 0;
			isFlying = false;
			velocity += flyVelocity;
		}
		//velocity can't be more than maxSPeed
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
		transform.position += velocity * Time.deltaTime;

	}

	private void checkRotation() {
		float angle = 0;
		if (velocity.y < 0) {
			angle = Mathf.Lerp(0, -15, -velocity.y / maxSpeed);
		}
		transform.rotation = Quaternion.Euler (0, 0, angle);
	}

	//Physics tests

	private void physicFlying() {
		//check rigidbody configuration
		if (rigidbody2D.gravityScale == 0) {
			rigidbody2D.gravityScale = 0.2f;
			rigidbody2D.mass = 0.5f;
		}
		if (isFlying) {
			Vector2 force = Vector2.up * flyVelocity.y*4f;
			if(force.y > maxSpeed*4) {
				force = Vector2.ClampMagnitude(force, maxSpeed);
			}
			rigidbody2D.AddForce (force);
			//animator.SetTrigger("fly")
			isFlying = false;

		}
	}



	private void checkPhysicRotation() {
		float angle = Mathf.Lerp (0, -15, (-rigidbody2D.velocity.y / maxSpeed));
		transform.rotation = Quaternion.Euler (0, 0, angle);
	}


	/* FIXME

	public void dead(){
		Instantiate(PlayerDie,transform.position,transform.rotation);
		Destroy (gameObject);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScoreManager> ().checkHighScore ();

	}

	//Play the default audioclip - jump sound
	void playSound(){
		if (!audio.isPlaying) {
			audio.Play();
		}
	}

	 */
}



