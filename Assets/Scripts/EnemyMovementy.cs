using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementy : MonoBehaviour {

	public int speed;
	public int delta;
	private Vector2 pos;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	// Update is called once per frame
	void Update () {
		Vector2 v = pos;
		v.y += delta * Mathf.Sin (Time.time * speed);
		transform.position = v;
	}
}
