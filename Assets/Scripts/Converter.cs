using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour {
	private GameObject obj;
	public GameObject []enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "base") {
			obj = enemy [Random.Range (0, 2)];
			if (obj.gameObject.tag == "enemy3") {
				transform.position=new Vector3(transform.position.x,-1.2f,transform.position.z);
			}
			Instantiate (obj, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
