using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FbManager : MonoBehaviour {

	ScoreManager scoreManager;
	List<object> scoreList = null;
	Dictionary<string,string> profile = null;


	public GameObject UIlogIn;
	public GameObject UInotLogIn;
	public Image profilePicture;
	public Text welcomeMessage;

	public GameObject scrollList;
	public GameObject scrollItem;

	// Use this for initialization
	void Awake(){
		FB.Init(SetInit, onHideUnity);
	}

	//to initialize unity sdk
	void SetInit(){

		Debug.Log("Initialization Facebook Manager!");

		if(FB.IsLoggedIn){
			Debug.Log("Log-in done.");
		}
		else{
			Debug.LogError("Can not log-in!");
		}
	}
	//need for documentation
	void onHideUnity(bool onShow){
		if(!onShow){
			Time.timeScale = 0;
		}
		else{
			Time.timeScale = 1;
		}

	}
	//logIn Menù
	public void fbLogin(){
		if(FB.IsLoggedIn){
			Debug.Log("Already logged in!");
			if(Application.loadedLevel == 0){
				sendScoreOnFb();
				showUILogin(true);
			}
		}
		else{
			FB.Login("user_friends, email, publish_actions, public_profile", AuthCallback);
		}

	}
	//active the correct UI about LogIn
	void AuthCallback(FBResult result){
		if(FB.IsLoggedIn){
			Debug.Log("Login OK!");
			if(Application.loadedLevel == 0){
				//send the actual HighScore
				sendScoreOnFb();
				showUILogin(true);
			}

		}
		else{
			Debug.Log("Login NOT OK!");
			if(Application.loadedLevel == 0){
				showUILogin(false);
			}
		}
	}

	//if you log, get photo profile and name
	void showUILogin(bool logIn){
		if(logIn){
			UIlogIn.SetActive(true);
			UInotLogIn.SetActive(false);

			//get profile picture
			FB.API(Util.GetPictureURL("me",128,128),Facebook.HttpMethod.GET,DealWithProfilePicture);
			//get name
			FB.API("/me?fields=id,first_name",Facebook.HttpMethod.GET,DealWithUserName);
			//getFrinds List
			QueryScores();
		}
		else{
			UIlogIn.SetActive(false);
			UInotLogIn.SetActive(true);
		}

	}
	//get UserName
	void DealWithUserName(FBResult result){
		if(result.Error != null){
			Debug.Log("Problem with Name!");
			
			FB.API("/me?fields=id,first_name",Facebook.HttpMethod.GET,DealWithUserName);;
			return;
		}

		profile = Util.DeserializeJSONProfile(result.Text);
		welcomeMessage.text = "Hello, " + profile["first_name"];

	}


	//get Picture Profile
	void DealWithProfilePicture (FBResult result){
		if(result.Error != null){
			Debug.Log("Problem with Profile Picture!");

			FB.API(Util.GetPictureURL("me",128,128),Facebook.HttpMethod.GET,DealWithProfilePicture);
			return;
		}

		profilePicture.sprite = Sprite.Create(result.Texture,new Rect(0,0,128,128),new Vector2(0,0));
	}


	//to save score on Fb
	public void sendScoreOnFb(){

		scoreManager = ScoreManager.getInstance ();
		int score = scoreManager.getBestScore ();
		Debug.Log("Score caricato from ScoreManager: "+score);

			var scoreData = new Dictionary<string,string>();
			scoreData["score"]=score.ToString();
			FB.API("/me/scores",Facebook.HttpMethod.POST,delegate(FBResult result) {
				Debug.Log("Send Score on Fb: "+result.Text);
			},scoreData);
		
	}

	public void QueryScores(){
		FB.API("/app/scores?fields=score,user.limit(30)",Facebook.HttpMethod.GET,ScoreCallback);
	}

	private int i = 0;


	void ScoreCallback(FBResult result){

		Debug.Log("Rsult text = " + result.Text);
		scoreList = Util.DeserializeScores(result.Text);

		foreach(Transform item in scrollList.transform){
			Destroy(item.gameObject);
		}

		//create a itemList with photo,name,score and put in scroll list
		Debug.Log ("score list has " + scoreList.Count);

		foreach(object score in scoreList) {

			var entry = (Dictionary<string,object>) score;
			var user = (Dictionary<string,object>) entry["user"];

			GameObject oneItem = Instantiate(scrollItem) as GameObject;

			oneItem.GetComponent<FB_LeaderboardItemManager>().setName(user["name"].ToString());
			oneItem.GetComponent<FB_LeaderboardItemManager>().setLevel("0");
			oneItem.GetComponent<FB_LeaderboardItemManager>().setScore(entry["score"].ToString());


			FB.API(Util.GetPictureURL(user["id"].ToString()	,128,128),Facebook.HttpMethod.GET,delegate(FBResult picResult) {

				if(picResult.Error != null){
					Debug.Log("Problem with Friend Profile Picture!");
				}
				else{
					Sprite s = Sprite.Create(picResult.Texture,new Rect(0,0,128,128),new Vector2(0,0));
					oneItem.GetComponent<FB_LeaderboardItemManager>().setPhoto(s);
				}

		});
			//put item in scrollList
			oneItem.transform.parent = scrollList.transform;
			oneItem.transform.localScale = Vector3.one;
		}

	}
	
	//to share a simple post in the game
	public void share(){
		scoreManager = ScoreManager.getInstance ();
		FB.Feed(
			linkCaption: "Download it Now and Play!",
			linkName: "I Scored " + scoreManager.getScore() + " in Lost John!",
			link: "http://apps.facebook.com/" + FB.AppId + "?/challenge_brag="+ (FB.IsLoggedIn ? FB.UserId : "guest"),
			picture: "http://www.itlosers.it/img/portfolio/cabin.png"
			);
	}

	public void Invite(){

		FB.AppRequest(
			message: "Come play this great game!",
			title: "Invite your Friends to Play!"
			);
	}
}
