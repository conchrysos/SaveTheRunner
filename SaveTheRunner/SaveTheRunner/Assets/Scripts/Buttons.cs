using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
	int sound; //0 is off and 1 is on
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
			PlayerPrefs.SetInt ("coins", 0);
			PlayerPrefs.Save ();
			PlayerPrefs.SetFloat ("score", 0.0f);
			PlayerPrefs.Save ();
		}

		sound = PlayerPrefs.GetInt ("sound", 1);

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
		switch (PlayerPrefs.GetInt ("velocityLevel", 1)) {
		case 2:
			{
				powerUps.transform.GetChild (1).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";

			}
			break;

		case 3:
			{
				powerUps.transform.GetChild (1).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
			}
			break;

		case 4:
			{
				powerUps.transform.GetChild (1).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (2).GetChild (3).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (1).gameObject.SetActive (false);
			}
			break;
		}

		switch (PlayerPrefs.GetInt ("coinsLevel", 1)) {
		case 2:
			{
				powerUps.transform.GetChild (2).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
			}
			break;

		case 3:
			{
				powerUps.transform.GetChild (2).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
			}
			break;

		case 4:
			{
				powerUps.transform.GetChild (2).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (2).GetChild (3).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (1).gameObject.SetActive (false);
			}
			break;
		}

		switch (PlayerPrefs.GetInt ("coinsValueLevel", 1)) {
		case 2:
			{
				powerUps.transform.GetChild (3).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
			}
			break;

		case 3:
			{
				powerUps.transform.GetChild (3).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
			}
			break;

		case 4:
			{
				powerUps.transform.GetChild (3).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (2).GetChild (3).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (1).gameObject.SetActive (false);
			}
			break;
		}

		switch (PlayerPrefs.GetInt ("shieldLevel", 1)) {
		case 2:
			{
				powerUps.transform.GetChild (4).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
			}
			break;

		case 3:
			{
				powerUps.transform.GetChild (4).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
			}
			break;

		case 4:
			{
				powerUps.transform.GetChild (4).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (2).GetChild (3).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (1).gameObject.SetActive (false);
			}
			break;
		}

		switch (PlayerPrefs.GetInt ("magnetLevel", 1)) {
		case 2:
			{
				powerUps.transform.GetChild (5).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
			}
			break;

		case 3:
			{
				powerUps.transform.GetChild (5).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
			}
			break;

		case 4:
			{
				powerUps.transform.GetChild (5).GetChild (2).GetChild (1).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (2).GetChild (2).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (2).GetChild (3).GetComponent<Image> ().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (1).gameObject.SetActive (false);
			}
			break;
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
		switch (PlayerPrefs.GetInt ("velocityLevel", 1)) {
		case 1: 
			if(GameOptions.options.getCoinsCollected() >= 100){
				PlayerPrefs.SetInt ("velocityLevel", 2);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
			}
			break;

		case 2: 
			if(GameOptions.options.getCoinsCollected() >= 200){
				PlayerPrefs.SetInt ("velocityLevel", 3);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(1).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
			}
			break;

		case 3: 
			if(GameOptions.options.getCoinsCollected() >= 300){
				PlayerPrefs.SetInt ("velocityLevel", 4);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(1).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (1).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
			}
			break;
		}
	}

	public void BuyCoins(){
		switch (PlayerPrefs.GetInt ("coinsLevel", 1)) {
		case 1: 
			if(GameOptions.options.getCoinsCollected() >= 100){
				PlayerPrefs.SetInt ("coinsLevel", 2);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
			}
			break;

		case 2: 
			if(GameOptions.options.getCoinsCollected() >= 200){
				PlayerPrefs.SetInt ("coinsLevel", 3);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
			}
			break;

		case 3: 
			if(GameOptions.options.getCoinsCollected() >= 300){
				PlayerPrefs.SetInt ("coinsLevel", 4);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(2).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (2).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
			}
			break;
		}
	}

	public void BuyCoinsValue(){
		switch (PlayerPrefs.GetInt ("coinsValueLevel", 1)) {
		case 1: 
			if(GameOptions.options.getCoinsCollected() >= 100){
				PlayerPrefs.SetInt ("coinsValueLevel", 2);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(3).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
			}
			break;

		case 2: 
			if(GameOptions.options.getCoinsCollected() >= 200){
				PlayerPrefs.SetInt ("coinsValueLevel", 3);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(3).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
			}
			break;

		case 3: 
			if(GameOptions.options.getCoinsCollected() >= 300){
				PlayerPrefs.SetInt ("coinsValueLevel", 4);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(3).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (3).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
			}
			break;
		}
	}

	public void BuyShield(){
		switch (PlayerPrefs.GetInt ("shieldLevel", 1)) {
		case 1: 
			if(GameOptions.options.getCoinsCollected() >= 100){
				PlayerPrefs.SetInt ("shieldLevel", 2);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(4).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
			}
			break;

		case 2: 
			if(GameOptions.options.getCoinsCollected() >= 200){
				PlayerPrefs.SetInt ("shieldLevel", 3);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(4).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
			}
			break;

		case 3: 
			if(GameOptions.options.getCoinsCollected() >= 300){
				PlayerPrefs.SetInt ("shieldLevel", 4);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(4).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (4).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
			}
			break;
		}
	}

	public void BuyMagnet(){
		switch (PlayerPrefs.GetInt ("magnetLevel", 1)) {
		case 1: 
			if(GameOptions.options.getCoinsCollected() >= 100){
				PlayerPrefs.SetInt ("magnetLevel", 2);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(5).GetChild(2).GetChild(1).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (1).GetChild (0).GetComponent<Text> ().text = "200 coins";
				GameOptions.options.removeCoinsFromCollection (100);
			}
			break;

		case 2: 
			if(GameOptions.options.getCoinsCollected() >= 200){
				PlayerPrefs.SetInt ("magnetLevel", 3);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(5).GetChild(2).GetChild(2).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (1).GetChild (0).GetComponent<Text> ().text = "300 coins";
				GameOptions.options.removeCoinsFromCollection (200);
			}
			break;

		case 3: 
			if(GameOptions.options.getCoinsCollected() >= 300){
				PlayerPrefs.SetInt ("magnetLevel", 4);
				PlayerPrefs.Save ();
				powerUps.transform.GetChild(5).GetChild(2).GetChild(3).GetComponent<Image>().color = Color.green;
				powerUps.transform.GetChild (5).GetChild (1).gameObject.SetActive (false);
				GameOptions.options.removeCoinsFromCollection (300);
			}
			break;
		}
	}

}
