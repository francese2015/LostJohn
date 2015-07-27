using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public GameObject explosion;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Asteroid") {
			Instantiate(explosion, coll.transform.position, Quaternion.identity);
			Destroy(coll.gameObject);
			Destroy(gameObject);

			destroyShield();
		}
	}

	private void destroyShield() {
		ShopManager.getInstance ().destroyItem (ShopList.shield);
	}
}
