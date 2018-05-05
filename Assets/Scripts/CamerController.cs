using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour {

	private Transform Player;
	private Vector2 pos; 
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		pos = Player.transform.position;
		if (MainGameLoader.soundVar == true) {
			GetComponent<AudioSource> ().Play ();
		} else {
			GetComponent<AudioSource> ().Pause ();
		}
		}

	// Update is called once per frame
	void Update () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		if (Player == null) {
			transform.position = new Vector3 (transform.position.x + 0.02f, 0, -10);
		} else {
			if (Player.position.x > 0 && pos.x < Player.position.x) {
				transform.position = new Vector3 (Player.transform.position.x, 0, -10);
				pos = transform.position;
			}
		}
	}
}
