using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameLoader : MonoBehaviour {
	public GameObject sound;
	public static bool soundVar=true;
	public Sprite[] img;
	public GameObject Panel;
	public GameObject Panel1;
	// Use this for initialization
	void Start () {
		Variable.score = 0;
		Variable.players = 1;
		soundVar = true;
		Panel.SetActive (false);
		Panel1.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Play()
	{
		Panel1.SetActive (false);
		Panel.SetActive (false);
		Application.LoadLevel ("Scene1");
	}
	public void Guide()
	{
		Panel1.SetActive (false);
		Panel.SetActive (true);
	}
	public void Setting()
	{
		Panel.SetActive (false);
		Panel1.SetActive (true);
	}
	public void SoundPlay()
	{
		if(soundVar==true)
		{
			soundVar = false;
			sound.gameObject.GetComponent<Button> ().GetComponent<Image> ().sprite = img [0];
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource> ().mute = !GetComponent<AudioSource> ().mute;
		}	
		else if (!soundVar) {
			soundVar = true;
			sound.gameObject.GetComponent<Button> ().GetComponent<Image> ().sprite = img [1];
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource> ().mute = GetComponent<AudioSource> ().mute;
		}
	}
}
