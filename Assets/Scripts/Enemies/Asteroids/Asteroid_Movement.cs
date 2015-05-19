using UnityEngine;
using System.Collections;

public class Asteroid_Movement : MonoBehaviour {

	public float force = 3;

	void Start () {

	}
	
	void Update () {
		//transform.position = new Vector3 (transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		//transform.position += Vector3.left * speed * Time.deltaTime;
		transform.rigidbody2D.AddForce (Vector2.right * -1 * force);
	}
}
