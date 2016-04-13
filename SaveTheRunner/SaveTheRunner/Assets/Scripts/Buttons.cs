using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
	int sound; //0 is off and 1 is on
	int velocityLevel, coinsLevel, coinsValueLevel, shieldLevel, magnetLevel;
	int getCoins;
	public GameObject soundOnButton;
	public GameObject soundOffButton;
	public GameObject powerUps;
	public bool test;

	// Use this for initialization
	void Start () {
		if (test) {
			PlayerPrefs.SetInt ("velocityLevel", 1);
			PlayerPrefs.Save ();
			PlayerPrefs.SetInt ("coinsLevel", 1);
			PlayerPrefs.Save ();
			PlayerPrefs.SetInt ("coinsValueLevel", 1);
			PlayerPrefs.Save ();
			PlayerPrefs.SetInt ("shieldLevel", 1);
			PlayerPrefs.Save ();
			PlayerPrefs.SetInt ("magnetLevel", 1);
			PlayerPrefs.Save ();
		}

		sound = PlayerPrefs.GetInt ("sound", 1);
		velocityLevel = PlayerPrefs.GetInt ("velocityLevel", 1);
		coinsLevel = PlayerPrefs.GetInt ("coinsLevel", 1);
		coinsValueLevel = PlayerPrefs.GetInt ("coinsValueLevel", 1);
		shieldLevel = PlayerPrefs.GetInt ("shieldLevel", 1);
		magnetLevel = PlayerPrefs.GetInt ("magnetLevel", 1);
		GameOptions.options.addCoinsToCollection (2000);
		getCoins = GameOptions.options.getCoinsCollected ();
		InitializeLevels ();


		if (sound == 1) {
			Camera.main.GetComponent <AudioSource> ().Play ();
			soundOffButton.SetActive (true);
			soundOnButton.SetActive (false);
		} 

		else {
			Camera.main.GetComponent <AudioSource> ().Stop ();
			soundOffButton.SetActive (false);
			soundOnButton.SetActive (true);
		}


	}

	public void InitializeLevels(){
		if(velocityLevel == 2){
			powerUps.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (1).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";

		}

		else if(velocityLevel == 3){
			powerUps.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (1).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
		}

		else if(velocityLevel == 4){
			powerUps.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(1).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (1).GetChild (1).gameObject.SetActive (false);
		}

		if(coinsLevel == 2){
			powerUps.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (2).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
		}

		else if(coinsLevel == 3){
			powerUps.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (2).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
		}

		else if(coinsLevel == 4){
			powerUps.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(2).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (2).GetChild (1).gameObject.SetActive (false);
		}

		if(coinsValueLevel == 2){
			powerUps.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (3).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
		}

		else if(coinsValueLevel == 3){
			powerUps.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(3).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (3).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
		}

		else if(coinsValueLevel == 4){
			powerUps.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(3).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(3).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (3).GetChild (1).gameObject.SetActive (false);
		}

		if(shieldLevel == 2){
			powerUps.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (4).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
		}

		else if(shieldLevel == 3){
			powerUps.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(4).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (4).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
		}

		else if(shieldLevel == 4){
			powerUps.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(4).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(4).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (4).GetChild (1).gameObject.SetActive (false);
		}

		if(magnetLevel == 2){
			powerUps.transform.GetChild(5).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (5).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
		}

		else if(magnetLevel == 3){
			powerUps.transform.GetChild(5).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(5).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (5).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
		}

		else if(magnetLevel == 4){
			powerUps.transform.GetChild(5).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(5).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild(5).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
			powerUps.transform.GetChild (5).GetChild (1).gameObject.SetActive (false);
		}
	}

	public void LoadGame(){	
		SceneManager.LoadScene ("Game");	
	}

	public void Exit(){
		Application.Quit ();
	}

	public void SoundOn(){
		PlayerPrefs.SetInt ("sound", 1);
		PlayerPrefs.Save ();
	}

	public void SoundOff(){
		PlayerPrefs.SetInt ("sound", 0);
		PlayerPrefs.Save ();
	}

	public void BuyVelocity(){
		switch (velocityLevel) {
		case 1: 
			if(getCoins >= 100){
				PlayerPrefs.SetInt ("velocityLevel", 2);
				PlayerPrefs.Save ();
				velocityLevel = 2;
				powerUps.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 2: 
			if(getCoins >= 200){
				PlayerPrefs.SetInt ("velocityLevel", 3);
				PlayerPrefs.Save ();
				velocityLevel = 3;
				powerUps.transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 3: 
			if(getCoins >= 300){
				PlayerPrefs.SetInt ("velocityLevel", 4);
				PlayerPrefs.Save ();
				velocityLevel = 4;
				powerUps.transform.GetChild(1).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;
		}
	}

	public void BuyCoins(){
		switch (coinsLevel) {
		case 1: 
			if(getCoins >= 100){
				PlayerPrefs.SetInt ("coinsLevel", 2);
				PlayerPrefs.Save ();
				coinsLevel = 2;
				powerUps.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 2: 
			if(getCoins >= 200){
				PlayerPrefs.SetInt ("coinsLevel", 3);
				PlayerPrefs.Save ();
				coinsLevel = 3;
				powerUps.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 3: 
			if(getCoins >= 300){
				PlayerPrefs.SetInt ("coinsLevel", 4);
				PlayerPrefs.Save ();
				coinsLevel = 4;
				powerUps.transform.GetChild(2).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;
		}
	}

	public void BuyCoinsValue(){
		switch (coinsValueLevel) {
		case 1: 
			if(getCoins >= 100){
				PlayerPrefs.SetInt ("coinsValueLevel", 2);
				PlayerPrefs.Save ();
				coinsValueLevel = 2;
				powerUps.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 2: 
			if(getCoins >= 200){
				PlayerPrefs.SetInt ("coinsValueLevel", 3);
				PlayerPrefs.Save ();
				coinsValueLevel = 3;
				powerUps.transform.GetChild(3).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 3: 
			if(getCoins >= 300){
				PlayerPrefs.SetInt ("coinsValueLevel", 4);
				PlayerPrefs.Save ();
				coinsValueLevel = 4;
				powerUps.transform.GetChild(3).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;
		}
	}

	public void BuyShield(){
		switch (shieldLevel) {
		case 1: 
			if(getCoins >= 100){
				PlayerPrefs.SetInt ("shieldLevel", 2);
				PlayerPrefs.Save ();
				shieldLevel = 2;
				powerUps.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 2: 
			if(getCoins >= 200){
				PlayerPrefs.SetInt ("shieldLevel", 3);
				PlayerPrefs.Save ();
				shieldLevel = 3;
				powerUps.transform.GetChild(4).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 3: 
			if(getCoins >= 300){
				PlayerPrefs.SetInt ("shieldLevel", 4);
				PlayerPrefs.Save ();
				shieldLevel = 4;
				powerUps.transform.GetChild(4).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;
		}
	}

	public void BuyMagnet(){
		switch (magnetLevel) {
		case 1: 
			if(getCoins >= 100){
				PlayerPrefs.SetInt ("magnetLevel", 2);
				PlayerPrefs.Save ();
				magnetLevel = 2;
				powerUps.transform.GetChild(5).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 2: 
			if(getCoins >= 200){
				PlayerPrefs.SetInt ("magnetLevel", 3);
				PlayerPrefs.Save ();
				magnetLevel = 3;
				powerUps.transform.GetChild(5).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;

		case 3: 
			if(getCoins >= 300){
				PlayerPrefs.SetInt ("magnetLevel", 4);
				PlayerPrefs.Save ();
				magnetLevel = 4;
				powerUps.transform.GetChild(5).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
				getCoins = GameOptions.options.getCoinsCollected ();
			}
			break;
		}
	}

}
