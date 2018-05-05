using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Caller _cal;
	public AudioClip enemyTouch;
	public AudioClip coinCollector;
	public GameObject lifeGame;
	private Transform camera;
	Rigidbody2D playerRigidBody;
	public float moveSpeed;
	public bool grounded;
	public Transform groundCheck;
	private Animator anim;

	IEnumerator waiter()
	{
		//Time.timeScale = 0;
		_cal.SendMessage ("activate");
		_cal.SendMessage ("printFinalScore");
		yield return new WaitForSeconds (3);
		Application.LoadLevel ("scene2");
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform> ();
		_cal = GameObject.FindGameObjectWithTag ("static").GetComponent<Caller> ();
		playerRigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("ground"));
		Debug.Log (grounded);
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (transform.eulerAngles.y != 180)
				transform.eulerAngles = new Vector3 (0, 180, 0);
			anim.Play ("PlayerWalk");
			if (transform.position.x > camera.position.x - 6) {
				playerRigidBody.velocity = new Vector2 (-moveSpeed, playerRigidBody.velocity.y);
			}
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow))
			anim.Play ("PlayerIdle");

		if (Input.GetKey (KeyCode.RightArrow)) {
			if (transform.eulerAngles.y != 0) 
				transform.eulerAngles = new Vector3 (0, 0, 0);
			anim.Play ("PlayerWalk");
			playerRigidBody.velocity = new Vector2 (moveSpeed, playerRigidBody.velocity.y);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow))
			anim.Play ("PlayerIdle");


		if (Input.GetKey (KeyCode.Space)&&grounded) {
			anim.Play ("PlayerJump");
			playerRigidBody.AddForce (new Vector3 (0, 80f, 0));

		}
		if (Input.GetKeyUp (KeyCode.Space))
			anim.Play ("PlayerIdle");
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "life") {
			Destroy (collision.gameObject);
			Vector3 s;
			s=new Vector3(transform.position.x-1*Variable.players,transform.position.y,transform.position.z);
			Variable.players++;
			Instantiate (lifeGame, s, transform.rotation);
			_cal.SendMessage ("printLife");
			//Instantiate ();
		}
		if (collision.gameObject.tag == "skull") {
			Debug.Log ("Skull");
			if (MainGameLoader.soundVar == true) {
				GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource> ().PlayOneShot (coinCollector, 10);
			}
			Destroy (collision.gameObject);
			Variable.score++;
			_cal.SendMessage ("printScore");
		}
		if (collision.gameObject.tag == "enemy1" || collision.gameObject.tag == "enemy2" || collision.gameObject.tag == "enemy3") {
			Debug.Log ("Enemy");
			Variable.players--;
			if (Variable.players < 0)
				Variable.players = 0;
			_cal.SendMessage ("printLife");
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource> ().PlayOneShot (enemyTouch, 8);
			if (Variable.players > 0)
				Destroy (gameObject);
			else
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			if (Variable.players <= 0) {
				StartCoroutine (waiter ());
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "enemy2") {
			Debug.Log ("Enemy");
			Variable.players--;
			if (Variable.players < 0)
				Variable.players = 0;
			_cal.SendMessage ("printLife");

			if (Variable.players > 0)
				Destroy (gameObject);
			else
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			if (Variable.players <= 0) {
				StartCoroutine (waiter ());
			}
		}
	}
}
