using UnityEngine;
using System.Collections;

public class ZombiePrefab : MonoBehaviour {
	private RaycastHit objectHit;
	private Animator animator;
	private bool isAttacking;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		isAttacking = false;

		animator.Play ("run02");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), transform.TransformDirection (Vector3.forward) * 50f, Color.red);
		if (Physics.Raycast (new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), transform.TransformDirection (Vector3.forward), out objectHit, 50.0f)) {
			GameObject target = objectHit.collider.gameObject;
			//Debug.Log ("Distance from Player = " + Vector3.Distance (transform.position, target.transform.position));
			if (target.tag.Equals ("Player")) {
				
				if (Vector3.Distance (transform.position, target.transform.position) <= GameOptions.options.getGameSpeed () + 5.0f) {
					Debug.Log ("Zombie Eats Human");
					if (!isAttacking) {
						GetComponent<Animator> ().Play ("atack02");

						isAttacking = true;
					}
				}
			}
		}
	}
}
