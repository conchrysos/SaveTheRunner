using UnityEngine;
using System.Collections;
//using UnityEditor;

public class CoinCreator : MonoBehaviour {
	public GameObject coins;
	public GameObject positioner;
	private RaycastHit objectHit;
	private int no, randInt1, randInt2, count, frames;
	private bool isProducing, isStarted;

	// Use this for initialization
	void Start () {
		randInt1 = (int)Mathf.Round(Random.Range (3.0f, 50.0f));
		randInt2 = (int)Mathf.Round(Random.Range (1000.0f, 3000.0f));
		//Debug.Log ("Coins = " + randInt1 + " Frames = " + randInt2);
		count = 0;
		frames = 0;
		no = 0;
		isProducing = false;
		isStarted = false;
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}

	void Update() {
		if (!GameOptions.options.getGameStarted ()) {
			return;
		}

		//if (Input.GetKeyDown (KeyCode.Space)) {
		//	isStarted = true;
		//}

		//if (!isStarted) {
		//	return;
		//}

		if (Mathf.Abs ((int)positioner.transform.position.z) < GameOptions.options.getCoinDistance()) {
			no = GameOptions.options.getCoinDistance ();
		}
		//Debug.Log ("BB = " + (int)GameObject.FindGameObjectWithTag ("Positioner").transform.position.z % 5);
		if (Mathf.Abs((int)positioner.transform.position.z) > no && isProducing) {
			//Selection.activeObject = AssetDatabase.LoadMainAssetAtPath ("Assets/Prefabs/Coin.prefab");
			Instantiate (coins, this.transform.position, /*((GameObject)Selection.activeObject)*/coins.transform.rotation);// as GameObject;
			//coin.transform.SetParent (GameObject.Find ("Coins").transform);
			no = no + GameOptions.options.getCoinDistance();
			if (count++ == randInt1) {
				
				frames = 0;
				randInt2 = (int)Mathf.Round (Random.Range (1000.0f, 3000.0f));
				positioner.GetComponent<Positioner> ().setMove (false);
				positioner.transform.position = Vector3.zero;
				isProducing = false;
			}
		} else if (frames++ == randInt2 && !isProducing) {
			//Debug.Log ("Coins to produce = " + randInt1);
			count = 0;
			randInt1 = (int)Mathf.Round(Random.Range (3.0f, 50.0f));
			positioner.GetComponent<Positioner> ().setMove (true);
			no = GameOptions.options.getCoinDistance ();
			isProducing = true;
		}

		//Debug.Log ("FRAME = " + frames);
	}
}
