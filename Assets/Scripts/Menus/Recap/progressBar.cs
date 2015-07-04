using UnityEngine;
using System.Collections;

public class progressBar : MonoBehaviour {

	public float percentage = 75;
	private Vector3 pos;
	private float lastX = 0;

	// Use this for initialization
	void Start () {

		pos = transform.position;
		float x = GetComponent<SpriteRenderer>().bounds.size.x * 2;
		//lastX = pos.x - t;
		Debug.Log ("x iniziale " + x);

		int start = 0;
		float max = transform.localScale.x;

		Vector3 ls = transform.localScale;
		ls.x = 0;
		transform.localScale = ls;

		if (percentage > 1) {
			percentage /= 100;
		}

		Debug.Log (percentage);
	}
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;
		Debug.Log ("position " + pos);

		Vector3 ls = transform.localScale;
		float diff = ls.x;

		ls.x = Mathf.Lerp(ls.x, percentage, Time.deltaTime);
		transform.localScale = ls;	

		diff = ls.x - diff;

		pos = transform.position;
		pos.x += diff *2.4f;
		transform.position = pos;

	}
}
