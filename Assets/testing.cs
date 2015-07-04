using UnityEngine;
using System.Collections;

public class testing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StorageManager.storeOnDisk (StorageManager.EXP, 46);
		StorageManager.storeOnDisk (StorageManager.LEVEL, 0);
		StorageManager.storeOnDisk (StorageManager.NEXT_GOAL, 0);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
