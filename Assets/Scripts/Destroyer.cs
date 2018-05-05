using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	private Caller _cal;
	// Use this for initialization
	void Start () {
		_cal = GameObject.FindGameObjectWithTag ("static").GetComponent<Caller> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator waiter()
	{
		Debug.Log ("Hello");
		yield return new WaitForSeconds (5);
		Application.LoadLevel ("scene2");
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "enemy3") {
			Destroy (collision.gameObject);
		}
			if (gameObject.tag == "finish" && collision.gameObject.tag != "Player") {
				Destroy (collision.gameObject);
			}
			if (gameObject.tag == "finish" && collision.gameObject.tag == "Player") {
				Debug.Log ("Level 1 Completed");
				Time.timeScale = 0;
				_cal.SendMessage ("endactivate");
				_cal.SendMessage ("printFinalScore");
				StartCoroutine (waiter ());
			}
		
	}

}
