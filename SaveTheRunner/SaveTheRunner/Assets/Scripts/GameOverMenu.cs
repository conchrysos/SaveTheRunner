using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	public void restartLevel() {
		GameOptions.options.restartLevel();
	}

	public void goHome() {
		GameOptions.options.goHome();
	}

	public void exitGame() {
		GameOptions.options.exitGame();
	}
}
