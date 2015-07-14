using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickToBuy : MonoBehaviour, Observer {

	private string BUY_OK = "Your gadget has " + '\n' + "been bought! :D";
	private string BUY_ERROR = "Sorry, can't buy " + '\n' + " the gadget :(";

	private float scaleFactor = 1.1f;
	private string myName;
	private string itemName;
	private string dialogText;
	private bool clicked = false;

	public GameObject dialogBox;
	public GameObject messageBox;

	public float dialogX = -0.48f;

	GameObject refereceToDialogBox;

	void Start () {
		myName = gameObject.name;

		Transform[] tList = GetComponentsInChildren<Transform> ();
		foreach (Transform t in tList) {
			if(t.name == "name") {
				itemName = t.gameObject.GetComponent<Text>().text;
			}
		}
	}
	
	void FixedUpdate () {
		// when click down 
		if (Input.GetMouseButtonDown(0)) {
			if(checkInput() == myName) {
				if(!clicked) {
					clicked = true;
					scaleUp(true);
					clickSound();
				}
			}
		}
		// when click is finished
		if (Input.GetMouseButtonUp(0)) {
			if(checkInput() == myName) {
				if(clicked) {
					scaleUp(false);
					clicked = false;

					showDialogBox();

				}
			}
		}
	}
	
	/**
	 * Increase or decrease the object's local size when it is clicked
	 */
	private void scaleUp(bool pressed) {
		if (!pressed) {
			transform.localScale /= scaleFactor;
		} else {
			transform.localScale *= scaleFactor;
		}
	}
	
	/**
	 * Check if the clicked input is this one.
	 */
	private string checkInput() {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null) {
			return hit.collider.gameObject.name;
		} else {
			return null;
		}
	}
	
	public void clickSound() {
		PlayClickSound.play();
	}

	
	
	public void notify (bool state) {
		if (state) {// YES has been clicked

			string itemName = transform.name;
			int amount = ShopManager.getInstance().getItem(itemName).coins;

			bool canBuy = ShopManager.getInstance().canBuyItem(itemName);

			if (canBuy) {
				GadgetActivator.getInstance().activate (itemName);
				ShopManager.getInstance ().buyItem (itemName);
			}
		
			if (refereceToDialogBox != null) {
				refereceToDialogBox.SetActive(false);
			}

			showMessageBox(canBuy);
		}
	}

	private void showDialogBox() {
		string itemName = transform.name;

		int lvlToUnlock = ShopManager.getInstance ().getItem (itemName).lvlToUnlock;
		int playerLevel = LevelManager.getInstance ().getLevel ();

		//if cannot buy because of the low level
		if (lvlToUnlock > playerLevel) {
			showMessageBox (false);
		
		} else {

			string dialogtext = "Do you want to buy" + '\n' + itemName + "?";

			refereceToDialogBox = (GameObject)Instantiate (dialogBox, new Vector3 (dialogX, -15, -5), Quaternion.identity);
			refereceToDialogBox.GetComponent<DialogBoxYesNo> ().setDialogText (dialogtext);
			refereceToDialogBox.GetComponent<DialogBoxYesNo> ().register (this);
		}
	}


	private void showMessageBox(bool state) {
		GameObject refereceToMsgBox = (GameObject) Instantiate (messageBox, new Vector3(dialogX, -15, -5), Quaternion.identity);
		string msg = state ? BUY_OK : BUY_ERROR;
		refereceToMsgBox.GetComponent<DialogBoxOk> ().setDialogText (msg);
	}
	
}
