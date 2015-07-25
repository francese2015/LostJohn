using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickToBuy : MonoBehaviour, Observer {

	private string BUY_OK = "Your gadget has " + '\n' + "been bought! :D";
	private string BUY_ERROR = "Sorry, can't buy " + '\n' + " the gadget :(";
	private string ALREADY_BOUGHT = "You already have" + '\n' + " this gadget!";

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
			ShopItem item = ShopManager.getInstance().getItem(itemName);

			bool canBuy = ShopManager.getInstance().canBuyItem(itemName);
		
			if (canBuy) {
				// if buy action has success then activate the gadget
				if (ShopManager.getInstance ().buyItem (itemName)) {
					GadgetActivator.getInstance().activate (itemName);
				}
			}
		
			if (refereceToDialogBox != null) {
				refereceToDialogBox.SetActive(false);
			}

			string msgState = canBuy ? BUY_OK : BUY_ERROR;
			showMessageBox(msgState);

			GetComponent<GraphicButtonManager>().update(item);
		}
	}

	private void showDialogBox() {
		string itemName = transform.name;
		ShopItem item = ShopManager.getInstance ().getItem (itemName);

		int lvlToUnlock = item.lvlToUnlock;
		int playerLevel = LevelManager.getInstance ().getLevel ();
		//if the item has already been bought you can not buy it
		bool alreadyBought = item.activatable;

		if (alreadyBought) {
			showMessageBox(ALREADY_BOUGHT);
		} 

		//if cannot buy because of the low level
		else if (lvlToUnlock > playerLevel) {
			showMessageBox (BUY_ERROR);
		
		} else {

			string dialogtext = "Do you want to buy" + '\n' + itemName + "?";

			refereceToDialogBox = (GameObject)Instantiate (dialogBox, new Vector3 (dialogX, -15, -5), Quaternion.identity);
			refereceToDialogBox.GetComponent<DialogBoxYesNo> ().setDialogText (dialogtext);
			refereceToDialogBox.GetComponent<DialogBoxYesNo> ().register (this);
		}
	}


	private void showMessageBox(string msg) {
		GameObject refereceToMsgBox = (GameObject) Instantiate (messageBox, new Vector3(dialogX, -15, -5), Quaternion.identity);
		refereceToMsgBox.GetComponent<DialogBoxOk> ().setDialogText (msg);
	}
	
}
