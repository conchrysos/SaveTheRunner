using UnityEngine;
using System.Collections;
using UnityEditor;

public class CoinCreator : MonoBehaviour {
	private RaycastHit objectHit;
	private int no;

	// Use this for initialization
	void Start () {
		no = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOptions.options.getGameStarted ()) {
			return;
		}
		if (no % 150 == 0) {
			Selection.activeObject = AssetDatabase.LoadMainAssetAtPath ("Assets/Prefabs/Coin.prefab");
			Object obstacle = Instantiate (Selection.activeObject, new Vector3 (transform.position.x, transform.position.y, transform.position.z), ((GameObject)Selection.activeObject).transform.rotation);
		}
		no++;
	}
}
