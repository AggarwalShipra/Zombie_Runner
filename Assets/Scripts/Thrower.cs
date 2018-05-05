using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour {
	private Transform Player;
	public GameObject enemy;
	public int speed;
	public int delta;
	private Vector2 pos;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		pos = transform.position;
		Invoke ("spawnObject", 8);
	}
	void spawnObject()
	{
		Instantiate (enemy, transform.position, transform.rotation);
		Start ();
		//start ();
	}
	// Update is called once per frame
	void Update () {
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		pos.x = Player.position.x+5.0f;
		Vector2 v = pos;
		v.x += delta * Mathf.Sin (Time.time * speed);
		transform.position = v;
	}
}
