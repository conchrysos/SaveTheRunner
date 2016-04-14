using UnityEngine;
using System.Collections;
//using UnityEditor;

public class HouseCreator : MonoBehaviour {
	public GameObject house;
	public GameObject positioner;
	private int no, houseNo, randInt1, randInt2, count, frames;
	private bool isProducing, isStarted;

	// Use this for initialization
	void Start () {
		randInt1 = (int)Mathf.Round(Random.Range (3.0f, 50.0f));
		randInt2 = (int)Mathf.Round(Random.Range (1000.0f, 3000.0f));
		//Debug.Log ("Coins = " + randInt1 + " Frames = " + randInt2);
		count = 0;
		frames = 0;
		no = 0;
		houseNo = 0;
		isProducing = true;
		isStarted = false;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (!GameOptions.options.getGameStarted ()) {
			return;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			positioner.GetComponent<Positioner> ().setMove (true);
			isStarted = true;
		}

		if (!isStarted) {
			return;
		}
			
		//Debug.Log ("BB = " + (int)GameObject.FindGameObjectWithTag ("Positioner").transform.position.z % 5);
		if (Mathf.Abs((int)positioner.transform.position.z) >= no && isProducing) {
			//Selection.activeObject = AssetDatabase.LoadMainAssetAtPath ("Assets/Prefabs/Coin.prefab");
			GameObject house1 = Instantiate (house, this.transform.position, /*((GameObject)Selection.activeObject)*/Quaternion.identity) as GameObject;
			house1.name = "HouseRight-" + houseNo.ToString ();
			GameObject house2 = Instantiate (house, this.transform.position, /*((GameObject)Selection.activeObject)*/Quaternion.identity) as GameObject;
			house2.name = "HouseLeft-" + houseNo.ToString ();
			house2.transform.Rotate (new Vector3 (0f, 180f, 0f));
			//house2.transform.GetChild (4).transform.Rotate (new Vector3 (0f, 180f, 0f));

			//coin.transform.SetParent (GameObject.Find ("Coins").transform);
			no = no + 3;
			houseNo++;
		}

		//Debug.Log ("FRAME = " + frames);
	}
}
