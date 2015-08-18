using UnityEngine;
using System.Collections;

public class Asteroid_Movement : MonoBehaviour {

	public float force = 3;

	void Start () {
		transform.GetComponent<Rigidbody2D>().AddForce (Vector2.left * force);
	}
	
	void FixedUpdate () {
		//transform.position = new Vector3 (transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		//transform.position += Vector3.left * speed * Time.deltaTime;
	}
}
