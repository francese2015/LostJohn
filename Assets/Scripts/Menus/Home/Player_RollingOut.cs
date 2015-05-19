using UnityEngine;
using System.Collections;

public class Player_RollingOut : MonoBehaviour {

	private GameObject player;
	private bool startAnimation = false;
	public float speed = 100f;
	
	// Use this for initialization
	void Start () {
		player = gameObject;
		speed *= 100;
	}
		
	// Update is called once per frame
	void Update () {
		player.transform.Rotate(0, 0, -speed * Time.deltaTime);
	}
		
	public void startAnim(){
		startAnimation = true;
	}

}
