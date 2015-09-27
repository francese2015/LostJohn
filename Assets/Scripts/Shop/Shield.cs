using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == GameTags.asteroid || coll.gameObject.tag == GameTags.boundaryAsteroid) {

			Vector3 pos = transform.position;
			pos.z = 2;

			Instantiate(explosion, pos, Quaternion.identity);
			// boundary asteroids cannot be destroyed
			if (coll.gameObject.tag == GameTags.asteroid) {
				//Debug.Log("distruggo " + coll.transform.name);
				Destroy(coll.gameObject);
			}
			Destroy(gameObject);

			destroyShield();
		}
	}

	private void destroyShield() {
		ShopManager.getInstance ().destroyItem (ShopList.shield);
	}
}
