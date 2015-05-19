using UnityEngine;
using System.Collections;

public class TextureRotation : MonoBehaviour {

	public float speed = 20f;
	private int randomFactor = 1;

	void Start () {
		randomFactor = Random.Range (2, 10);
	}
	
	void Update () {
		transform.Rotate (0, 0, speed * Time.deltaTime * randomFactor);
	}
}
