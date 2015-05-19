using UnityEngine;
using System.Collections;

public class Recap_Move : MonoBehaviour {

	
	private Vector3 endPos;

	Vector3 velocity = Vector3.zero;

	public float timeInSec = 0.1f;


	// Use this for initialization
	void Start () {
		endPos = transform.position;
		endPos.y += 3;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.SmoothDamp (transform.position, endPos, ref velocity, timeInSec);
	}
}
