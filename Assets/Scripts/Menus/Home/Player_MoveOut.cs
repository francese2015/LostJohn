using UnityEngine;
using System.Collections;

public class Player_MoveOut : MonoBehaviour {

	public float time = 1;
	
	private bool canMove;
	
	// Use this for initialization
	void Start () {
		canMove = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			transform.Translate(3 * Time.deltaTime, 0, 0);
		}
	}

	public void anim() {
		canMove = true;
	}


}
